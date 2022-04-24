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
                ToTable(nameof(League)).
                HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(60).IsRequired();
            
        }       
    }
}
