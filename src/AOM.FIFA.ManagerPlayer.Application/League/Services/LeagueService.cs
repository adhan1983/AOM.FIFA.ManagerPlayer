using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.League.Dtos;
using AOM.FIFA.ManagerPlayer.Application.League.Responses;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Requests;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.Base.Response;

namespace AOM.FIFA.ManagerPlayer.Application.League.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        public LeagueService(ILeagueRepository leagueRepository) => this._leagueRepository = leagueRepository;


        public async Task<TotalClubsByLeagueResponse> GetTotalClubsByLeagueResponse() 
        {
            var models = await _leagueRepository.GetLeaguesAsync();

            var response = new TotalClubsByLeagueResponse();            

            for (int i = 0, ii = models.Count; i < ii; i++)
            {
                var clubByLeagueDto = new ClubByLeagueDto
                {
                    Name = models[i].Name,
                    Total = models[i].Clubs.Count           
                };
                response.ClubsByLeague.Add(clubByLeagueDto);
            }
            response.ClubsByLeague = response.ClubsByLeague.OrderByDescending(a => a.Total).ToList();
            
            return response;            
        }
        
        public async Task<LeagueDto> GetLeagueByIdAsync(int id)
        {
            var league = await _leagueRepository.GetByIdAsync(id);

            return new LeagueDto
            {
                Id = league.Id,
                Name = league.Name,
                SourceId = league.SourceId,
            };

        }

        public async Task<LeagueDto> GetLeagueBySourceIdAsync(int id)
        {
            var league = await _leagueRepository.GetByIdAsync(id);

            return new LeagueDto
            {
                Id = league.Id,
                Name = league.Name,
                SourceId = league.SourceId,
            };

        }

        public async Task<FIFAManagerResponse> InsertLeagueAsync(LeagueDto leagueDto)
        {
            var modelLeague = await _leagueRepository.GetLeagueBySourceId(leagueDto.SourceId);
            
            if(modelLeague != null) 
            {   
                return new FIFAManagerResponse() { Id = 0, Status = false,Message = "This league has been included" };
            }
            
            var result = await _leagueRepository.
                                InsertAsync(new Entities.League { Name = leagueDto.Name, SourceId = leagueDto.SourceId });

            return new FIFAManagerResponse { Id= result.Id, Status = true, Message = "Success" };

        }

        public async Task<LeaguesResponse> GetLeaguesResponseAsync(LeagueParametersRequest leagueParameters)
        {
            var leagues = await _leagueRepository.GetPagedListLeaguesAsync(leagueParameters);

            return new LeaguesResponse
            {
                Total = leagues.Count,
                Leagues = leagues.Select(model => new LeagueDto { Id = model.Id, Name = model.Name }).ToList()
            };
        }

        public async Task<LeagueDto> GetLeagueBySourceId(int sourceId)
        {
            var model = await _leagueRepository.GetLeagueBySourceId(sourceId);

            return new LeagueDto { Id = model.Id, Name = model.Name, SourceId = model.SourceId };
        }

        public async Task<List<LeagueDto>> GetLeaguesAsync()
        {
            var models = await _leagueRepository.GetAllAsync();

            return models.Select(l => new LeagueDto { Id = l.Id, Name = l.Name }).ToList();

        }

    }
}