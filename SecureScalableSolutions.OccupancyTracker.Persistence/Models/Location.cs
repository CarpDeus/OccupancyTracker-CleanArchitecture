using Microsoft.EntityFrameworkCore;
using SecureScalableSolutions.OccupancyTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{
    /// <summary>
    /// Locations are the physical locations where occupancy is tracked
    /// </summary>
    [Index(nameof(LocationId), nameof(LocationName), IsUnique = true)]
    [Index(nameof(LocationSqid), IsUnique = true)]
    [Table("Locations")]
    public class Location 
    {
        /// <summary>
        /// Primary key for the organization
        /// </summary>
        [Required]
        [Key]
        public Int64 LocationId { get; set; }


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
        /// Date the entrance data was created
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Date the entrance data was last modified
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// UserInformationSqid of the user who created the entrance
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// UserInformationSqid of the user who last modified the data
        /// </summary>
        public string? ModifiedBy { get; set; }


        /// <summary>
        /// Status of the data
        /// </summary>
        public int CurrentStatus { get; set; } = 0;

        public Organization Organization { get; set; } = default!;

        public ICollection<Entrance>? Entrances { get; set; }
    }
}
