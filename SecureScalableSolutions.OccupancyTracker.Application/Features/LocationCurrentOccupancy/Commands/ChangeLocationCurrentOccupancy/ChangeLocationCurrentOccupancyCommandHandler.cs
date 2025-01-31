using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.SetLocationCurrentOccupancy;
using SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.CreateOrganization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.ChangeLocationCurrentOccupancy
{
    public  class ChangeLocationCurrentOccupancyCommandHandler : IRequestHandler<ChangeLocationCurrentOccupancyCommand, ChangeLocationCurrentOccupancyResponse>
    {
        private readonly ILogger<ChangeLocationCurrentOccupancyCommandHandler> _logger;
        private readonly ILocationCurrentOccupancyRepository _locationCurrentOccupancyRepository;

        public ChangeLocationCurrentOccupancyCommandHandler(ILogger<ChangeLocationCurrentOccupancyCommandHandler> logger, ILocationCurrentOccupancyRepository locationCurrentOccupancyRepository)
        {
            _logger = logger;
            _locationCurrentOccupancyRepository = locationCurrentOccupancyRepository;
        }

        public async Task<ChangeLocationCurrentOccupancyResponse> Handle(ChangeLocationCurrentOccupancyCommand request, CancellationToken cancellationToken)
        {
            var changeLocationCurrentOccupancyResponse = new ChangeLocationCurrentOccupancyResponse();
            var validator = new ChangeLocationCurrentOccupancyValidator();
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Count > 0)
            {
                changeLocationCurrentOccupancyResponse.Success = false;
                changeLocationCurrentOccupancyResponse.ValidationErrors = new List<string>();
                foreach (var error in validationResult.Errors)
                {
                    changeLocationCurrentOccupancyResponse.ValidationErrors.Add(error.ErrorMessage);
                }
            }
            if (changeLocationCurrentOccupancyResponse.Success)
            {
                var currentOccupancy = await _locationCurrentOccupancyRepository.UpdateCurrentOccupancy(request.LocationSqid, request.CurrentOccupancyChange);
                _logger.LogInformation($"Location {request.LocationSqid} changed by {request.CurrentOccupancyChange} to {currentOccupancy}.");
                changeLocationCurrentOccupancyResponse.CurrentOccupancy= Convert.ToInt32(currentOccupancy);
            }
            return changeLocationCurrentOccupancyResponse;
        }
    }
}
