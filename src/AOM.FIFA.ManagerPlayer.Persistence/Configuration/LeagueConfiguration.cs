using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Persistence.Configuration
{
    public class LeagueConfiguration : IEntityTypeConfiguration<domain.League>
    {
        public void Configure(EntityTypeBuilder<domain.League> builder)
        {
            builder.
                ToTable(nameof(domain.League)).
                HasKey(x => x.Id);
            builder.
                Property(x => x.Name).
                HasMaxLength(60).
                IsRequired();
            builder.
                Property(x => x.SourceId).
                IsRequired();
            builder.
                HasMany(x => x.Clubs).
                WithOne(x => x.League).
                HasForeignKey(x => x.LeagueId);            
        }       
    }
}
