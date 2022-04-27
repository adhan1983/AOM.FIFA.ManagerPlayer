using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Responses;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues;
using System.Linq;
using System.Threading.Tasks;
using entity = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services
{
    public class SyncLeagueService : ISyncLeagueService
    {
        
        private readonly ILeagueRepository _leagueRepository;
        private readonly IHttpClientFactoryService _httpClientServiceImplementation;

        public SyncLeagueService(ILeagueRepository leagueRepository, IHttpClientFactoryService httpClientServiceImplementation) 
        { 
            this._leagueRepository = leagueRepository;
            this._httpClientServiceImplementation = httpClientServiceImplementation;
        }

        public async Task<SyncLeagueResponse> SyncLeaguesAsync()
        {            
            var response = new SyncLeagueResponse();            

            var result = await GetLeagueListResponseAsync();

            var leagues = result.
                            items.
                            Select(x => new entity.League { Name = x.name, SourceId = x.id }).
                            ToList();

            var resulInsertManyAsync = await _leagueRepository.InsertManyAsync(leagues);

            response.AllLeaguesSyncronized = resulInsertManyAsync;
            
            return response;
        }

        private async Task<LeagueListResponse> GetLeagueListResponseAsync()
        {
            var response = new LeagueListResponse();
            
            var firstResponse = await _httpClientServiceImplementation.GetLeaguesAsync(new Request { Page = 1, MaxItemPerPage = 20 });

            response.items.AddRange(firstResponse.items);

            for (int nextPage = firstResponse.page + 1, total = firstResponse.page_total; nextPage <= total; nextPage++)
            {
                //Thread.Sleep(5000);
                var resultAnotherResponses = await _httpClientServiceImplementation.GetLeaguesAsync(new Request { Page = nextPage, MaxItemPerPage = 20 });
                response.items.AddRange(resultAnotherResponses.items);
            }

            return response;
        }
    }
}
