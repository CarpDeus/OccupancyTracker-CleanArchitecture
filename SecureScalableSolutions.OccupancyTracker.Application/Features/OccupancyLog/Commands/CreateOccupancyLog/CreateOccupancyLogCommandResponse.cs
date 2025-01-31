using SecureScalableSolutions.OccupancyTracker.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.OccupancyLog.Commands.CreateOccupancyLog
{
    public class CreateOccupancyLogCommandResponse : BaseResponse
    {
        public CreateOccupancyLogCommandResponse() : base()
        {
        }

        public int CurrentOccupancy { get; set; }

    }
}
