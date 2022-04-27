using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Clubs;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Player;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces
{
    public interface IHttpClientFactoryService
    {
        Task<LeagueListResponse> GetLeaguesAsync(Request request);

        Task<ClubListResponse> GetClubsAsync(Request request);

        Task<PlayerListResponse> GetPlayersAsync(Request request);
    }
}
