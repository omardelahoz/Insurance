using Insurance.Application.Contracts;
using Insurance.Domain.Entities;
using Insurance.infrastructure.Data;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Insurance.infrastructure.Managers
{
    public class PolicyManager : IPolicyRepository
    {
        private const string _collection = "Policies";
        private readonly IMongoDbContext<Policy> _dbContext;
        public PolicyManager(IMongoDbContext<Policy> dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> Add(Policy entity)
        {
            await _dbContext.Add(entity);
            return true;
        }

        public async Task<IEnumerable<Domain.Entities.Policy>> Get(Expression<Func<Policy, bool>> predicate, Func<IQueryable<Policy>, IOrderedQueryable<Domain.Entities.Policy>>? orderBy = null)
        {
            return await _dbContext.Get(predicate);
        }

        public async Task<IEnumerable<Domain.Entities.Policy>> GetAll()
        {
            return await _dbContext.GetAll();
        }
    }
}
