using Insurance.Domain.Common;
using System.Linq.Expressions;

namespace Insurance.Application.Contracts.Persistance.Common
{
    public interface IGet<T> where T : BaseDomain
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    }
}
