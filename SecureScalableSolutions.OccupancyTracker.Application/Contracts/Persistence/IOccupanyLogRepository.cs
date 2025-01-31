using SecureScalableSolutions.OccupancyTracker.Application.DTOs.OccupanyLogDto;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.ChangeLocationCurrentOccupancy;
using SecureScalableSolutions.OccupancyTracker.Application.Features.OccupancyLog.Commands.CreateOccupancyLog;
using SecureScalableSolutions.OccupancyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence
{
    public interface IOccupanyLogRepository
    {
        Task<CreateOccupancyLogCommandResponse> AddAsync(OccupancyLogDto occupanyLogDto);
    }
}
