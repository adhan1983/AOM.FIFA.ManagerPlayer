using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Interfaces.Services
{
    public interface ISyncPlayerService
    {
        Task<SyncPage> SyncPlayerAsync(int totalItemsPerPage, SyncPage syncPage);
    }
}
