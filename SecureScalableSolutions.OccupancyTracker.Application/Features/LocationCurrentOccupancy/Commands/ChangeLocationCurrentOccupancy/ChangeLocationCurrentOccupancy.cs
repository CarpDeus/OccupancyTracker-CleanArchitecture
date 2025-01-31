using MediatR;
using SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.ChangeLocationCurrentOccupancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.LocationCurrentOccupancy.Commands.SetLocationCurrentOccupancy
{
    public class ChangeLocationCurrentOccupancyCommand : IRequest<ChangeLocationCurrentOccupancyResponse>
    {
        /// <summary>
        /// Location Identifier
        /// </summary>
        public string LocationSqid { get; set; } = string.Empty;

        /// <summary>
        /// Description of the organization
        /// </summary>
        public int CurrentOccupancyChange { get; set; } 

        public ChangeLocationCurrentOccupancyCommand(string locationSqid, int currentOccupancyChange)
        {
            LocationSqid = locationSqid;
            CurrentOccupancyChange = currentOccupancyChange;
        }
    }
}
