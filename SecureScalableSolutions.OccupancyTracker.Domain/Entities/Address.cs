using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Domain.Entities
{
    /// <summary>
    /// Standardized Address class 
    /// </summary>
    public class Address
    {

        /// <summary>
        /// Address line 1
        /// </summary>
        public string? AddressLine1 { get; set; } = string.Empty;

        /// <summary>
        /// Address line 2
        /// </summary>
        public string? AddressLine2 { get; set; } = string.Empty;

        /// <summary>
        /// City of the address
        /// </summary>
        public string? City { get; set; } = string.Empty;

        /// <summary>
        /// State of the address
        /// </summary>
        public string? State { get; set; } = string.Empty;

        /// <summary>
        /// Postal code of the address
        /// </summary>
        public string? PostalCode { get; set; } = string.Empty;

        /// <summary>
        /// Country of the address
        /// </summary>
        public string? Country { get; set; } = string.Empty;

    }
}
