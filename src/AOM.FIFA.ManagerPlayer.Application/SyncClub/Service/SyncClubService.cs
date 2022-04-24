using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Responses;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Clubs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using entity = AOM.FIFA.ManagerPlayer.Application.Club.Entities;
using gateway = AOM.FIFA.ManagerPlayer.Gateway.Services.Interfaces;
using domainLeague = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services
{
    public class SyncClubService : ISyncClubService
    {
        private readonly gateway.IClubService _clubService;
        private readonly IClubRepository _clubRepository;
        private readonly ILeagueRepository _leagueRepository;


        public SyncClubService(gateway.IClubService clubService, IClubRepository clubRepository, ILeagueRepository leagueRepository) 
        { 
            _clubService = clubService;
            _clubRepository = clubRepository;
            _leagueRepository = leagueRepository;
        }

        public async Task<SyncClubResponse> SyncClubsAsync()
        {
            //TO TO : We should have syncronized 674 clubs instead 668. Maybe because some of them has leage as null parameter.

            var response = new SyncClubResponse();

            var leagues = await _leagueRepository.GetAllAsync();

            var lst  = leagues.ToList();
            
            var firstResponse = await InsertManyClubsAsync(1, lst);

            bool resulInsertManyAsync = false;
            
            for (int nextPage = firstResponse.page + 1, total = firstResponse.page_total; nextPage <= total; nextPage++)
            {
                await InsertManyClubsAsync(nextPage, lst);
                
                Thread.Sleep(5000);
            }

            resulInsertManyAsync = true;

            response.AllClubsSyncronized = resulInsertManyAsync;
            
            return response;
        }

        private async Task<ClubListResponse> InsertManyClubsAsync(int page, List<domainLeague.League> leagues)
        {
            try
            {
                var response = await _clubService.GetClubsAsync(new ClubRequest { Page = page, MaxItemPerPage = 20 });
                
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
