using FluentValidation;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.SetLocationCurrentOccupancy;
using SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.CreateOrganization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.ChangeLocationCurrentOccupancy
{
    internal class ChangeLocationCurrentOccupancyValidator : AbstractValidator<ChangeLocationCurrentOccupancyCommand>
    {
        public ChangeLocationCurrentOccupancyValidator()
        {
            RuleFor(x => x.LocationSqid)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(256)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(x => x.CurrentOccupancyChange)
                .NotEmpty()
                .WithMessage("{PropertyName} must be provided.");
        }
    }
}
