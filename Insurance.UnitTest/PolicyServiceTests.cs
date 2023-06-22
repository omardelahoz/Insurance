using FluentAssertions;
using Bogus;
using Insurance.Application.Contracts;
using Insurance.Domain.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Xunit;
using Moq;
using Insurance.infrastructure.Managers;
using Insurance.Application.Features.Policy.Commands;
using Insurance.Application.Features.Policy.Handlers;
using AutoMapper;
using Insurance.Application.Mappings;
using Insurance.infrastructure.Data;
using System.Linq.Expressions;
using System.Linq;
using Insurance.Application.Features.Policy.Queries;

namespace Insurance.UnitTest
{
    public class PolicyServiceTests
    {
        private readonly IMapper _mapper;
        private readonly IPolicyRepository _policyRepository;
        public PolicyServiceTests()
        {
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Add_ValidPolicy_ReturnsTrue()
        {
            // Arrange
            var mockDbContext = new Mock<IMongoDbContext<Policy>>();
            mockDbContext.Setup(db => db.Add(It.IsAny<Policy>())).Returns(Task.FromResult(true));

            var policyManager = new PolicyManager(mockDbContext.Object);
            var command = new CreatePolicyCommandHandler(policyManager, _mapper);

            // Act
            var policy = GenerateFake();
            var result = await command.Handle(policy, CancellationToken.None);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task Get_WithPredicate_ReturnsPolicies()
        {
            // Arrange
            var mockDbContext = new Mock<IMongoDbContext<Policy>>();
            var policies = GenerateFakeList();
            policies[2].PolicyNumber = "WSX123";
            var mappedPolicies = _mapper.Map<IEnumerable<Policy>>(policies);
            mockDbContext.Setup(db => db.GetAll()).Returns(Task.FromResult(mappedPolicies));

            var policyManager = new PolicyManager(mockDbContext.Object);
            GetPolicyQuery request = new GetPolicyQuery("WSX123");
            var command = new GetPolicyQueryHandler(policyManager, _mapper);

            // Act
            var result = await command.Handle(request, CancellationToken.None);

            // Assert
            
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public async Task GetAll_ReturnsAllPolicies()
        {
            // Arrange
            var mockDbContext = new Mock<IMongoDbContext<Policy>>();
            var policies = GenerateFakeList();
            var mappedPolicies = _mapper.Map<IEnumerable<Policy>>(policies);
            mockDbContext.Setup(db => db.GetAll()).Returns(Task.FromResult(mappedPolicies));

            var policyManager = new PolicyManager(mockDbContext.Object);
            var command = new GetPolicyListQueryHandler(policyManager, _mapper);

            // Act
            var result = await policyManager.GetAll();

            // Assert
            mockDbContext.Verify(db => db.GetAll(), Times.Once);

            Assert.Equal(policies.Count, result.Count());
        }

        private CreatePolicyCommand GenerateFake()
        {
            return GenerateFakeList()[0];
        }
        private List<CreatePolicyCommand> GenerateFakeList()
        {
            var faker = new Faker<CreatePolicyCommand>()
                  .RuleFor(p => p.PolicyNumber, f => f.Random.AlphaNumeric(8))
                  .RuleFor(p => p.ClientName, f => f.Person.FullName)
                  .RuleFor(p => p.ClientIdentification, f => f.Random.Replace("#########"))
                  .RuleFor(p => p.ClientBirthDate, f => f.Date.Between(new DateTime(1970, 1, 1), new DateTime(2000, 12, 31)))
                  .RuleFor(p => p.PolicyStartDate, f => f.Date.Future())
                  .RuleFor(p => p.PolicyEndDate, (f, p) => p.PolicyStartDate.AddDays(f.Random.Int(1, 30)))
                  .RuleFor(p => p.Coverages, f => f.Make(f.Random.Int(1, 5), () => f.Random.Word()).ToList())
                  .RuleFor(p => p.MaximumCoverageAmount, f => f.Finance.Amount())
                  .RuleFor(p => p.PolicyPlanName, f => f.Commerce.ProductName())
                  .RuleFor(p => p.ClientCity, f => f.Address.City())
                  .RuleFor(p => p.ClientAddress, f => f.Address.StreetAddress())
                  .RuleFor(p => p.VehiclePlate, f => f.Random.Replace("??###??"))
                  .RuleFor(p => p.VehicleModel, f => f.Vehicle.Model())
                  .RuleFor(p => p.HasInspection, f => f.Random.Bool());

            return faker.Generate(10).ToList();
        }
        private static IAsyncCursor<Policy> MockCursor<Policy>() where Policy : class
        {
            var mockCursor = new Mock<IAsyncCursor<Policy>>();
            mockCursor.Setup(c => c.Current).Returns(Enumerable.Empty<Policy>());
            mockCursor.Setup(c => c.MoveNext(default)).Returns(false);
            return mockCursor.Object;
        }
    }
}
