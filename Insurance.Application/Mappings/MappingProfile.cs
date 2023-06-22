using AutoMapper;
using Insurance.Application.Features.Policy;
using Insurance.Application.Features.Policy.Commands;
using Insurance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Policy, PolicyVm>().ReverseMap();
            CreateMap<Policy, CreatePolicyCommand>().ReverseMap();
        }
    }
}
