using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.League.Dtos;
using AOM.FIFA.ManagerPlayer.Application.League.Requests;
using AOM.FIFA.ManagerPlayer.Application.League.Responses;

namespace AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services
{
    public interface ILeagueService
    {
        Task<LeaguesResponse> GetLeaguesResponseAsync(LeagueParametersRequest leagueParameters);

        Task<LeagueDto> GetLeagueByIdAsync(int id);
    }
}
