using AutoMapper;
using MediatR;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
using System;
using SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.CreateOrganization;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.CreateOrganization
{
    public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, string>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrganizationCommandHandler> _logger;

        public CreateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper, ILogger<CreateOrganizationCommandHandler> logger)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> Handle(CreateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateOrganizationValidator(_organizationRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new Exceptions.ValidationException(validationResult);

            var organizationToCreate = _mapper.Map<Domain.Entities.Organization>(request);
            var createdOrganization = await _organizationRepository.AddAsync(organizationToCreate);
            _logger.LogInformation($"Organization {createdOrganization.OrganizationSqid} is successfully created.");
            return createdOrganization.OrganizationSqid;
        }

    }
}
