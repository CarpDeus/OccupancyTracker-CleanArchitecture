using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.EntranceCounter.Persistence.Models
{
    public class LocationCurrentOccupancy
    {
        public string LocationSqid { get; set; } = string.Empty;
        public int CurrentOccupancy { get; set; } = 0;
    }
}
