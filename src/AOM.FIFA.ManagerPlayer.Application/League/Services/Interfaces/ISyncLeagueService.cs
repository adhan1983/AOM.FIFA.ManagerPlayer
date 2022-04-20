using AOM.FIFA.ManagerPlayer.Application.League.Responses;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.League.Services.Interfaces
{
    public interface ISyncLeagueService
    {
        Task<SyncResponseLeague> SyncLeaguesAsync();
    }
}
