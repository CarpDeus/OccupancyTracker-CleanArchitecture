using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureScalableSolutions.OccupancyTracker.Domain.Common;
using SecureScalableSolutions.OccupancyTracker.Domain.Entities;

namespace SecureScalableSolutions.OccupancyTracker.Persistence.Models
{
    public class UserInformation : AuditableEntity
    {
        /// <summary>
        /// UserInformation public facing identifier
        /// </summary>
        [StringLength(64)] 
        public string UserInformationSqid { get; set; } = string.Empty;


        /// <summary>
        /// Email address of the user
        /// </summary>
        [StringLength(320)] 
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// First name of the user
        /// </summary>
        [StringLength(256)]
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the user
        /// </summary>
        [StringLength(256)]
        public string LastName { get; set; } = string.Empty;

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
        /// Indicates if the user is a super admin
        /// </summary>
        public bool IsSuperAdmin { get; set; } = false;

        /// <summary>
        /// Indicates if the user has completed registration
        /// </summary>
        public bool HasCompletedRegistration { get; set; } = false;

        /// <summary>
        /// Indicates if the user belongs to an organization
        /// </summary>
        public bool BelongsToOrganization { get; set; } = false;

        /// <summary>
        /// Status of the user
        /// </summary>
        public int CurrentStatusId { get; set; } = 0;


    }
}
