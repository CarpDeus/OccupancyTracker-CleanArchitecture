using Microsoft.EntityFrameworkCore;
using SecureScalableSolutions.OccupancyTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Persistence.Models
{

    /// <summary>
    /// Entrance is a point of entry to a location
    /// </summary>
    [Index(nameof(EntranceId), nameof(EntranceName), IsUnique = true)]
    [Index(nameof(EntranceSqid), IsUnique = true)]
    [Table("Entrances")]
    public class Entrance : AuditableEntity
    {
        /// <summary>
        /// Primary key for the organization
        /// </summary>
        [Required]
        [Key]
        public long EntranceId { get; set; }

        /// <summary>
        /// Human Readable Name
        /// </summary>
        [StringLength(256)]
        public string EntranceName { get; set; } = string.Empty;

        /// <summary>
        /// Description of the entrance
        /// </summary>
        [StringLength(1024)]
        public string EntranceDescription { get; set; } = string.Empty;

        /// <summary>
        /// Public facing entrance identifier
        /// </summary>
        [StringLength(64)]
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
