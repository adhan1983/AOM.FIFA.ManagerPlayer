using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Base;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Synchronization.Repository
{
    public class SyncRepository : BaseSynchronizationRepository<Sync>, ISyncRepository
    {
        public SyncRepository(FIFASynchronizationDbContext dbContext) : base(dbContext) { }

        public async Task<Sync> GetSyncByNameAsync(string name)
        {
            var model = await this._fifaSynchronizationDbContext.
                                Sync.
                                    Include(a => a.SyncPages).
                                    ThenInclude(b => b.SourcesWithoutSync).
                                FirstOrDefaultAsync(a => a.Name == name);

            return model;
        }

        public async Task<bool> UpdateSyncWithSyncPages(Sync sync) 
        {
            await this._fifaSynchronizationDbContext.SyncPage.AddRangeAsync(sync.SyncPages);

            await this._fifaSynchronizationDbContext.SourceWithoutSync.AddRangeAsync(sync.SyncPages.FirstOrDefault().SourcesWithoutSync);

            var upDated =  Convert.ToBoolean(await this._fifaSynchronizationDbContext.SaveChangesAsync());

            return upDated;

        }
    }
}
