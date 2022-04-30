using System;
using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using entity = AOM.FIFA.ManagerPlayer.Application.Club.Entities;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Clubs;

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

        public async Task<SyncPage> SyncClubsAsync(int totalItemPerPage, SyncPage syncPage)
        {
            //TO TO : We should have syncronized 674 clubs instead 668. Maybe because some of them has leage as null parameter.

            var response = await _httpClientServiceImplementation.
                                    GetClubsAsync(new Request { Page = syncPage.Page, MaxItemPerPage = totalItemPerPage });

            RemoveSourceWillNotBeSync(response, syncPage);

            var leagues = await _leagueRepository.GetAllAsync();
            
            var clubs = response.
                             items.
                             Select(x => new entity.Club
                             {
                                 Name = x.name,
                                 LeagueId = leagues.FirstOrDefault(c => c.SourceId == x.league).Id,
                                 SourceId = x.id,
                             }).
                             ToList();

            foreach (var club in clubs)
            {
                try
                {
                    var model = await _clubRepository.InsertAsync(club);
                    if (model.Id > 0)
                        syncPage.TotalSynchronized++;
                }
                catch (Exception ex)
                {
                    syncPage.TotalDosNotSynchronized++;

                    var sourceWithoutSync = new SourceWithoutSync
                    {
                        SourceId = club.SourceId,
                        SyncPageId = syncPage.Id
                    };

                    syncPage.SourcesWithoutSync.Add(sourceWithoutSync);
                }
            }
            
            return syncPage;
        }

        private ClubListResponse RemoveSourceWillNotBeSync(ClubListResponse response, SyncPage syncPage) 
        {
            var itemsNeedToBeRemoved = response.items.Where(x => x.league == null).ToList();

            foreach (var item in itemsNeedToBeRemoved)
            {
                var sourceWithoutSync = new SourceWithoutSync
                {
                    SourceId = item.id,
                    SyncPageId = syncPage.Id
                };
                
                syncPage.SourcesWithoutSync.Add(sourceWithoutSync);

                syncPage.TotalDosNotSynchronized++;
            }

            response.items.RemoveAll(x => itemsNeedToBeRemoved.Contains(x));
            
            return response;
        }

    }
}
