using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Features.Policy.Commands
{
    public class CreatePolicyCommandValidator : AbstractValidator<CreatePolicyCommand>
    {
        public CreatePolicyCommandValidator()
        {
            RuleFor(p => p.PolicyEndDate)
                .GreaterThan(DateTime.Now).WithMessage("la poliza no es vigente");
            RuleFor(p => p.ClientAddress)
                .NotEmpty().WithMessage("Debe ingresar un valor para la la dirección del cliente")
                .NotNull().WithMessage("Debe ingresar un valor para la la dirección del cliente");
            RuleFor(p => p.VehicleModel)
                .NotEmpty().WithMessage("Debe ingresar un valor para el modelo del vehiculo")
                .NotNull().WithMessage("Debe ingresar un valor para el modelo del vehiculo");
            RuleFor(p => p.ClientBirthDate)
                .NotEmpty().WithMessage("Debe ingresar un valor para la fecha de nacimiento del cliente")
                .NotNull().WithMessage("Debe ingresar un valor para la fecha de nacimiento del cliente ");
            RuleFor(p => p.ClientCity)
                .NotEmpty().WithMessage("Debe ingresar un valor para la ciudad del cliente")
                .NotNull().WithMessage("Debe ingresar un valor para la ciudad del cliente ");
            RuleFor(p => p.ClientIdentification)
                .NotEmpty().WithMessage("Debe ingresar un valor para la identificación del cliente")
                .NotNull().WithMessage("Debe ingresar un valor para la identificación del cliente");
            RuleFor(p => p.ClientName)
                .NotEmpty().WithMessage("Debe ingresar un valor para el nombre del cliente")
                .NotNull().WithMessage("Debe ingresar un valor para el nombre del cliente ");
            RuleFor(p => p.Coverages)
                .NotEmpty().WithMessage("Debe ingresar un valor para las coberturas")
                .NotNull().WithMessage("Debe ingresar un valor para las coberturas ");
            RuleFor(p => p.MaximumCoverageAmount)
                .NotEmpty().WithMessage("Debe ingresar un valor para ")
                .NotNull().WithMessage("Debe ingresar un valor para ")
                .GreaterThan(0).WithMessage("El valor máximo debe ser mayor a 0");
            RuleFor(p => p.PolicyNumber)
                .NotEmpty().WithMessage("Debe ingresar un valor para el número de poliza")
                .NotNull().WithMessage("Debe ingresar un valor para el número de poliza");
            RuleFor(p => p.PolicyPlanName)
               .NotEmpty().WithMessage("Debe ingresar un valor para el plan de poliza")
               .NotNull().WithMessage("Debe ingresar un valor para el plan de poliza");
            RuleFor(p => p.PolicyStartDate)
               .NotEmpty().WithMessage("Debe ingresar un valor para el inicio de la poliza")
               .NotNull().WithMessage("Debe ingresar un valor para el inicio de la poliza");
            RuleFor(p => p.VehiclePlate)
               .NotEmpty().WithMessage("Debe ingresar un valor para la placa del vehículo")
               .NotNull().WithMessage("Debe ingresar un valor para la placa del vehículo");

        }
    }
}
