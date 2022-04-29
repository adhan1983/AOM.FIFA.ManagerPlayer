using AOM.FIFA.ManagerPlayer.Application.Synchronization.Entities;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Base;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Synchronization.Repository
{
    public class SyncPageRepository : BaseSynchronizationRepository<SyncPage>, ISyncPageRepository
    {
        public SyncPageRepository(FIFASynchronizationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<SyncPage>> GetSyncPagesBySyncId(int syncId)
        {
            var lst = await this._fifaSynchronizationDbContext.
                            SyncPage.
                            Where(a => a.SyncId == syncId).
                            ToListAsync();

            return lst;

        }
    }
}
