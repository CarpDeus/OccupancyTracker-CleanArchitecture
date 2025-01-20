using FluentValidation;

namespace SecureScalableSolutions.OccupancyTracker.Application.DTOs.AddressDto
{
    public class AddressValidator : AbstractValidator<Address?>
    {
        public AddressValidator()
        {
            RuleFor(x => x)
                .NotNull().WithMessage("{PropertyName}  is required.");
            RuleFor(x => x.AddressLine1)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} is required.")
                .MaximumLength(1024).MinimumLength(3).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(x => x.AddressLine2)
                .MaximumLength(1024).WithMessage("{PropertyName} must be less than {MaxLength} characters long.");
            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(512)
                .MinimumLength(3).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(x => x.State)
                .NotEmpty()
                .MaximumLength(512)
                .MinimumLength(3).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(x => x.PostalCode)
                .NotEmpty()
                .MaximumLength(128)
                .MinimumLength(3).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(x => x.Country)
                .NotEmpty()
                .MaximumLength(128)
                .MinimumLength(3).WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
        }
    }
}