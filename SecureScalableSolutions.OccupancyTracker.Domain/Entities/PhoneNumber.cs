using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{
    /// <summary>
    /// Standardized Phone Number 
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// Country code of the phone number
        /// </summary>
        public string? CountryCode { get; set; }

        /// <summary>
        /// Phone number
        /// </summary>
        public string? Number { get; set; }
    }
}
