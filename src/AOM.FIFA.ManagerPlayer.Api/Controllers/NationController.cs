using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Nation.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("api/nation")]
    [ApiController]
    [Authorize]
    public class NationController : ControllerBase
    {
        private readonly INationService _nationService;

        public NationController(INationService nationService) => this._nationService = nationService;

        [HttpGet]
        [ProducesResponseType(typeof(NationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await _nationService.GetNationResponseAsync();

            return Ok(result);
        }
    }
}
