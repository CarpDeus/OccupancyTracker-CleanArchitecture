using MediatR;
using Microsoft.Extensions.Logging;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.ChangeLocationCurrentOccupancy;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.SetLocationCurrentOccupancy;
using SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.CreateOrganization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Queries.GetLocationCurrentOccupancy
{
    public class GetLocationCurrentOccupancyCommandHandler : IRequestHandler<GetLocationCurrentOccupancyCommand, GetLocationCurrentOccupancyCommandResponse>
    {
        private readonly ILogger<GetLocationCurrentOccupancyCommand> _logger;
        private readonly ILocationCurrentOccupancyRepository _locationCurrentOccupancyRepository;

        public GetLocationCurrentOccupancyCommandHandler(ILogger<GetLocationCurrentOccupancyCommand> logger, ILocationCurrentOccupancyRepository locationCurrentOccupancyRepository)
        {
            _logger = logger;
            _locationCurrentOccupancyRepository = locationCurrentOccupancyRepository;
        }

        public async Task<GetLocationCurrentOccupancyCommandResponse> Handle(GetLocationCurrentOccupancyCommand request, CancellationToken cancellationToken)
        {
            GetLocationCurrentOccupancyCommandResponse getLocationCurrentOccupancyCommandResponse = new GetLocationCurrentOccupancyCommandResponse();
            var validator = new GetLocationCurrentOccupancyValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                getLocationCurrentOccupancyCommandResponse.Success = false;
                getLocationCurrentOccupancyCommandResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    getLocationCurrentOccupancyCommandResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (getLocationCurrentOccupancyCommandResponse.Success)
            { 
                getLocationCurrentOccupancyCommandResponse=  await _locationCurrentOccupancyRepository.GetCurrentOccupancy(request.LocationSqid);
                _logger.LogInformation($"Location {request.LocationSqid} current occupancy was {getLocationCurrentOccupancyCommandResponse.CurrentOccupancy}.");
            }
            return getLocationCurrentOccupancyCommandResponse;
        }
    }
}
