using Microsoft.EntityFrameworkCore;
using AOM.FIFA.ManagerPlayer.Persistence.Configuration;
using domain = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Persistence.Context
{
    public class FIFAManagerPlayerDbContext : DbContext
    {
        public FIFAManagerPlayerDbContext(DbContextOptions<FIFAManagerPlayerDbContext> options) : base(options)
        {

        }

        public DbSet<domain.League> Leagues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
        }

    }

}
