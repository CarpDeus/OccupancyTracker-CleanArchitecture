using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Features.OccupancyLog.Commands.CreateOccupancyLog
{
    public class CreateOccupancyLogCommand : IRequest<CreateOccupancyLogCommandResponse>
    {
        /// <summary>
        /// Organization id the change is logged for
        /// </summary>
        [Required]
        public string OrganizationSqid { get; set; }
        /// <summary>
        /// Location id the change is logged for
        /// </summary>
        [Required]
        public string LocationSqid { get; set; }
        /// <summary>
        /// Entrance id the change is logged for
        /// </summary>
        [Required]
        public string EntranceSqid { get; set; }
        /// <summary>
        /// EntranceCounter id logging the change
        /// </summary>
        [Required]
        public string EntranceCounterSqid { get; set; }

        /// <summary>
        /// Number of people logged as changed. Positive for people entering, negative for people leaving
        /// </summary>
        public int LoggedChange { get; set; }

    }
}
