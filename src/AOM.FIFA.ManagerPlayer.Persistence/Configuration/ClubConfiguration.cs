using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain = AOM.FIFA.ManagerPlayer.Application.Club.Entities;

namespace AOM.FIFA.ManagerPlayer.Persistence.Configuration
{


    public class ClubConfiguration : IEntityTypeConfiguration<domain.Club>
    {
        public void Configure(EntityTypeBuilder<domain.Club> builder)
        {
            builder.
                ToTable(nameof(domain.Club)).
                HasKey(x => x.Id);
            builder.
                Property(x => x.Name).
                HasMaxLength(60).
                IsRequired();
            builder.
                Property(x => x.SourceId);             
            builder.
                Property(x => x.LeagueId).                
                IsRequired();
            builder.
                HasMany(x=> x.Players).
                WithOne(x => x.Club).
                HasForeignKey(x => x.ClubId);

        }
    }
}
