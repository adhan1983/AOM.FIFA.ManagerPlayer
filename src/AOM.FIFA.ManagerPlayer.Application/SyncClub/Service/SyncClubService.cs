using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Responses;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Clubs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using domainLeague = AOM.FIFA.ManagerPlayer.Application.League.Entities;
using entity = AOM.FIFA.ManagerPlayer.Application.Club.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.SyncClub.Services
{
    public class SyncClubService : ISyncClubService
    {

        private readonly IHttpClientFactoryService _httpClientServiceImplementation;
        private readonly IClubRepository _clubRepository;
        private readonly ILeagueRepository _leagueRepository;

        public SyncClubService(IHttpClientFactoryService httpClientServiceImplementation,  IClubRepository clubRepository, ILeagueRepository leagueRepository) 
        {            
            this._clubRepository = clubRepository;
            this._leagueRepository = leagueRepository;
            this._httpClientServiceImplementation = httpClientServiceImplementation;
        }

        public async Task<SyncClubResponse> SyncClubsAsync()
        {
            //TO TO : We should have syncronized 674 clubs instead 668. Maybe because some of them has leage as null parameter.

            var response = new SyncClubResponse();

            var leagues = await _leagueRepository.GetAllAsync();

            var lst  = leagues.ToList();
            
            var firstResponse = await InsertManyClubsAsync(1, lst);            
            
            for (int nextPage = firstResponse.page + 1, total = firstResponse.page_total; nextPage <= total; nextPage++)
            {
                await InsertManyClubsAsync(nextPage, lst);
                
                Thread.Sleep(5000);
            }

            response.AllClubsSyncronized = true;
            
            return response;
        }

        private async Task<ClubListResponse> InsertManyClubsAsync(int page, List<domainLeague.League> leagues)
        {
            try
            {
                var response = await _httpClientServiceImplementation.GetClubsAsync(new Request { Page = page, MaxItemPerPage = 20 });
                
                response.items.RemoveAll(a => a.league == null);

                var clubs = response.
                                items.
                                Select(x => new entity.Club
                                {
                                    Name = x.name,
                                    LeagueId = leagues.FirstOrDefault(c => c.SourceId == x.league).Id,
                                    SourceId = x.id,
                                }).
                                ToList();

                var status = await _clubRepository.InsertManyAsync(clubs);

                return response;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
    }
}
