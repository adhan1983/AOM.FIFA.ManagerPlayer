using AOM.FIFA.ManagerPlayer.Application.League.Responses;
using AOM.FIFA.ManagerPlayer.Application.League.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues;
using System.Threading.Tasks;
using gateway = AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces;


namespace AOM.FIFA.ManagerPlayer.Application.League.Services
{
    public class SyncLeagueService : ISyncLeagueService
    {
        private readonly gateway.ILeagueService _leagueService;
        public SyncLeagueService(gateway.ILeagueService leagueService) => _leagueService = leagueService;
        public async Task<SyncResponseLeague> SyncLeaguesAsync()
        {            
            var response = new SyncResponseLeague();

            var result = await GetLeagueListResponseAsync();

            //TO DO: Store in database


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
