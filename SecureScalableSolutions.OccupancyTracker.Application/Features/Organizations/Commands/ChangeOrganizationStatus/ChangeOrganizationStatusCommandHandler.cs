using AutoMapper;
using MediatR;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
using SecureScalableSolutions.OccupancyTracker.Application.Exceptions;
using SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.CreateOrganization;
using SecureScalableSolutions.OccupancyTracker.Domain.Entities;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.ChangeOrganizationStatus
{
    public class ChangeOrganizationStatusCommandHandler : IRequestHandler<ChangeOrganizationStatusCommand, bool>
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ChangeOrganizationStatusCommandHandler> _logger;

        public ChangeOrganizationStatusCommandHandler(IOrganizationRepository organizationRepository, IMapper mapper, ILogger<ChangeOrganizationStatusCommandHandler> logger)
        {
            _organizationRepository = organizationRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<bool> Handle(ChangeOrganizationStatusCommand request, CancellationToken cancellationToken)
        {
            var organization = await _organizationRepository.GetByIdAsync(request.OrganizationSqid);
            if (organization == null)
            {
                throw new NotFoundException(nameof(Organization), request.OrganizationSqid);
            }

            organization.CurrentStatus = request.NewStatus;
            await _organizationRepository.UpdateAsync(organization);
            return true;
        }

    }
}
