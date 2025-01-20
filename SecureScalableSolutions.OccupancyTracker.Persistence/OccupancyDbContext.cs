using Microsoft.EntityFrameworkCore;
using SecureScalableSolutions.OccupancyTracker.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureScalableSolutions.OccupancyTracker.Persistence.Models;
using SecureScalableSolutions.OccupancyTracker.Domain.Common;

namespace SecureScalableSolutions.OccupancyTracker.Persistence
{
    public class OccupancyDbContext : DbContext
    {
        private readonly ILoggedInUserService _loggedInUserService;

        public OccupancyDbContext(DbContextOptions<OccupancyDbContext> options, ILoggedInUserService loggedInUserService) : base(options)
        {
            _loggedInUserService = loggedInUserService;
        }

        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<EntranceCounter> EntranceCounters { get; set; }
    
     // Define the model.
        // modelBuilder: The ModelBuilder.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // SQID Fields need to be case sensitive
            modelBuilder.Entity<Location>().Property(c => c.LocationSqid).UseCollation("SQL_Latin1_General_CP1_CS_AS");
            modelBuilder.Entity<Organization>().Property(c => c.OrganizationSqid).UseCollation("SQL_Latin1_General_CP1_CS_AS");
            modelBuilder.Entity<Entrance>().Property(c => c.EntranceSqid).UseCollation("SQL_Latin1_General_CP1_CS_AS");
            modelBuilder.Entity<Entrance>().Property(c => c.EntranceCounter).UseCollation("SQL_Latin1_General_CP1_CS_AS");
            modelBuilder.Entity<EntranceCounter>().Property(c => c.EntranceCounterSqid).UseCollation("SQL_Latin1_General_CP1_CS_AS");
            modelBuilder.Entity<UserInformation>().Property(c => c.UserInformationSqid).UseCollation("SQL_Latin1_General_CP1_CS_AS");



            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = _loggedInUserService.UserSqid;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        entry.Entity.ModifiedBy = _loggedInUserService.UserSqid;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}