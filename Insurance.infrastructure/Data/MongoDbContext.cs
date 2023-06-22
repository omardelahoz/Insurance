using MongoDB.Driver;
using System.Linq.Expressions;
using System.Reflection;

namespace Insurance.infrastructure.Data
{
    public class MongoDbContext<T> : IMongoDbContext<T> where T : class
    {
        private IMongoDatabase? _database;
        private readonly IMongoCollection<T> _collection;
        public MongoDbContext(IMongoDatabase database, string collectionname)
        {
            //this.client = new MongoClient(configuration.GetConnectionString("MongoDB"));

            _database = database;// client.GetDatabase(configuration.GetSection("MongoDBName").Value);
            _collection = _database.GetCollection<T>(collectionname);
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await _collection.Find(predicate).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<bool> Add(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _database = null;
            }
        }
    }
}
