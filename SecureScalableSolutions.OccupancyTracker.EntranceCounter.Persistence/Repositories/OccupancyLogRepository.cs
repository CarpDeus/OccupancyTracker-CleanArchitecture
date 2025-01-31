using Couchbase.KeyValue;
using Couchbase;
using Microsoft.Extensions.Configuration;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using SecureScalableSolutions.OccupancyTracker.Application.DTOs.OccupanyLogDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.ChangeLocationCurrentOccupancy;
using SecureScalableSolutions.OccupancyTracker.Application.Features.OccupancyLog.Commands.CreateOccupancyLog;

namespace SecureScalableSolutions.OccupancyTracker.EntranceCounter.Persistence.Repositories
{
    public class OccupancyLogRepository : IOccupanyLogRepository
    {
        private readonly ICouchbaseCollection _collection;

        public OccupancyLogRepository(ICouchbaseCollection collection)
        {
            _collection = collection;
        }
        

        public async Task<CreateOccupancyLogCommandResponse> AddAsync(OccupancyLogDto occupanyLogDto)
        {
            CreateOccupancyLogCommandResponse createOccupancyLogCommandResponse = new CreateOccupancyLogCommandResponse();
            await _collection.InsertAsync(occupanyLogDto.Id, occupanyLogDto);
            createOccupancyLogCommandResponse.CurrentOccupancy= await SharedFunctionality.Counters.UpdateCounter(_collection, occupanyLogDto.LocationSqid, occupanyLogDto.LoggedChange);
            return createOccupancyLogCommandResponse;

        }
    }
}
