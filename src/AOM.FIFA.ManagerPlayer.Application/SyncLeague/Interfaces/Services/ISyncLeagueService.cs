using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces
{
    public interface ISyncLeagueService
    {
        Task<SyncPage> SyncLeaguesAsync(int totalItemsPerPage, SyncPage syncPage);
    }
}
