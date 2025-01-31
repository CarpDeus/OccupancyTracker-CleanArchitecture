﻿using Sqids;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using FluentValidation;
namespace OccupancyTracker.Models
{

    public class LocationOccupancyStats
    {
        public int MaxOccupancy { get; set; }
        public int CurrentOccupancy { get; set; }
        public int OccupancyThresholdWarning { get; set; }
    }

        public class LocationValidator : AbstractValidator<Location>
    {
        public LocationValidator()
        {
            RuleFor(x => x.LocationName).NotEmpty().MaximumLength(256).WithMessage("Location Name is required and must be less than 256 characters long.");
            RuleFor(x => x.LocationDescription).MaximumLength(1024).WithMessage("Location Description must be less than 1024 characters long.");
            RuleFor(x => x.MaxOccupancy).GreaterThan(0).WithMessage("Max Occupancy must be greater than 0");
            RuleFor(x => x.OccupancyThresholdWarning).LessThan(x => x.MaxOccupancy).WithMessage("Threshold must be less than Max Occupancy");
            RuleFor(x => x.LocationAddress).SetValidator(new AddressValidator());
            RuleFor(x => x.PhoneNumber).SetValidator(new PhoneNumberValidator());
            RuleFor(x => x.MaxOccupancy).GreaterThan(0).WithMessage("Max Occupancy must be greater than 0");
            RuleFor(x => x.OccupancyThresholdWarning).LessThan(x => x.MaxOccupancy).WithMessage("Threshold must be less than Max Occupancy").GreaterThan(0).WithMessage("Threshold must be greater than 0");
        }
        /// <summary>
        /// Validate a single property of the model
        /// </summary>
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<Location>.CreateWithOptions((Location)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return result.Errors.Select(e => e.ErrorMessage);
        };
    }

    /// <summary>
    /// Locations are the physical locations where occupancy is tracked
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Primary Key
        /// </summary>
        [Key]
        public long LocationId { get; set; }


        /// <summary>
        /// Human readable name of the location
        /// </summary>
        [Required]
        [StringLength(256)]
        public string LocationName { get; set; } = string.Empty;

        /// <summary>
        /// Description of the location
        /// </summary>
        public string LocationDescription { get; set; } = string.Empty;

        /// <summary>
        /// Maximum occupancy of the location
        /// </summary>
        [Required]
        
        public int MaxOccupancy { get; set; } = 1;

        /// <summary>
        /// Current occupancy. Generally set using the entrance counters
        /// </summary>
        [Required] public int CurrentOccupancy { get; set; } = 0;

        /// <summary>
        /// The point at which a location is close enough to full to trigger a warning
        /// </summary>
        [Required]
        [Compare("MaxOccupancy", ErrorMessage = "Threshold must be less than Max Occupancy")]
        public int OccupancyThresholdWarning { get; set; } = 0;

        /// <summary>
        /// The address of the location
        /// </summary>
        public Address LocationAddress { get; set; }

        /// <summary>
        /// Contact phone number for the location
        /// </summary>
        public PhoneNumber PhoneNumber { get; set; }

        /// <summary>
        /// Status of the data
        /// </summary>
        public int CurrentStatus { get; set; } = 0;

        /// <summary>
        /// Date the data was created
        /// </summary>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Date the data was last modified. If null, not changed since creationg
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// UserInformationSqid of the user who created the data
        /// </summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>
        /// UserInformationSqid of the user who last modified
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// Human readable status of the data
        /// </summary>
        public string CurrentStatusDescription { get { return Statuses.DataStatus.FromId(this.CurrentStatus).Name; } }

        /// <summary>
        /// Public facing location identifier
        /// </summary>
        public string? LocationSqid { get; set; }

        
        /// <summary>
        /// OrganizationId the location belongs to
        /// </summary>
        public long OrganizationId { get; set; } 

        /// <summary>
        /// The number of entrances associated with the location
        /// </summary>
        public int EntranceCount { get; set; } = 0;

        /// <summary>
        /// Constructor for blank new locatino
        /// </summary>
        public Location()
        {
            this.LocationAddress = new Address();
            this.PhoneNumber = new PhoneNumber();
        }

      

        /// <summary>
        /// Used for determinig if a location should be displayed based on a filter
        /// </summary>
        /// <param name="filter">search string. if not provided, location will be displayed</param>
        /// <returns>True if match, False if not</returns>
        public bool FilterCriteria(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return true;
            }
            return Utility.FilterCriteria(this.LocationName, filter) ||
             Utility.FilterCriteria(this.LocationDescription, filter)  ||
                this.LocationAddress.FilterCriteria(filter) ||
                this.PhoneNumber.FilterCriteria(filter);
        }

    }
}
