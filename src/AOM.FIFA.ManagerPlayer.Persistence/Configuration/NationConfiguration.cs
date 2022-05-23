using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain = AOM.FIFA.ManagerPlayer.Application.Nation.Entities;

namespace AOM.FIFA.ManagerPlayer.Persistence.Configuration
{
    public class NationConfiguration : IEntityTypeConfiguration<domain.Nation>
    {
        public void Configure(EntityTypeBuilder<domain.Nation> builder)
        {
            builder.
                ToTable(nameof(domain.Nation)).
                HasKey(x => x.Id);
            builder.
                Property(x => x.Name).
                HasMaxLength(60).
                IsRequired();
            builder.
                Property(x => x.SourceId).
                IsRequired();
        }       
    }
}
