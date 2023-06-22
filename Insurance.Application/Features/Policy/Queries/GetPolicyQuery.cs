using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Policy.Queries
{
    public class GetPolicyQuery : IRequest<List<PolicyVm>>
    {
        public string ParamValue { get; set; } = string.Empty;

        public GetPolicyQuery(string paramValue)
        {
            this.ParamValue = paramValue;
        }
    }
}
