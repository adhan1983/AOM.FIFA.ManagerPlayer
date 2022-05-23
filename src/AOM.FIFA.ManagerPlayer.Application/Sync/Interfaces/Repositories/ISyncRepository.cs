using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using s = AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories
{
    public interface ISyncRepository : IBaseSynchronizationRepository<s.Sync>    
    {
        Task<s.Sync> GetSyncByNameAsync(string name);

        Task<List<s.Sync>> GetJobsAsync();
    }
}
