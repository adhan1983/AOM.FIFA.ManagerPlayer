using AOM.FIFA.ManagerPlayer.Application.League.Responses;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [OpenApiTag("Sync League", Description = "Sync League")]
    public class SyncLeagueController : ControllerBase
    {
        private readonly ISyncLeagueService _syncLeagueService;

        public SyncLeagueController(ISyncLeagueService syncLeagueService)
        {            
            this._syncLeagueService = syncLeagueService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = new SyncResponseLeague();

            response = await _syncLeagueService.SyncLeaguesAsync();

            return Ok(response);

        }
    }
}
