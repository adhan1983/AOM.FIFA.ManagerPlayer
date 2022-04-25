using Microsoft.EntityFrameworkCore;
using AOM.FIFA.ManagerPlayer.Persistence.Configuration;
using domainClub = AOM.FIFA.ManagerPlayer.Application.Club.Entities;
using domainLeague = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Persistence.Context
{
    public class FIFAManagerPlayerDbContext : DbContext
    {
        public FIFAManagerPlayerDbContext(DbContextOptions<FIFAManagerPlayerDbContext> options) : base(options)
        {

        }

        public DbSet<domainLeague.League> Leagues { get; set; }

        public DbSet<domainClub.Club> Clubs { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfiguration(new LeagueConfiguration());
            modelBuilder.ApplyConfiguration(new ClubConfiguration());
        }

    }

}
