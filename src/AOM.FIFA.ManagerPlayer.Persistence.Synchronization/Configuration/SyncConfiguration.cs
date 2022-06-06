using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

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

            builder.HasData(new List<Sync>() 
            {
                new Sync { Id = 1,  Name = "League", TotalItems = 49, TotalPages = 3, TotalItemsPerPage = 20, Synchronized = false },
                new Sync { Id = 2,  Name = "Club", TotalItems = 674, TotalPages = 34, TotalItemsPerPage = 20, Synchronized = false },
                new Sync { Id = 3,  Name = "Player", TotalItems = 20617, TotalPages = 1031, TotalItemsPerPage = 20, Synchronized = false },
                new Sync { Id = 4,  Name = "Nation", TotalItems = 160, TotalPages = 8, TotalItemsPerPage = 20, Synchronized = false },
            });
        }
    }
}
