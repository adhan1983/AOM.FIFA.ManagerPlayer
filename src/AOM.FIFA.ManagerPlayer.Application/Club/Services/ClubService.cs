using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Club.Responses;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Services
{
    public class ClubService : IClubService
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

        public async Task<ClubResponse> GetClubsResponseAsync()
        {
            var clubs = await _clubRepository.GetAllAsync();

            return new ClubResponse
            {
                Total = clubs.Count,
                Clubs = clubs.Select(model => new ClubDto { Id = model.Id, Name = model.Name, LeagueId = model.LeagueId }).ToList()
            };

        }

        public async Task<ClubLeagueResponse> GetClubsByLeagueIdAsync(int leagueId)
        {
            var clubs = await _clubRepository.GetClubsByLeagueIdAsync(leagueId);

            return new ClubLeagueResponse
            {
                Total = clubs.Count,
                NameLeague = clubs?.FirstOrDefault(a => a.League.Id ==  leagueId)?.League?.Name,
                Clubs = clubs.Select(model => new ClubLeagueDto { Id = model.Id, Name = model.Name }).OrderBy(x => x.Name).ToList()
            };
        }
    }
}
