using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.DTOs.PhoneDto
{
    public class PhoneNumberValidator : AbstractValidator<PhoneNumber?>
    {
        public PhoneNumberValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.CountryCode)
                .NotEmpty()
                .MinimumLength(1)
                .MaximumLength(8).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(x => x.Number)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(32).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
        }
    }
}

