using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LaunchApi.Contracts.v1.Transport.Requests
{
    public abstract class GetPagedRequestBase : IValidatableObject
    {
        [FromQuery]
        [Range(1, int.MaxValue, ErrorMessage = "PageNumber is not in the range from 1 to int maximum value")]
        [Required(ErrorMessage = "PageNumber must be specified")]
        public uint PageNumber { get; set; }

        [FromQuery]
        [Range(1, int.MaxValue, ErrorMessage = "PageSize is not in the range from 1 to int maximum value")]
        [Required(ErrorMessage = "PageSize must be specified")]
        public uint PageSize { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            if (PageSize < 1)
            {
                result.Add(new ValidationResult($"{nameof(PageSize)} should be more than 0"));
            }

            if (PageNumber < 1)
            {
                result.Add(new ValidationResult($"{nameof(PageNumber)} should be more than 0"));
            }

            return result.Concat(ValidateChild());
        }

        protected virtual IEnumerable<ValidationResult> ValidateChild() => Enumerable.Empty<ValidationResult>();
    }
}
