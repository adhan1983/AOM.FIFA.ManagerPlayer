using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.League.Dtos;
using AOM.FIFA.ManagerPlayer.Application.League.Responses;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Requests;

namespace AOM.FIFA.ManagerPlayer.Application.League.Services
{
    public class LeagueService : ILeagueService
    {
        private readonly ILeagueRepository _leagueRepository;
        public LeagueService(ILeagueRepository leagueRepository) => this._leagueRepository = leagueRepository;

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

        public async Task<int> InsertLeagueAsync(LeagueDto leagueDto)
        {
            var result = await _leagueRepository.
                                InsertAsync(new Entities.League { Name = leagueDto.Name, SourceId = leagueDto.SourceId });

            return result.Id;

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

    }
}