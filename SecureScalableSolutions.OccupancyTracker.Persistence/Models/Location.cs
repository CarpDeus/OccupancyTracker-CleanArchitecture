using Microsoft.EntityFrameworkCore;
using SecureScalableSolutions.OccupancyTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Persistence.Models
{
    /// <summary>
    /// Locations are the physical locations where occupancy is tracked
    /// </summary>
    [Index(nameof(LocationId), nameof(LocationName), IsUnique = true)]
    [Index(nameof(LocationSqid), IsUnique = true)]
    [Table("Locations")]
    public class Location : AuditableEntity
    {
        /// <summary>
        /// Primary key for the organization
        /// </summary>
        [Required]
        [Key]
        public long LocationId { get; set; }


        /// <summary>
        /// Public facing location identifier
        /// </summary>
        [StringLength(64)]
        public string? LocationSqid { get; set; }


        /// <summary>
        /// Human readable name of the location
        /// </summary>
        [StringLength(256)]
        public string LocationName { get; set; } = string.Empty;

        /// <summary>
        /// Description of the location
        /// </summary>
        [StringLength(1024)]
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
        /// Address line 1
        /// </summary>
        [StringLength(1024)]
        public string AddressLine1 { get; set; } = string.Empty;

        /// <summary>
        /// Address line 2
        /// </summary>
        [StringLength(1024)]
        public string? AddressLine2 { get; set; } = string.Empty;

        /// <summary>
        /// City of the address
        /// </summary>
        [StringLength(512)]
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// State of the address
        /// </summary>
        [StringLength(512)]
        public string State { get; set; } = string.Empty;

        /// <summary>
        /// Postal code of the address
        /// </summary>
        [StringLength(128)]
        public string PostalCode { get; set; } = string.Empty;

        /// <summary>
        /// Country of the address
        /// </summary>
        [StringLength(256)]
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// Phone number
        /// </summary>
        [StringLength(64)]
        public string? Number { get; set; }

      


        /// <summary>
        /// Status of the data
        /// </summary>
        public int CurrentStatus { get; set; } = 0;

        public Organization Organization { get; set; } = default!;

        public ICollection<Entrance>? Entrances { get; set; }
    }
}
