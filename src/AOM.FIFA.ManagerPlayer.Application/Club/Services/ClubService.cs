using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Club.Responses;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Services
{
    public class ClubService : IClubeService
    {
        private readonly IClubRepository _clubRepository;

        public ClubService(IClubRepository clubRepository) => this._clubRepository = clubRepository;

        public async Task<ClubDto> GetClubByIdAsync(int id)
        {
            var club = await _clubRepository.GetByIdAsync(id);

            return new ClubDto
            {
                Id = club.Id,
                Name = club.Name,
                LeagueId = club.LeagueId,
            };

        }

        public async Task<ClubResponse> GetLeaguesResponseAsync()
        {
            var leagues = await _clubRepository.GetAllAsync();

            return new ClubResponse
            {
                Total = leagues.Count,
                Clubs = leagues.Select(model => new ClubDto { Id = model.Id, Name = model.Name }).ToList()
            };
        }

    }
}
