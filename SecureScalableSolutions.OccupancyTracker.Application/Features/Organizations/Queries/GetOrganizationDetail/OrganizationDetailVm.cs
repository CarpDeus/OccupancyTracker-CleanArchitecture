using SecureScalableSolutions.OccupancyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Queries.GetOrganizationDetail
{
    public class OrganizationDetailVm
    {
        /// <summary>
        /// Unique identifier for the organization
        /// </summary>
        public string OrganizationSqid { get; set; } = string.Empty;

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
        public Address? Address { get; set; }

        /// <summary>
        /// Phone number of the organization
        /// </summary>
        public PhoneNumber? PhoneNumber { get; set; }

        /// <summary>
        /// Status of the data
        /// </summary>
        public int CurrentStatus { get; set; } = 0;

        public string CurrentStatusDescription { get { return Models.Statuses.DataStatus.FromId(this.CurrentStatus).Name; } }
    }
}
