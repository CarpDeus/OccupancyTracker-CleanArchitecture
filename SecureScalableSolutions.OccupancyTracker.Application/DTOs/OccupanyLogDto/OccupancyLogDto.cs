using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.DTOs.OccupanyLogDto
{
    public class OccupancyLogDto
    {
        private Guid _id = Guid.NewGuid();
        private DateTime _dateLogged = DateTime.UtcNow;


        public string Id { get => _id.ToString(); }
        public DateTime DateLogged { get => _dateLogged; }

        /// <summary>
        /// Organization id the change is logged for
        /// </summary>
        public string OrganizationSqid { get; set; }
        /// <summary>
        /// Location id the change is logged for
        /// </summary>
        public string LocationSqid { get; set; }
        /// <summary>
        /// Entrance id the change is logged for
        /// </summary>
        public string EntranceSqid { get; set; }
        /// <summary>
        /// EntranceCounter id logging the change
        /// </summary>
        public string EntranceCounterSqid { get; set; }

        /// <summary>
        /// Number of people logged as changed. Positive for people entering, negative for people leaving
        /// </summary>
        public int LoggedChange { get; set; }
    }
}
