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
    [Index(nameof(EntranceCounterSqid), IsUnique = true)]
    [Table("EntranceCounters")]
    public class EntranceCounter : AuditableEntity
    {

        /// <summary>
        /// Public facing id for the entrance counter
        /// </summary>
        [StringLength(64)]
        public string EntranceCounterSqid { get; set; } = string.Empty;

        /// <summary>
        /// EntranceId this counter is associated with
        /// </summary>
        public Entrance Entrance { get; set; } = default!;

        /// <summary>
        /// LocationId this counter is associated with
        /// </summary>
        public Location Location { get; set; } = default!;

        /// <summary>
        /// OrganizationId this counter is associated with
        /// </summary>
        public Organization Organization { get; set; } = default!;

        /// <summary>
        /// Does this entrance counter require authentication. If true then the user attempting use the counter must be authenticated and authorized to the location
        /// </summary>
        public bool RequiresAuthentication { get; set; } = false;


        /// <summary>
        /// Status of the data
        /// </summary>
        public int CurrentStatus { get; set; } = 0;
    }
}
