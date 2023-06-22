using Insurance.Application.Contracts;
using Insurance.Domain.Entities;
using Insurance.infrastructure.Data;
using Insurance.infrastructure.Managers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Insurance.infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });
            services.AddScoped(typeof(IPolicyRepository), typeof(PolicyManager));

            services.AddScoped<IMongoDatabase>(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                var connectionString = configuration.GetConnectionString("MongoDB");
                var databaseName = configuration.GetSection("MongoDBName").Value;

                var client = new MongoClient(connectionString);
                return client.GetDatabase(databaseName);
            });

            services.AddScoped<IMongoDbContext<Policy>>(provider =>
            {
                var database = provider.GetRequiredService<IMongoDatabase>();
                var collectionName = "Policies"; 
                return new MongoDbContext<Policy>(database, collectionName);
            });

            return services;
        }
    }
}
