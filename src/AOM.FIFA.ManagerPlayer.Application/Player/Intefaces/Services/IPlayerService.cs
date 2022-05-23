using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Player.Requests;
using AOM.FIFA.ManagerPlayer.Application.Player.Responses;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Services
{
    public interface IPlayerService
    {
        Task<PlayerResponse> GetPlayerByIdAsync(int id);

        Task<PlayerListResponse> GetPlayersAsync(PlayerParameterRequest request);

        Task<PlayerListResponse> GetPlayersByClubAsync(PlayerClubParameterRequest request);

        Task<int> InsertPlayerAsync(PlayerDto playerDto);

    }
}
