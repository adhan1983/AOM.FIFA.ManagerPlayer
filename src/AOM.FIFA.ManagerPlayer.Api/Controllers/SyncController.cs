using AOM.FIFA.ManagerPlayer.Application.SyncClub.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.SyncClub.Responses;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Interfaces.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Responses;
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
        private readonly ISyncLeagueService _syncLeagueService;
        private readonly ISyncClubService _syncClubService;

        public SyncController(ISyncLeagueService syncLeagueService, ISyncClubService syncClubService)
        {            
            this._syncLeagueService = syncLeagueService;
            this._syncClubService = syncClubService;
        }        

        [HttpPost]
        [Route("leagues")]
        public async Task<IActionResult> Leagues()
        {
            var response = new SyncLeagueResponse();
                        
            response = await _syncLeagueService.SyncLeaguesAsync();             

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
