using AutoMapper;
using Insurance.Application.Contracts;
using Insurance.Application.Features.Policy.Queries;
using MediatR;
using System.Linq.Expressions;

namespace Insurance.Application.Features.Policy.Handlers
{
    public class GetPolicyQueryHandler : IRequestHandler<GetPolicyQuery, List<PolicyVm>>
    {
        private readonly IPolicyRepository policyRepository;
        private readonly IMapper _mapper;

        public GetPolicyQueryHandler(IPolicyRepository policyRepository, IMapper mapper)
        {
            this.policyRepository = policyRepository;
            _mapper = mapper;
        }

        public async Task<List<PolicyVm>> Handle(GetPolicyQuery request, CancellationToken cancellationToken)
        {
            var policyList = await this.policyRepository.Get(
                    p => p.PolicyNumber == request.ParamValue || p.VehiclePlate == request.ParamValue,
                    p => p.OrderBy(i => i.ClientName)
                );
            return _mapper.Map<List<PolicyVm>>(policyList);
        }
    }
}
