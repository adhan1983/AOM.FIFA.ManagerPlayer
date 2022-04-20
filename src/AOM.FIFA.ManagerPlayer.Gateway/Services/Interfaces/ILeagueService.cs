using AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces
{
    public  interface ILeagueService
    {
        Task<LeagueListResponse> GetLeaguesAsync(LeagueRequest request);
    }
}
