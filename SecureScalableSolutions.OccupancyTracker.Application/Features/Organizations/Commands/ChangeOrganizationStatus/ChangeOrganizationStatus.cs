using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.Organizations.Commands.ChangeOrganizationStatus
{
    public class ChangeOrganizationStatusCommand : IRequest<bool>
    {
        /// <summary>
        /// Id of the organzation that will have the status changed
        /// </summary>
        public string OrganizationSqid { get; set; }

        /// <summary>
        /// New status of the organzation if change is successful
        /// </summary>
        public int NewStatus { get; set; }
    }
}
