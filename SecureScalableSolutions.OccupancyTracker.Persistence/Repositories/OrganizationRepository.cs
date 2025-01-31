using SecureScalableSolutions.OccupancyTracker.Domain.Entities;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts.Persistence;

namespace SecureScalableSolutions.OccupancyTracker.Persistence.Repositories
{
    public class OrganizationRepository : BaseRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(OccupancyDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsOrganizationNameUnique(string name, string? organizationSqid = null)
        {
            var matches = _dbContext.Organizations.Any(e => e.OrganizationName == name && e.OrganizationSqid != organizationSqid);
            return Task.FromResult(!matches);
        }
    }
}
