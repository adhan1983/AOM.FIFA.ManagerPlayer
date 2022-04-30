using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Base;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Context;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Synchronization.Repository
{
    public class SourceWithoutSyncRepository : BaseSynchronizationRepository<SourceWithoutSync>, ISourceWithoutSyncRepository
    {
        public SourceWithoutSyncRepository(FIFASynchronizationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
