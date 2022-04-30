using NSwag.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AOM.FIFA.ManagerPlayer.Application.Sync.Responses;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("api/sync")]
    [ApiController]
    [OpenApiTag("Sync FIFA", Description = "End point responsable for Synchronazation")]
    public class SyncController : ControllerBase
    {
        private readonly ISyncService _syncService;       

        public SyncController(ISyncService syncService) => this._syncService = syncService;
               

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
            var response = new SyncResponse();

            response = await _syncService.SyncByNameAsync("club");

            return Ok(response);

        }
    }
}
