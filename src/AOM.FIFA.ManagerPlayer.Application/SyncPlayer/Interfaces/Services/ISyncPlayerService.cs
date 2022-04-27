using AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Responses;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Interfaces.Services
{
    public interface ISyncPlayerService
    {
        Task<SyncPlayerResponse> SyncPlayerAsync(); 
    }
}
