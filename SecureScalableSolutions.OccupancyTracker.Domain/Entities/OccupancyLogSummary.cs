﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{
    public class OccupancyLogSummary
    {
        /// <summary>
        /// Organization id 
        /// </summary>
        public long OrganizationId { get; set; }

        /// <summary>
        /// Location id
        /// </summary>
        public long LocationId { get; set; }

        /// <summary>
        /// Entrance id
        /// </summary>
        public long EntranceId { get; set; }

        /// <summary>
        /// Year the changes cover
        /// </summary>
        public int LoggedYear { get; set; }

        /// <summary>
        /// Month the changes cover
        /// </summary>
        public int LoggedMonth { get; set; }

        /// <summary>
        /// Day the changes cover
        /// </summary>
        public int LoggedDay { get; set; }

        /// <summary>
        /// Hour the changes cover
        /// </summary>
        public int LoggedHour { get; set; }

        /// <summary>
        /// Minute the changes cover
        /// </summary>
        public int LoggedMinute { get; set; }

        /// <summary>
        /// How many people entered the location
        /// </summary>
        public int EnteredLocation { get; set; }

        /// <summary>
        /// How many people exited the location
        /// </summary>
        public int ExitedLocation { get; set; }

        /// <summary>
        /// What was the minimum occupancy during the period
        /// </summary>
        public int MinOccupancy { get; set; }

        /// <summary>
        /// What was the maximum occupancy during the period
        /// </summary>
        public int MaxOccupancy { get; set; }
    }
}
