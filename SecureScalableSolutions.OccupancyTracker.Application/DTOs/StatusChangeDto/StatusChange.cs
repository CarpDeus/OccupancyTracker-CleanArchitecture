using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.DTOs.StatusChangeDto
{
    public class StatusChangeCommand
    {
        public int CurrentStatus { get; set; }
        public int NewStatus { get; set; }
    }
}
