using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Leagues;
using System;
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

        public async Task<SyncPage> SyncLeaguesAsync(int page, int totalItemsPerPage, SyncPage syncPage)
        {            
            var result = await GetLeagueListResponseAsync(page, totalItemsPerPage);

            var leagues = result.
                            items.
                            Select(x => new entity.League { Name = x.name, SourceId = x.id }).
                            ToList();

            foreach (var league in leagues)
            {
                try
                {                    
                    var model = await _leagueRepository.InsertAsync(league);
                    if (model.Id > 0)
                        syncPage.TotalSynchronized++;
                   
                }
                catch (Exception ex)
                {
                    syncPage.TotalDosNotSynchronized++;

                    var sourceWithoutSync = new SourceWithoutSync
                    {
                        SourceId = league.SourceId,
                        SyncPageId = syncPage.Id
                    };

                    syncPage.SourcesWithoutSync.Add(sourceWithoutSync);
                }

            }

            return syncPage;
        }

        /*
         * public async Task<SyncResponse> SyncLeaguesAsync()
        {
            var sync = await _syncService.GetSyncByNameAsync("League");

            var response = new SyncResponse() {  TypeOfSyncName = sync.Name, SourceIdsDoNotSynchronized = new List<int>() };

            var syncPage = new SyncPage() {  SourcesWithoutSync = new List<SourceWithoutSync>() };
            
            if (sync.SyncPages.Any())
            {
                var syncPages = sync.SyncPages;                
                var lastPageSynchronized = sync.SyncPages.Max(a => a.Page);                

                var syncPageSuccess = syncPages.Any(a => a.SyncPageSuccess == false);

                if (sync.Synchronized) 
                {                   
                    response.TotalPagesSynchronized = syncPages.Where(x => x.Page > 0).Count();
                    response.TotalItemDoNotSynchronized = syncPages.Where(x => x.TotalDosNotSynchronized > 0).Count();
                    response.TotalItemsSynchronized = syncPages.Select(x => x.TotalSynchronized).Sum();
                    response.SourceIdsDoNotSynchronized = null;
                    response.AllItemsSynchronized = true;                    
                    response.Synchronized = sync.Synchronized;
                    
                    return response;
                }

                syncPage.SyncId = sync.Id;
                syncPage.Page = lastPageSynchronized + 1;                
            }
            else
            {
                //FirstTime
                syncPage.SyncId = sync.Id;
                syncPage.Page = 1;                
            }

            var result = await GetLeagueListResponseAsync(syncPage.Page, sync.TotalItemsPerPage);

            var leagues = result.
                            items.
                            Select(x => new entity.League { Name = x.name, SourceId = x.id }).
                            ToList();

            foreach (var league in leagues)
            {
                try
                {                    
                    var model = await _leagueRepository.InsertAsync(league);
                    if (model.Id > 0)
                        syncPage.TotalSynchronized++;
                   
                }
                catch (Exception ex)
                {
                    syncPage.TotalDosNotSynchronized++;

                    var sourceWithoutSync = new SourceWithoutSync
                    {
                        SourceId = league.SourceId,
                        SyncPageId = syncPage.Id
                    };

                    syncPage.SourcesWithoutSync.Add(sourceWithoutSync);
                }

            }

            syncPage.SyncPageSuccess = syncPage.TotalDosNotSynchronized > 0 ? false : true;
            sync.SyncPages.Add(syncPage);
            sync.Synchronized = (sync.SyncPages.Max(a => a.Page) == sync.TotalPages);
            var syncUpdated = await _syncService.UpdateAsync(sync);

            response.TotalItemsSynchronized = syncPage.TotalSynchronized;
            response.TotalItemDoNotSynchronized = syncPage.TotalDosNotSynchronized;
            response.SourceIdsDoNotSynchronized.AddRange(syncPage.SourcesWithoutSync.Select(a => a.SourceId).ToList());
            response.AllItemsSynchronized = syncPage.SyncPageSuccess;
            response.Synchronized = sync.Synchronized;

            return response;
        }
         */

        private async Task<LeagueListResponse> GetLeagueListResponseAsync(int page, int maxItemPerPage)
        {
            var response = new LeagueListResponse();

            var firstResponse = await _httpClientServiceImplementation.GetLeaguesAsync(new Request { Page = page, MaxItemPerPage = maxItemPerPage });

            response.items.AddRange(firstResponse.items);

            return response;
        }
    }
}
