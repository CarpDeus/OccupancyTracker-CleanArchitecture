using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Common
{
    public  class AuditableEntity
    {
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

    }
}
