using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Contracts
{
    public interface ILoggedInUserService
    {
        public string UserSqid { get; }
    }
}
