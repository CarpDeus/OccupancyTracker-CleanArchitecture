using SecureScalableSolutions.OccupancyTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{

    /// <summary>
    /// Entrance is a point of entry to a location
    /// </summary>
    public class Entrance : AuditableEntity
    {

        /// <summary>
        /// Human Readable Name
        /// </summary>
        public string EntranceName { get; set; } = string.Empty;

        /// <summary>
        /// Description of the entrance
        /// </summary>
        public string EntranceDescription { get; set; } = string.Empty;

        /// <summary>
        /// Public facing entrance identifier
        /// </summary>
        public string EntranceSqid { get; set; } = string.Empty;

        /// <summary>
        /// The current entrance counter public facing identifier
        /// </summary>
        public EntranceCounter? EntranceCounter { get; set; } 

        /// <summary>
        /// Status of the entrance
        /// </summary>
        public int CurrentStatus { get; set; } = 0;

        public Location Location { get; set; } = default!;


    }
}
