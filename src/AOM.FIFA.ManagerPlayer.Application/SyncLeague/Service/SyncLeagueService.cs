using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Responses;
using entity = AOM.FIFA.ManagerPlayer.Application.League.Entities;
using gateway = AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.League.Services.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services
{
    public class SyncLeagueService : ISyncLeagueService
    {
        private readonly gateway.ILeagueService _leagueService;
        private readonly ILeagueRepository _leagueRepository;

        public SyncLeagueService(gateway.ILeagueService leagueService, ILeagueRepository leagueRepository) 
        { 
            _leagueService = leagueService;
            _leagueRepository = leagueRepository;
        }

        public async Task<SyncLeagueResponse> SyncLeaguesAsync()
        {            
            var response = new SyncLeagueResponse();

            var result = await GetLeagueListResponseAsync();

            var leagues = result.
                            items.
                            Select(x => new entity.League { Name = x.name }).
                            ToList();

            var resulInsertManyAsync = await _leagueRepository.InsertManyAsync(leagues);

            response.AllLeaguesSyncronized = resulInsertManyAsync;
            
            return response;
        }

        private async Task<LeagueListResponse> GetLeagueListResponseAsync()
        {
            var response = new LeagueListResponse();
            
            var firstResponse = await _leagueService.GetLeaguesAsync(new LeagueRequest { Page = 1, MaxItemPerPage = 20 });

            response.items.AddRange(firstResponse.items);

            for (int nextPage = firstResponse.page + 1, total = firstResponse.page_total; nextPage <= total; nextPage++)
            {
                var resultAnotherResponses = await _leagueService.GetLeaguesAsync(new LeagueRequest { Page = nextPage, MaxItemPerPage = 20 });
                response.items.AddRange(resultAnotherResponses.items);
            }

            return response;
        }
    }
}
