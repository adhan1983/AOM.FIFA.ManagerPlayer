using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces.Services
{
    public interface ISyncClubService
    {
        Task<SyncPage> SyncClubsAsync(int totalItemPerPage, SyncPage syncPage);
    }
}
