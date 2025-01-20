using SecureScalableSolutions.OccupancyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence
{
    public interface IOrganizationRepository: IAsyncRepository<Organization>
    {
        Task<bool> IsOrganizationNameUnique(string name, string? organizationSqid=null);
    }
}
