using FluentValidation;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.SetLocationCurrentOccupancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Queries.GetLocationCurrentOccupancy
{
    internal class GetLocationCurrentOccupancyValidator : AbstractValidator<GetLocationCurrentOccupancyCommand>
    {
        public GetLocationCurrentOccupancyValidator()
        {
            RuleFor(x => x.LocationSqid)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(256)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
        }
    }
}
