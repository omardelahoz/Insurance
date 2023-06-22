using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.infrastructure.Data
{
    public interface IMongoDbContext<T> : IDisposable where T : class
    {
        Task<bool> Add(T entity);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();
    }
}
