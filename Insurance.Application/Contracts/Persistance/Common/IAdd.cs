using Insurance.Domain.Common;

namespace Insurance.Application.Contracts.Persistance.Common
{
    public interface IAdd<T> where T : BaseDomain
    {
        Task<bool> Add(T entity);
    }
}
