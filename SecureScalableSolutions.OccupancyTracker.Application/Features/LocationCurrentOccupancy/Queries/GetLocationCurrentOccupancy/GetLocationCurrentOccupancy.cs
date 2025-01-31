using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Queries.GetLocationCurrentOccupancy
{
    public class GetLocationCurrentOccupancyCommand : IRequest<GetLocationCurrentOccupancyCommandResponse>    
    {
        public string LocationSqid { get; set; } = string.Empty;
        public GetLocationCurrentOccupancyCommand(string locationSqid)
        {
            LocationSqid = locationSqid;
        }
    }
}
