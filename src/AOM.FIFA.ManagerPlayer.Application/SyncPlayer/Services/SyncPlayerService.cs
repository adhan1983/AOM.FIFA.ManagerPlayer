using System;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Responses;
using AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Player;
using System.Linq;

namespace AOM.FIFA.ManagerPlayer.Application.SyncPlayer.Services
{
    public class SyncPlayerService : ISyncPlayerService
    {
        //private readonly IPlayerService _playerService;

        //public SyncPlayerService(IPlayerService playerService)
        //{
        //    this._playerService = playerService;
        //}

        public async Task<SyncPlayerResponse> SyncPlayerAsync()
        {
            //var result = await _playerService.GetPlayersAsync(new PlayerRequest { });

            


            
            
            throw new NotImplementedException();
        }
    }
}
