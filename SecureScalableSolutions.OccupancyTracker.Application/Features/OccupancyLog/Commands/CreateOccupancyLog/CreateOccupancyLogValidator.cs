using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.OccupancyLog.Commands.CreateOccupancyLog
{
    public class CreateOccupancyLogValidator : AbstractValidator<CreateOccupancyLogCommand>
    {
        public CreateOccupancyLogValidator()
        {
            RuleFor(p => p.OrganizationSqid)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(256)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(p => p.LocationSqid)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(256)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(p => p.EntranceSqid)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(256)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(p => p.EntranceCounterSqid)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(256)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(p => p.LoggedChange)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }
    }
}
