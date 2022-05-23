using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
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

        public async Task<SyncPage> SyncLeaguesAsync(int totalItemsPerPage, SyncPage syncPage)
        {
            var response = await _httpClientServiceImplementation.
                                    GetLeaguesAsync(new Request{ Page = syncPage.Page, MaxItemPerPage = totalItemsPerPage });

            var leagues = response.
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

    }
}
