using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureScalableSolutions.OccupancyTracker.Domain.Common;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{
    public class UserInformation : AuditableEntity
    {
        /// <summary>
        /// UserInformation public facing identifier
        /// </summary>
        public string UserInformationSqid { get; set; } = string.Empty;


        /// <summary>
        /// Email address of the user
        /// </summary>
        public string EmailAddress { get; set; } = string.Empty;

        /// <summary>
        /// First name of the user
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the user
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Address of the user
        /// </summary>
        public Address? Address { get; set; }

        /// <summary>
        /// Contact phone number of the user
        /// </summary>
        public PhoneNumber? ContactPhoneNumber { get; set; }

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
