using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Logging.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Club.Responses;
using entities = AOM.FIFA.ManagerPlayer.Application.Club.Entities;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Base.Response;

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

        public async Task<FIFAManagerResponse> InsertClubAsync(ClubDto clubDto)
        {
            var modelLeague = await _leagueService.GetLeagueBySourceId(clubDto.SourceLeagueId);

            if (modelLeague == null) 
            {
                return new FIFAManagerResponse { Id = 0, Message = "League is required", Status = false };
            }

            var modelClub = await _clubRepository.GetClubBySourceId(clubDto.SourceId);
            if (modelClub != null) 
            {
                return new FIFAManagerResponse { Id = 0, Message = "Club existed", Status = false };
            }
            
            var model = new entities.Club() 
            {
                Name = clubDto.Name,
                LeagueId = modelLeague.Id,
                SourceId = clubDto.SourceId,                
            };

            var result = await _clubRepository.InsertAsync(model);

            return new FIFAManagerResponse { Id = model.Id, Status = true, Message = "Success" };
        }

        public async Task<ClubDto> GetClubBySourceId(int sourceId)
        {
            var model = await _clubRepository.GetClubBySourceId(sourceId);

            if (model == null)
                return null;

            var clubDto = new ClubDto { Id = model.Id, Name = model.Name, SourceId = model.SourceId  };

            return clubDto;
        }
    }
}
