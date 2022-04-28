using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Entities;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Configuration
{
    public class SourceWithoutSyncConfiguration : IEntityTypeConfiguration<SourceWithoutSync>
    {
        public void Configure(EntityTypeBuilder<SourceWithoutSync> builder)
        {
            builder.
               ToTable(nameof(SourceWithoutSync)).
               HasKey(x => x.Id);
            builder.
                Property(x => x.SourceId).
                IsRequired();
            builder.
                Property(x => x.SyncPageId).
                IsRequired();            
        }
    }
}
