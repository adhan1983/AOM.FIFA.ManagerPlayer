using AOM.FIFA.ManagerPlayer.Application.League.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using model = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Persistence.Configuration
{
    public class LeagueConfiguration : IEntityTypeConfiguration<model.League>
    {
        public void Configure(EntityTypeBuilder<League> builder)
        {
            builder.
                ToTable(nameof(League)).
                HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(60).IsRequired();

            
        }
    }
}
