using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Policy.Queries
{
    public class GetPolicyListQuery: IRequest<List<PolicyVm>>
    {
        public GetPolicyListQuery()
        {
            
        }
    }
}
