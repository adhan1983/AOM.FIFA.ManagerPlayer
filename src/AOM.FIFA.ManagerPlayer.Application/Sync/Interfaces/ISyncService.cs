using AOM.FIFA.ManagerPlayer.Application.Sync.Responses;
using System.Threading.Tasks;
using s = AOM.FIFA.ManagerPlayer.Application.Sync.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces
{
    public interface ISyncService
    {
        Task<s.Sync> GetSyncByNameAsync(string name);

        Task<bool> UpdateAsync(s.Sync sync);

        Task<SyncResponse> SyncByNameAsync(string name);
    }
}
