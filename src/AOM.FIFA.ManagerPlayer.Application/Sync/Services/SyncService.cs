using System.Threading.Tasks;
using s = AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Sync.Responses;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using System.Linq;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Services
{
    public class SyncService : ISyncService
    {
        private readonly ISyncRepository _syncRepository;

        public ISyncLeagueService _syncLeagueService { get; }

        public SyncService(ISyncRepository syncRepository, ISyncLeagueService syncLeagueService)
        {
            this._syncRepository = syncRepository;
            this._syncLeagueService = syncLeagueService;
        }

        public async Task<SyncResponse> SyncByNameAsync(string name) 
        {
            var sync = await _syncRepository.GetSyncByNameAsync(name);

            var response = new SyncResponse() { TypeOfSyncName = sync.Name, SourceIdsDoNotSynchronized = new List<int>() };

            var syncPage = new SyncPage() { SourcesWithoutSync = new List<SourceWithoutSync>() };

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
            
            await _syncLeagueService.SyncLeaguesAsync(syncPage.Page, sync.TotalItemsPerPage, syncPage);

            syncPage.SyncPageSuccess = syncPage.TotalDosNotSynchronized > 0 ? false : true;
            sync.SyncPages.Add(syncPage);
            sync.Synchronized = (sync.SyncPages.Max(a => a.Page) == sync.TotalPages);
            var syncUpdated = await _syncRepository.UpdateAsync(sync);

            response.TotalItemsSynchronized = syncPage.TotalSynchronized;
            response.TotalItemDoNotSynchronized = syncPage.TotalDosNotSynchronized;
            response.SourceIdsDoNotSynchronized.AddRange(syncPage.SourcesWithoutSync.Select(a => a.SourceId).ToList());
            response.AllItemsSynchronized = syncPage.SyncPageSuccess;
            response.Synchronized = sync.Synchronized;

            return response;

        }

        public async Task<s.Sync> GetSyncByNameAsync(string name)
        {
            var result = await _syncRepository.GetSyncByNameAsync(name);

            return result;
        }

        public async Task<bool> UpdateAsync(s.Sync sync)
        {
            var result = await _syncRepository.UpdateAsync(sync);

            return result;
                
        }
    }
}
