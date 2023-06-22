using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Application.Exceptions
{
    public class InsuranceExcepcion : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; } = new Dictionary<string, string[]>();
        public InsuranceExcepcion(string message) : base(message)
        {
            
        }
        public InsuranceExcepcion(IEnumerable<ValidationFailure> failures) : this("Se presentaron uno o mas errores de validacion")
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());

        }
    }
}
