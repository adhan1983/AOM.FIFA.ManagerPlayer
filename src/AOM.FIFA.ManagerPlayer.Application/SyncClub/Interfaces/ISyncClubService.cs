using AOM.FIFA.ManagerPlayer.Application.SyncClub.Responses;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces
{
    public interface ISyncClubService
    {
        Task<SyncClubResponse> SyncClubsAsync();
    }
}
