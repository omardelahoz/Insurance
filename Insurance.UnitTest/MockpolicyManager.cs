using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Insurance.Application.Contracts;
using Insurance.Domain.Entities;
using Insurance.infrastructure.Managers;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;
using Xunit;


namespace Insurance.UnitTest
{
    public class MockpolicyManager
    {
        public static Mock<PolicyManager> GetPoliocymanager()
        {
            var inMemoryMongoClient = new MongoClient();
            IMongoDatabase database = inMemoryMongoClient.GetDatabase("test_database");

            var mockPolicyManager = new Mock<PolicyManager>(database);

            return mockPolicyManager;
        }

    }
}
