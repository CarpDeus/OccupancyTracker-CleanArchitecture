using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{
    public class OccupanyLog
    {
        /// <summary>
        /// Organization id the change is logged for
        /// </summary>
        public long OrganizationId { get; set; }
        /// <summary>
        /// Location id the change is logged for
        /// </summary>
        public long LocationId { get; set; }
        /// <summary>
        /// Entrance id the change is logged for
        /// </summary>
        public long EntranceId { get; set; }
        /// <summary>
        /// EntranceCounter id logging the change
        /// </summary>
        public long EntranceCounterId { get; set; }

        /// <summary>
        /// Number of people logged as changed. Positive for people entering, negative for people leaving
        /// </summary>
        public int LoggedChange { get; set; }

        /// <summary>
        /// Current occupancy after the change
        /// </summary>
        public int CurrentOccupancy { get; set; }

        /// <summary>
        /// Date change was logged
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
