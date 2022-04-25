using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Club.Responses;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services
{
    public interface IClubService
    {
        Task<ClubDto> GetClubByIdAsync(int id);

        Task<ClubResponse> GetClubsResponseAsync();

        Task<ClubLeagueResponse> GetClubsByLeagueIdAsync(int leagueId);
    }
}
