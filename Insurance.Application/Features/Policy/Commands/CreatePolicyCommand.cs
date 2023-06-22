using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Policy.Commands
{
    public class CreatePolicyCommand : IRequest<bool>
    {
        public string PolicyNumber { get; set; } = string.Empty;
        public string ClientName { get; set; } = string.Empty;
        public string ClientIdentification { get; set; } = string.Empty;
        public DateTime ClientBirthDate { get; set; }
        public DateTime PolicyStartDate { get; set; }
        public DateTime PolicyEndDate { get; set; }
        public List<string> Coverages { get; set; }
        public decimal MaximumCoverageAmount { get; set; }
        public string PolicyPlanName { get; set; } = string.Empty;
        public string ClientCity { get; set; } = string.Empty;
        public string ClientAddress { get; set; } = string.Empty;
        public string VehiclePlate { get; set; } = string.Empty;
        public string VehicleModel { get; set; } = string.Empty;
        public bool HasInspection { get; set; }
        public CreatePolicyCommand()
        {
            this.Coverages = new List<string>();
        }
    }
}
