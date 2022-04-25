using AOM.FIFA.ManagerPlayer.Gateway.Responses.Clubs;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces
{
    public interface IClubService
    {
        Task<ClubListResponse> GetClubsAsync(ClubRequest request);
    }
}
