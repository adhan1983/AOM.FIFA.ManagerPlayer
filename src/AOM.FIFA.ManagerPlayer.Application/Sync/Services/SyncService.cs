using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using AOM.FIFA.ManagerPlayer.Application.Sync.Responses;
using AOM.FIFA.ManagerPlayer.Application.SyncNation.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Services
{
    public class SyncService : ISyncService
    {
        private readonly ISyncRepository _syncRepository;
        private readonly ISyncLeagueService _syncLeagueService;
        private readonly ISyncClubService _syncClubService;
        private readonly ISyncNationService _syncNationService;

        public SyncService(ISyncRepository syncRepository, ISyncLeagueService syncLeagueService, ISyncClubService syncClubService, ISyncNationService syncNationService)
        {
            this._syncRepository = syncRepository;
            this._syncLeagueService = syncLeagueService;
            this._syncClubService = syncClubService;
            this._syncNationService = syncNationService;
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
                syncPage.SyncId = sync.Id;
                syncPage.Page = 1;
            }

            switch (name)
            {
                case "league":
                    await _syncLeagueService.SyncLeaguesAsync(sync.TotalItemsPerPage, syncPage);
                    break;
                case "club":
                    await _syncClubService.SyncClubsAsync(sync.TotalItemsPerPage, syncPage);
                    break;
                case "nation":
                    await _syncNationService.SyncNationAsync(sync.TotalItemsPerPage, syncPage); 
                    break;
                case "player":
                    break;
                default:
                    break;
            }


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
        
    }
}
