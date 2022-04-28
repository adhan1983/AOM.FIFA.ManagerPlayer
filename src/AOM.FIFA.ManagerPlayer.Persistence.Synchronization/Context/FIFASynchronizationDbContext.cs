using Microsoft.EntityFrameworkCore;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Entities;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Configuration;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Context
{
    public class FIFASynchronizationDbContext : DbContext
    {
        public FIFASynchronizationDbContext(DbContextOptions<FIFASynchronizationDbContext> options) : base(options)
        {

        }

        public DbSet<Sync> Sync { get; set; }

        public DbSet<SyncPage> SyncPage { get; set; }

        public DbSet<SourceWithoutSync> SourceWithoutSync { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new SyncConfiguration());
            //modelBuilder.ApplyConfiguration(new SyncPageConfiguration());
            //modelBuilder.ApplyConfiguration(new SourceWithoutConfiguration());
        }
    }
}
