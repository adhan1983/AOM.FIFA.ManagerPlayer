using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AOM.FIFA.ManagerPlayer.Application.League.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Nation.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Base.Response;
using AOM.FIFA.ManagerPlayer.Application.Nation.Responses;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("/nation")]
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

        [HttpPost]
        [ProducesResponseType(typeof(LeagueDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] NationDto nationDto)
        {
            var response = new FIFAManagerResponse();

            response.Id = await _nationService.InsertNationAsync(nationDto);

            return Ok(response);
        }
    }
}
