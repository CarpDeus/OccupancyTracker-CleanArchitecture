using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Validators
{
    public class AddressLine1Validator: AbstractValidator<string>
    {
        public AddressLine1Validator()
        {
            RuleFor(x => x)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(1024).MinimumLength(3).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
        }

    }
}
