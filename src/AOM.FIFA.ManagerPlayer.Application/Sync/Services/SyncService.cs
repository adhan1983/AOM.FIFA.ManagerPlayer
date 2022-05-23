using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using s = AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using AOM.FIFA.ManagerPlayer.Application.Sync.Responses;
using AOM.FIFA.ManagerPlayer.Application.SyncNation.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Interfaces.Services;

namespace AOM.FIFA.ManagerPlayer.Application.Synchronization.Services
{
    public class SyncService : ISyncService
    {
        private readonly ISyncRepository _syncRepository;
        private readonly ISyncLeagueService _syncLeagueService;
        private readonly ISyncClubService _syncClubService;
        private readonly ISyncNationService _syncNationService;
        private readonly ISyncPlayerService _syncPlayerService;

        public SyncService(
                ISyncRepository syncRepository, ISyncLeagueService syncLeagueService, 
                ISyncClubService syncClubService, ISyncNationService syncNationService,
                ISyncPlayerService syncPlayerService
            )
        {
            this._syncRepository = syncRepository;
            this._syncLeagueService = syncLeagueService;
            this._syncClubService = syncClubService;
            this._syncNationService = syncNationService;
            this._syncPlayerService = syncPlayerService;
        }

        public async Task PublishingFifaJobs()
        {
            var jobs = await _syncRepository.GetJobsAsync();

            if (jobs.Any(a => !a.Synchronized))
            {
                foreach (var job in jobs)
                {
                    switch (job.Name)
                    {
                        case "League":
                            if (!job.Synchronized)
                            {
                                await SyncByNameAsync(job);
                            }
                            break;
                        case "Nation":
                            if (!job.Synchronized)
                            {
                                await SyncByNameAsync(job);
                            }
                            break;
                        case "Club":
                            if (!job.Synchronized && jobs.FirstOrDefault(x => x.Name == "League").Synchronized)
                            {
                                await SyncByNameAsync(job);
                            }
                            break;
                        case "Player":
                            if (!job.Synchronized && jobs.FirstOrDefault(x => x.Name == "Club").Synchronized && jobs.FirstOrDefault(x => x.Name == "Nation").Synchronized && jobs.FirstOrDefault(x => x.Name == "League").Synchronized)
                            {
                                await SyncByNameAsync(job);
                            }
                            break;
                    }
                } 
            }
        }

        public async Task<SyncResponse> SyncByNameAsync(s.Sync job)
        {           
            var response = new SyncResponse() { TypeOfSyncName = job.Name, SourceIdsDoNotSynchronized = new List<int>() };

            var syncPage = new s.SyncPage() { SourcesWithoutSync = new List<s.SourceWithoutSync>() };

            if (job.SyncPages.Any())
            {
                var syncPages = job.SyncPages;
                var lastPageSynchronized = job.SyncPages.Max(a => a.Page);

                var syncPageSuccess = syncPages.Any(a => a.SyncPageSuccess == false);

                if (job.Synchronized)
                {
                    response.TotalPagesSynchronized = syncPages.Where(x => x.Page > 0).Count();
                    response.TotalItemDoNotSynchronized = syncPages.Where(x => x.TotalDosNotSynchronized > 0).Count();
                    response.TotalItemsSynchronized = syncPages.Select(x => x.TotalSynchronized).Sum();
                    response.SourceIdsDoNotSynchronized = null;
                    response.AllItemsSynchronized = true;
                    response.Synchronized = job.Synchronized;

                    return response;
                }

                syncPage.SyncId = job.Id;
                syncPage.Page = lastPageSynchronized + 1;
            }
            else
            {
                syncPage.SyncId = job.Id;
                syncPage.Page = 1;
            }

            switch (job.Name)
            {
                case "League":
                    await _syncLeagueService.SyncLeaguesAsync(job.TotalItemsPerPage, syncPage);
                    break;
                case "Club":
                    await _syncClubService.SyncClubsAsync(job.TotalItemsPerPage, syncPage);
                    break;
                case "Nation":
                    await _syncNationService.SyncNationAsync(job.TotalItemsPerPage, syncPage); 
                    break;
                case "Player":
                    await _syncPlayerService.SyncPlayerAsync(job.TotalItemsPerPage, syncPage);
                    break;
                default:
                    break;
            }


            syncPage.SyncPageSuccess = syncPage.TotalDosNotSynchronized > 0 ? false : true;
            job.SyncPages.Add(syncPage);
            job.Synchronized = (job.SyncPages.Max(a => a.Page) == job.TotalPages);
            var syncUpdated = await _syncRepository.UpdateAsync(job);

            response.TotalItemsSynchronized = syncPage.TotalSynchronized;
            response.TotalItemDoNotSynchronized = syncPage.TotalDosNotSynchronized;
            response.SourceIdsDoNotSynchronized.AddRange(syncPage.SourcesWithoutSync.Select(a => a.SourceId).ToList());
            response.AllItemsSynchronized = syncPage.SyncPageSuccess;
            response.Synchronized = job.Synchronized;

            return response;

        }
        
    }
}
