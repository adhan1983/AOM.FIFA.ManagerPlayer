using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain = AOM.FIFA.ManagerPlayer.Application.Player.Entities;

namespace AOM.FIFA.ManagerPlayer.Persistence.Configuration
{
    public class PlayerConfiguration : IEntityTypeConfiguration<domain.Player>
    {
        public void Configure(EntityTypeBuilder<domain.Player> builder)
        {
            builder.
                ToTable(nameof(domain.Player)).
                HasKey(x => x.Id);
            builder.
                Property(x => x.Name).
                HasMaxLength(60);
            builder.
                Property(x => x.LastName).
                HasMaxLength(60);
            builder.
                Property(x => x.Age).
                IsRequired();
            builder.
                Property(x => x.CommonName).
                HasMaxLength(60);
            builder.
                Property(x => x.SourceId);
            builder.
                Property(x => x.Foot);
            builder.
                Property(x => x.ClubId);
            builder.
                Property(x => x.NationId).
                IsRequired();
            builder.
                Property(x => x.Height);
            builder.
                Property(x => x.Weight);
            builder.
                Property(x => x.Rarity);
            builder.
                Property(x => x.Position);
            builder.
                Property(x => x.Foot);
            builder.
               Property(x => x.AttackWorkRate);
            builder.
                Property(x => x.DefenseWorkRate);
            builder.
                Property(x => x.TotalStats);
            builder.
               Property(x => x.Rating);
            builder.
                Property(x => x.Pace);
            builder.
                Property(x => x.Shooting);
            builder.
               Property(x => x.Passing);
            builder.
                Property(x => x.Dribbling);
            builder.
                Property(x => x.Defending);
            builder.
                Property(x => x.Physicality);

        }
    }
}