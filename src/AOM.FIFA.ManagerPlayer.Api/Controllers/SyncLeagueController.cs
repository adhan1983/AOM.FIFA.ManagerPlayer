using NSwag.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Responses;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("api/syncleagues")]
    [ApiController]
    [OpenApiTag("Sync League", Description = "End point responsable for Sync Leagues")]
    public class SyncLeagueController : ControllerBase
    {
        private readonly ISyncLeagueService _syncLeagueService;

        public SyncLeagueController(ISyncLeagueService syncLeagueService)
        {            
            this._syncLeagueService = syncLeagueService;
        }

        [HttpPost]        
        public async Task<IActionResult> Post()
        {
            var response = new SyncLeagueResponse();

            response = await _syncLeagueService.SyncLeaguesAsync();

            return Ok(response);

        }
    }
}
