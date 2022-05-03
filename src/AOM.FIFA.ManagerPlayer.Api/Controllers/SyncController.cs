using NSwag.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AOM.FIFA.ManagerPlayer.Application.Sync.Responses;
using AOM.FIFA.ManagerPlayer.Application.Synchronization.Interfaces;
using System.Threading;

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

        [HttpPost]
        [Route("nations")]
        public async Task<IActionResult> Nations()
        {
            var response = new SyncResponse();

            response = await _syncService.SyncByNameAsync("nation");

            return Ok(response);

        }

        [HttpPost]
        [Route("player")]
        public async Task<IActionResult> Player()
        {
            var response = new SyncResponse();

            for (int i = 1; i < 10; i++)
            {
                response = await _syncService.SyncByNameAsync("player");
                Thread.Sleep(3000);
            }

            return Ok(response);

        }
    }
}
