using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Configuration
{
    public class SyncPageConfiguration : IEntityTypeConfiguration<SyncPage>
    {
        public void Configure(EntityTypeBuilder<SyncPage> builder)
        {
            builder.
               ToTable(nameof(SyncPage)).
               HasKey(x => x.Id);
            builder.
                Property(x => x.Page).                
                IsRequired();
            builder.
                Property(x => x.TotalSynchronized).
                IsRequired();
            builder.
                Property(x => x.TotalDosNotSynchronized).
                IsRequired();
            builder.
                Property(x => x.SyncPageSuccess).
                IsRequired();
            builder.
                HasMany(x => x.SourcesWithoutSync).
                WithOne(x => x.SyncPage).
                HasForeignKey(x => x.SyncPageId);
        }
    }
}
