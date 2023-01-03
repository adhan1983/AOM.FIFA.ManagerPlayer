using AOM.FIFA.ManagerPlayer.Application.Base.Response;
using AOM.FIFA.ManagerPlayer.Application.League.Dtos;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.League.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("/league")]
    [ApiController]
    [Authorize]
    [OpenApiTag("League", Description = "FiFA Player Manager Leagues: Premier League, Budesliga, La Liga, Serie A, UEFA Champios League")]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueService _leagueService;
        public LeagueController(ILeagueService leagueService) => this._leagueService = leagueService;        

        [HttpGet]
        [ProducesResponseType(typeof(List<LeagueDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery]LeagueParametersRequest leagueParameters)
        {
            var result = await _leagueService.GetLeaguesResponseAsync(leagueParameters);
            
            return Ok(result);
        }

        [HttpGet("/TotalClubsByLeague")]
        [ProducesResponseType(typeof(List<LeagueDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTotalClubsByLeague()
        {
            var result = await _leagueService.GetTotalClubsByLeagueResponse();

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

        [HttpPost]
        [ProducesResponseType(typeof(LeagueDto), StatusCodes.Status201Created)]        
        public async Task<IActionResult> Post([FromBody]LeagueDto leagueDto) 
        {
            var response = new FIFAManagerResponse();

            response.Id = await _leagueService.InsertLeagueAsync(leagueDto);

            return Ok(response);
        }


    }
}
