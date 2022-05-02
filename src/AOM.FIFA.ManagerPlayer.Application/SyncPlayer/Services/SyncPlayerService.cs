using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Sync.Entities;
using AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;
using System;
using System.Linq;
using System.Threading.Tasks;
using m = AOM.FIFA.ManagerPlayer.Application.Player.Entities;
using r = AOM.FIFA.ManagerPlayer.Gateway.Responses.Player;

namespace AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Services
{
    public class SyncPlayerService : ISyncPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IClubRepository _clubRepository;
        private readonly IHttpClientFactoryService _httpClientServiceImplementation;

        public SyncPlayerService(IPlayerRepository playerRepository, IHttpClientFactoryService httpClientServiceImplementation, IClubRepository clubRepository)
        {
            this._playerRepository = playerRepository;
            this._httpClientServiceImplementation = httpClientServiceImplementation;
            this._clubRepository = clubRepository;
        }

        public async Task<SyncPage> SyncPlayerAsync(int totalItemsPerPage, SyncPage syncPage)
        {
            var response = await _httpClientServiceImplementation.GetPlayersAsync(new Request
            {
                Page = syncPage.Page,
                MaxItemPerPage = totalItemsPerPage
            });

            var clubs = await _clubRepository.GetAllAsync();

            foreach (var item in response.items)
            {
                try
                {
                    var club = clubs?.FirstOrDefault(x => x.SourceId == item?.club);

                    if (club == null)
                    {
                        var sourceWithoutSync = new SourceWithoutSync
                        {
                            SourceId = item.id,
                            SyncPageId = syncPage.Id
                        };

                        continue;
                    }

                    var model = await _playerRepository.InsertAsync(Mapper(item));
                    if (model.Id > 0)
                        syncPage.TotalSynchronized++;

                }
                catch (Exception ex)
                {
                    syncPage.TotalDosNotSynchronized++;

                    var sourceWithoutSync = new SourceWithoutSync
                    {
                        SourceId = item.id,
                        SyncPageId = syncPage.Id
                    };

                    syncPage.SourcesWithoutSync.Add(sourceWithoutSync);
                }
            }

            return syncPage;

        }


        private m.Player Mapper(r.Player player)
        {
            var model = new m.Player
            {
                Name = player.name,
                Age = player.age,
                AttackWorkRate = player.attack_work_rate,
                ClubId = player.id,
                CommonName = player.common_name,
                Defending = player.defending,
                DefenseWorkRate = player.defense_work_rate,
                Dribbling = player.dribbling,
                Foot = player.foot,
                Height = player.height,
                LastName = player.last_name,
                NationId = player.nation,
                Pace = player.pace,
                Passing = player.passing,
                Physicality = player.physicality,
                Position = player.position,
                Rarity = player.rarity,
                Rating = player.rating,
                Shooting = player.shooting,
                SourceId = player.id,
                TotalStats = player.total_stats,
                Weight = player.weight,
            };

            return model;
        }
    }
}
