using AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("api/nation")]
    [ApiController]
    [OpenApiTag("Nation", Description = "End point responsable for Nations")]
    public class NationController : ControllerBase
    {
        private readonly INationgRPCService nationgRPCService;

        public NationController(gRPCServer.Services.Interfaces.INationgRPCService nationgRPCService)
        {
            this.nationgRPCService = nationgRPCService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post()
        {
            var result = await nationgRPCService.InsertNation(new gRPCServer.NationRequest { Name = "AOMAOM", SourceId = 2 }, null);

            return Ok(result);
        }
    }
}
