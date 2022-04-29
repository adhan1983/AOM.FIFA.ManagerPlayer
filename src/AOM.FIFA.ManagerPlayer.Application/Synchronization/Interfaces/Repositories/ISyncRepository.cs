using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Entities;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories
{
    public interface ISyncRepository : IBaseSynchronizationRepository<Sync>    
    {
        Task<Sync> GetSyncByNameAsync(string name);
    }
}
