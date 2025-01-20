using AutoMapper;
using MediatR;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
using System;
using SecureScalableSolutions.OccupancyTracker.Application.Exceptions;
using SecureScalableSolutions.OccupancyTracker.Domain.Entities;
using SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.CreateOrganization;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.UpdateOrganization
{
    public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOrganizationCommandHandler> _logger;

        public UpdateOrganizationCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper, ILogger<CreateOrganizationCommandHandler> logger)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(UpdateOrganizationCommand request, CancellationToken cancellationToken)
        {
            var organizationToUpdate = await _organizationRepository.GetByIdAsync(request.OrganizationSqid);

            if (organizationToUpdate == null)
            {
                throw new NotFoundException(nameof(Organization), request.OrganizationSqid);
            }

            var validator = new UpdateOrganizationValidator(_organizationRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);


            _mapper.Map(request, organizationToUpdate, typeof(UpdateOrganizationCommand), typeof(Organization));

            await _organizationRepository.UpdateAsync(organizationToUpdate);
        }

    }
}
