using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Logging.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Club.Responses;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;

        private readonly ILoggerManager _loggerManager;

        public ClubService(IClubRepository clubRepository, ILoggerManager loggerManager) 
        { 
            this._clubRepository = clubRepository;
            this._loggerManager = loggerManager;
        }

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
            try
            {
                _loggerManager.LogInfo("Before getClubsByLeague");
                
                var clubs = await _clubRepository.GetClubsByLeagueIdAsync(leagueId);
                
                _loggerManager.LogInfo("After getClubsByLeague");

                return new ClubLeagueResponse
                {
                    Total = clubs.Count,
                    NameLeague = clubs?.FirstOrDefault(a => a.League.Id == leagueId)?.League?.Name,
                    Clubs = clubs.Select(model => new ClubLeagueDto { Id = model.Id, Name = model.Name }).OrderBy(x => x.Name).ToList()
                };
            }
            catch (System.Exception ex)
            {                              
                _loggerManager.LogError(ex.Message);
                return new ClubLeagueResponse { Clubs = null, Total = 0, NameLeague = string.Empty };
            }
        }
    }
}
