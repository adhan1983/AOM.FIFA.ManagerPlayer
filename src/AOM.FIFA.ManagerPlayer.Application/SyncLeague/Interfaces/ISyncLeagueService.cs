using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Responses;

namespace AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces
{
    public interface ISyncLeagueService
    {
        Task<SyncLeagueResponse> SyncLeaguesAsync();
    }
}
