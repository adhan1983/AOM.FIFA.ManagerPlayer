using AOM.FIFA.ManagerPlayer.Application.Synchronization.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Configuration
{
    public class SyncConfiguration : IEntityTypeConfiguration<Sync>
    {
        public void Configure(EntityTypeBuilder<Sync> builder)
        {
            builder.
               ToTable(nameof(Sync)).
               HasKey(x => x.Id);
            builder.
                Property(x => x.Name).
                HasMaxLength(60).
                IsRequired();
            builder.
                Property(x => x.TotalPages).
                IsRequired();
            builder.
                Property(x => x.TotalItems).
                IsRequired();
            builder.
                Property(x => x.TotalItemsPerPage).
                IsRequired();            
            builder.
                HasMany(x => x.SyncPages).
                WithOne(x => x.Sync).
                HasForeignKey(x => x.SyncId);
        }
    }
}
