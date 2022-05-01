using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.SyncNation.Interfaces
{
    public interface ISyncNationService
    {
        Task<SyncPage> SyncNationAsync(int totalItemsPerPage, SyncPage syncPage);
    }
}
