using AOM.FIFA.ManagerPlayer.Application.League.Dtos;
using AOM.FIFA.ManagerPlayer.Application.League.Responses;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services
{
    public interface ILeagueService
    {
        Task<LeaguesResponse> GetLeaguesResponseAsync();

        Task<LeagueDto> GetLeagueByIdAsync(int id);
    }
}
