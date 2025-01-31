using SecureScalableSolutions.OccupancyTracker.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Queries.GetLocationCurrentOccupancy
{
    public  class GetLocationCurrentOccupancyCommandResponse : BaseResponse
    {
        public GetLocationCurrentOccupancyCommandResponse() : base()
        {
        }
        public int CurrentOccupancy { get; set; }
    }
}