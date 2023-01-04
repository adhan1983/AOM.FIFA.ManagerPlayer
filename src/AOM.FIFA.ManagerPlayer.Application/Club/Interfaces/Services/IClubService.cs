using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Base.Response;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Club.Responses;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services
{
    public interface IClubService
    {
        Task<ClubDto> GetClubByIdAsync(int id);

        Task<ClubResponse> GetClubsResponseAsync();

        Task<ClubLeagueResponse> GetClubsByLeagueIdAsync(int leagueId);

        Task<FIFAManagerResponse> InsertClubAsync(ClubDto clubDto);

        Task<ClubDto> GetClubBySourceId(int sourceId);        
    }
}
