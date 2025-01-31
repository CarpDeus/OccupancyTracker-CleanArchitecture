using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Queries.GetLocationCurrentOccupancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence
{
    public interface ILocationCurrentOccupancyRepository
    {
        Task<GetLocationCurrentOccupancyCommandResponse> UpdateCurrentOccupancy(string locationSqid, int currentOccupancyChange);

        Task<GetLocationCurrentOccupancyCommandResponse> GetCurrentOccupancy(string locationSqid);
    }
}
