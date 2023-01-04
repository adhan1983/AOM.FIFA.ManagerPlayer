using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Base.Response;
using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Player.Requests;
using AOM.FIFA.ManagerPlayer.Application.Player.Responses;
using AOM.FIFA.ManagerPlayer.Application.Player.Services;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Services
{
    public interface IPlayerService
    {
        Task<PlayerResponse> GetPlayerByIdAsync(int id);

        Task<PlayerListResponse> GetPlayersAsync(PlayerParameterRequest request);

        Task<PlayerListResponse> GetPlayersByClubAsync(PlayerClubParameterRequest request);

        Task<PlayerListFUT22ICONResponse> GetPlayerByFUT22ICONSAsync();

        Task<FIFAManagerResponse> InsertPlayerAsync(PlayerDto playerDto);

        Task<PlayerByNationByLeagueResponse> GetPlayersByNationByLeague(int nation, int league);

        Task<TotalPlayersByLeagueByNationResponse> GetTotalNationalityPlayerByNation();

    }
}
