using AOM.FIFA.ManagerPlayer.Application.Sync.Responses;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces
{
    public interface ISyncService
    {       
        Task<SyncResponse> SyncByNameAsync(string name);
    }
}
