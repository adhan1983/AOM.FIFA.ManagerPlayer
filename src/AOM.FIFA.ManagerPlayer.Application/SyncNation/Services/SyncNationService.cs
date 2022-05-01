using System;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using AOM.FIFA.ManagerPlayer.Application.SyncNation.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces;
using entity = AOM.FIFA.ManagerPlayer.Application.Nation.Entities;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Application.SyncNation.Services
{
    public class SyncNationService : ISyncNationService
    {
        private readonly IHttpClientFactoryService _httpClientServiceImplementation;
        private readonly INationRepository _nationRepository;

        public SyncNationService(INationRepository nationRepository, IHttpClientFactoryService httpClientServiceImplementation)
        {
            this._nationRepository = nationRepository;
            this._httpClientServiceImplementation = httpClientServiceImplementation;
        }

        public async Task<SyncPage> SyncNationAsync(int totalItemsPerPage, SyncPage syncPage)
        {
            var response = await _httpClientServiceImplementation.
                                    GetNationsAsync(new Request { Page = syncPage.Page, MaxItemPerPage = totalItemsPerPage });

            foreach (var nation in response.items)
            {

                try
                {
                    var model = await _nationRepository.
                                InsertAsync(new entity.Nation { Name = nation.name, SourceId = nation.id });

                    if (model.Id > 0)
                        syncPage.TotalSynchronized++;
                }
                catch (Exception ex)
                {
                    syncPage.TotalDosNotSynchronized++;

                    var sourceWithoutSync = new SourceWithoutSync
                    {
                        SourceId = nation.id,
                        SyncPageId = syncPage.Id
                    };

                    syncPage.SourcesWithoutSync.Add(sourceWithoutSync);

                }

            }

            return syncPage;

        }


    }
}
