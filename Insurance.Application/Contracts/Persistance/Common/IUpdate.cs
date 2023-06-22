using Insurance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Contracts.Persistance.Common
{
    public interface IUpdate<T> where T : BaseDomain
    {
        Task Update(T entity);
    }
}
