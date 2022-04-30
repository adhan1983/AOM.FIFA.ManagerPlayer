using AOM.FIFA.ManagerPlayer.Application.Sync.Responses;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Responses;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("api/sync")]
    [ApiController]
    [OpenApiTag("Sync FIFA", Description = "End point responsable for Synchronazation")]
    public class SyncController : ControllerBase
    {
        private readonly ISyncService _syncService;
        private readonly ISyncLeagueService _syncLeagueService;
        private readonly ISyncClubService _syncClubService;

        public SyncController(ISyncLeagueService syncLeagueService, ISyncClubService syncClubService, ISyncService syncService)
        {            
            this._syncLeagueService = syncLeagueService;
            this._syncClubService = syncClubService;
            this._syncService = syncService;
        }        

        [HttpPost]
        [Route("leagues")]
        public async Task<IActionResult> Leagues()
        {
            var response = new SyncResponse();

            response = await _syncService.SyncByNameAsync("league");

            return Ok(response);

        }

        [HttpPost]
        [Route("clubs")]
        public async Task<IActionResult> Clubs()
        {
            var response = new SyncClubResponse();

            response = await _syncClubService.SyncClubsAsync();

            return Ok(response);

        }
    }
}
