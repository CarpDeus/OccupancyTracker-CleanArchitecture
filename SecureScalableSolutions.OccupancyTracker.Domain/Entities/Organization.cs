using SecureScalableSolutions.OccupancyTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{
    public class Organization : AuditableEntity
    {
        /// <summary>
        /// Publicly accessible Id for the organization
        /// </summary>
        public string? OrganizationSqid { get; set; }

        /// <summary>
        /// Human readable organization name
        /// </summary>
        public string OrganizationName { get; set; } = string.Empty;

        /// <summary>
        /// Description of the organization
        /// </summary>
        public string OrganizationDescription { get; set; } = string.Empty;

        /// <summary>
        /// Can the organization used certain paid features
        /// </summary>
        public bool PaidClient { get; set; } = false;

        /// <summary>
        /// When the organization's paid status is valid until
        /// </summary>
        public DateOnly? PaidThroughDate { get; set; }

        /// <summary>
        /// Address of the organization
        /// </summary>
        public Address? MailingAddress { get; set; }
        
        public PhoneNumber? ContactPhoneNumber { get; set; }

        /// <summary>
        /// Status of the data
        /// </summary>
        public int CurrentStatus { get; set; } = 0;

        /// <summary>
        /// List of locations for the organization
        /// </summary>
        public ICollection<Location>? Locations { get; set; } 

    }
}
