using AOM.FIFA.ManagerPlayer.Application.Synchronization.Entities;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Base;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Context;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Synchronization.Repository
{
    public class SyncRepository : BaseSynchronizationRepository<Sync>, ISyncRepository
    {
        public SyncRepository(FIFASynchronizationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
