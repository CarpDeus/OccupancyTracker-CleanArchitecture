using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Models.Statuses
{
    public record DataStatus(int Id, string Name, string Description)
    {
        public static DataStatus Active { get; } = new DataStatus(0, "Active", "Available");
        public static DataStatus Deleted { get; } = new DataStatus(1, "Deleted", "Only shows up to Administrators");
        public static DataStatus PermanentlyDeleted { get; } = new DataStatus(2, "Permanently Deleted", "Permanently Deleted - Not available except to Super Admins");

        public static DataStatus FromId(int id)
        {
            return id switch
            {
                0 => Active,
                1 => Deleted,
                2 => PermanentlyDeleted,
                _ => throw new ArgumentOutOfRangeException(nameof(id), id, "Invalid status id")
            };
        }



        public static bool ValidChangeStates(int fromStatusId, int toStatusId)
        {
            return (fromStatusId==0 && toStatusId == 1) // Active to Deleted
                || (fromStatusId == 1 && (toStatusId == 0 || toStatusId == 2)) // Deleted to Active or Permanently Deleted
                || (fromStatusId == 2 && toStatusId == 1); // Permanently Deleted to Deleted
        }
    }
}
