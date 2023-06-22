using AutoMapper;
using Insurance.Application.Contracts;
using Insurance.Application.Features.Policy.Queries;
using Insurance.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Policy.Handlers
{
    public class GetPolicyListQueryHandler : IRequestHandler<GetPolicyListQuery, List<PolicyVm>>
    {
        private readonly IPolicyRepository? policyRepository;
        private readonly IMapper _mapper;

        public GetPolicyListQueryHandler(IPolicyRepository? policyRepository, IMapper mapper)
        {
            this.policyRepository = policyRepository;
            _mapper = mapper;
        }

        public async Task<List<PolicyVm>> Handle(GetPolicyListQuery request, CancellationToken cancellationToken)
        {
            var policyList = await policyRepository!.GetAll();

            return _mapper.Map<List<PolicyVm>>(policyList);
        }
    }
}
