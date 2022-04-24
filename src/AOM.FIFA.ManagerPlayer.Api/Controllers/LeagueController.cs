using NSwag.Annotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.League.Dtos;
using AOM.FIFA.ManagerPlayer.Application.League.Services.Interfaces.Services;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("api/leagues")]
    [ApiController]
    [OpenApiTag("League", Description = "End point responsable for Leagues")]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;

        public LeagueController(ILeagueService leagueService) => this._leagueService = leagueService;

        //TO DO https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio

        [HttpGet]
        [ProducesResponseType(typeof(List<LeagueDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await _leagueService.GetLeaguesResponseAsync();
            
            return Ok(result);
        }

        [HttpGet("{id}")]        
        [ProducesResponseType(typeof(LeagueDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _leagueService.GetLeagueByIdAsync(id);
            
            return Ok(result);
        }

    }
}
