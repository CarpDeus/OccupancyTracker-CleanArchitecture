using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;
using SecureScalableSolutions.OccupancyTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureScalableSolutions.OccupancyTracker.EntranceCounter.Persistence.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        public Task<Organization> AddAsync(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task ChangeStatusAsync(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsOrganizationNameUnique(string name, string? organizationSqid = null)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Organization>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Organization entity)
        {
            throw new NotImplementedException();
        }
    }
}
