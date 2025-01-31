using SecureScalableSolutions.OccupancyTracker.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.ChangeLocationCurrentOccupancy
{
    public class ChangeLocationCurrentOccupancyResponse : BaseResponse
    {
        public ChangeLocationCurrentOccupancyResponse() : base()
        {
        }
        public int CurrentOccupancy { get; set; }
    }
}
