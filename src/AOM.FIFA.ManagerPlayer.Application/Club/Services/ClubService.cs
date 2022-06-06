using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Logging.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Club.Responses;
using entities = AOM.FIFA.ManagerPlayer.Application.Club.Entities;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Services
{
    public class ClubService : IClubService
    {
        private readonly IClubRepository _clubRepository;

        private readonly ILoggerManager _loggerManager;
        
        private readonly ILeagueService _leagueService;

        public ClubService(IClubRepository clubRepository, ILoggerManager loggerManager, ILeagueService leagueService) 
        { 
            this._clubRepository = clubRepository;
            this._loggerManager = loggerManager;
            this._leagueService = leagueService;
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

        public async Task<int> InsertClubAsync(ClubDto clubDto)
        {
            var league = await _leagueService.GetLeagueBySourceId(clubDto.SourceLeagueId);
            
            var model = new entities.Club() 
            {
                Name = clubDto.Name,
                LeagueId = league.Id,
                SourceId = clubDto.SourceId,                
            };

            var result = await _clubRepository.InsertAsync(model);
            
            return result.Id;
        }

        public async Task<ClubDto> GetClubBySourceId(int sourceId)
        {
            var model = await _clubRepository.GetClubBySourceId(sourceId);

            var clubDto = new ClubDto { Id = model.Id, Name = model.Name, SourceId = model.SourceId  };

            return clubDto;
        }
    }
}
