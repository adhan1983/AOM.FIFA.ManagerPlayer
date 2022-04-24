using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Club.Responses;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services
{
    public interface IClubeService
    {
        Task<ClubDto> GetClubByIdAsync(int id);

        Task<ClubResponse> GetLeaguesResponseAsync();
    }
}
