using SecureScalableSolutions.OccupancyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.EntranceCounter.Persistence.Models
{
    public class OccupancyLogPersist : OccupanyLog
    {
        public string Id { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssK");
    }
}
