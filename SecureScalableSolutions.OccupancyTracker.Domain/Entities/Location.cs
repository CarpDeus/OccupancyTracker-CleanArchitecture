using SecureScalableSolutions.OccupancyTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{
    /// <summary>
    /// Locations are the physical locations where occupancy is tracked
    /// </summary>
    public class Location: AuditableEntity 
    {

        /// <summary>
        /// Public facing location identifier
        /// </summary>
        public string? LocationSqid { get; set; }


        /// <summary>
        /// Human readable name of the location
        /// </summary>
        public string LocationName { get; set; } = string.Empty;

        /// <summary>
        /// Description of the location
        /// </summary>
        public string LocationDescription { get; set; } = string.Empty;

        /// <summary>
        /// Maximum occupancy of the location
        /// </summary>
        public int MaxOccupancy { get; set; } 

        /// <summary>
        /// Current occupancy. Generally set using the entrance counters
        /// </summary>
        public int CurrentOccupancy { get; set; } 

        /// <summary>
        /// The point at which a location is close enough to full to trigger a warning
        /// </summary>
        public int OccupancyThresholdWarning { get; set; } 

        /// <summary>
        /// The address of the location
        /// </summary>
        public Address? LocationAddress { get; set; }

        /// <summary>
        /// Contact phone number for the location
        /// </summary>
        public PhoneNumber? PhoneNumber { get; set; }

        /// <summary>
        /// Status of the data
        /// </summary>
        public int CurrentStatus { get; set; } = 0;

        public Organization Organization { get; set; } = default!;

        public ICollection<Entrance>? Entrances { get; set; }
    }
}
