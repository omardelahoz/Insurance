using AutoMapper;
using Insurance.Application.Contracts;
using Insurance.Application.Features.Policy.Commands;
using Insurance.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Policy.Handlers
{
    public class CreatePolicyCommandHandler : IRequestHandler<CreatePolicyCommand, bool>
    {
        private readonly IPolicyRepository policyRepository;
        private readonly IMapper _mapper;

        public CreatePolicyCommandHandler(IPolicyRepository policyRepository, IMapper mapper)
        {
            this.policyRepository = policyRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreatePolicyCommand request, CancellationToken cancellationToken)
        {
            return await this.policyRepository.Add(_mapper.Map<Insurance.Domain.Entities.Policy>(request));

        }
    }
}
