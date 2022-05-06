using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Sync.Responses;
using s = AOM.FIFA.ManagerPlayer.Application.Sync.Entities;


namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces
{
    public interface ISyncService
    {       
        Task<SyncResponse> SyncByNameAsync(s.Sync sync);

        Task PublishingFifaJobs();
    }
}
