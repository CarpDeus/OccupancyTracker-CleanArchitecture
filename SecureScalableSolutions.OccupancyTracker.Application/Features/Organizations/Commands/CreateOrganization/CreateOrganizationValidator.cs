using FluentValidation;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using SecureScalableSolutions.OccupancyTracker.Application.DTOs.AddressDto;
using SecureScalableSolutions.OccupancyTracker.Application.DTOs.PhoneDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.CreateOrganization
{
    internal class CreateOrganizationValidator : AbstractValidator<CreateOrganizationCommand>
    {
        private readonly IOrganizationRepository _organizationRepository;
        public CreateOrganizationValidator(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
            RuleFor(x => x.OrganizationName)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(256)
                .WithMessage("{PropertyName} must be between {MinLength} and {MaxLength} characters long.");
            RuleFor(x => x)
                .MustAsync(OrganizationNameIsUnique)
                .WithMessage("Organization name already exists.");
            RuleFor(x => x.OrganizationDescription)
                .MaximumLength(1024)
                 .WithMessage("{PropertyName} mst be less than {MaxLength} characters long.");
            RuleFor(x => x.Address)
                .SetValidator(new AddressValidator());
            RuleFor(x => x.PhoneNumber)
                .SetValidator(new PhoneNumberValidator());
        }

        private async Task<bool> OrganizationNameIsUnique(CreateOrganizationCommand e, CancellationToken token)
        {
            return !await _organizationRepository.IsOrganizationNameUnique(e.OrganizationName);
        }

    }
}
