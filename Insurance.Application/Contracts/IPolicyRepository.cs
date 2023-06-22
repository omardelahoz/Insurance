using Insurance.Application.Contracts.Persistance.Common;
using Insurance.Domain.Entities;

namespace Insurance.Application.Contracts
{
    public interface IPolicyRepository : IAdd<Policy>, IGet<Policy>
    {

    }
}
