using System.Threading.Tasks;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories
{
    public interface ISyncPageRepository : IBaseSynchronizationRepository<SyncPage>
    {
        Task<List<SyncPage>> GetSyncPagesBySyncId(int syncId);
    }
}
