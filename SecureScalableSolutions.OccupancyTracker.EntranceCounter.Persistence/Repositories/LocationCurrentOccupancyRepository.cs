using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using System;
using Couchbase;
using Couchbase.KeyValue;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureScalableSolutions.OccupancyTracker.Application.DTOs.OccupanyLogDto;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Queries.GetLocationCurrentOccupancy;


namespace SecureScalableSolutions.OccupancyTracker.EntranceCounter.Persistence.Repositories
{
    public class LocationCurrentOccupancyRepository : ILocationCurrentOccupancyRepository
    {
        private readonly ICouchbaseCollection _collection;


        public LocationCurrentOccupancyRepository(ICouchbaseCollection collection)
        {
            _collection = collection;
        }

        public async Task<GetLocationCurrentOccupancyCommandResponse> GetCurrentOccupancy(string locationSqid)
        {
            GetLocationCurrentOccupancyCommandResponse getLocationCurrentOccupancyCommandResponse = new GetLocationCurrentOccupancyCommandResponse();
            try
            {
                getLocationCurrentOccupancyCommandResponse.CurrentOccupancy = Convert.ToInt32( await SharedFunctionality.Counters.GetCounter(_collection, locationSqid));
                return getLocationCurrentOccupancyCommandResponse;
            }
            catch
            {
                return getLocationCurrentOccupancyCommandResponse;
            }
        }

        public async Task<GetLocationCurrentOccupancyCommandResponse> UpdateCurrentOccupancy(string locationSqid, int currentOccupancyChange)
        {
            GetLocationCurrentOccupancyCommandResponse getLocationCurrentOccupancyCommandResponse = new GetLocationCurrentOccupancyCommandResponse();
            getLocationCurrentOccupancyCommandResponse.CurrentOccupancy= await SharedFunctionality.Counters.UpdateCounter(_collection, locationSqid, currentOccupancyChange);
            return getLocationCurrentOccupancyCommandResponse;
        }

    }
}
