using SecureScalableSolutions.OccupancyTracker.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{
    [Index(nameof(OrganizationName), IsUnique = true)]
    [Index(nameof(OrganizationSqid), IsUnique = true)]
    [Table("Organizations")]
    public class Organization 
    {

        /// <summary>
        /// Primary key for the organization
        /// </summary>
        [Required]
        [Key]
        public Int64 OrganizationId { get; set; }

        /// <summary>
        /// Publicly accessible Id for the organization
        /// </summary>
        [StringLength(64)]
        public string? OrganizationSqid { get; set; }

        /// <summary>
        /// Human readable organization name
        /// </summary>
        [StringLength(256)] 
        public string OrganizationName { get; set; } = string.Empty;

        /// <summary>
        /// Description of the organization
        /// </summary>
        [StringLength(1024)] 
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
        /// Country code of the phone number
        /// </summary>
        [StringLength(256)] 
        public string? CountryCode { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        [StringLength(64)]
        public string? Number { get; set; }

        /// <summary>
        /// Status of the data
        /// </summary>
        public int CurrentStatus { get; set; } = 0;

        /// <summary>
        /// List of locations for the organization
        /// </summary>
        public ICollection<Location>? Locations { get; set; }


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
        [StringLength(64)]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// UserInformationSqid of the user who last modified the data
        /// </summary>
        [StringLength(64)]
        public string? ModifiedBy { get; set; }

    }
}
