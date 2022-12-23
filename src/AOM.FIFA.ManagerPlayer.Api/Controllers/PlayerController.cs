using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Player.Requests;
using AOM.FIFA.ManagerPlayer.Application.Player.Responses;
using AOM.FIFA.ManagerPlayer.Application.Player.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("api/players")]
    [ApiController]
    [OpenApiTag("Player", Description = "End point responsable for Players")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService) => this._playerService = playerService;


        [HttpGet]
        [ProducesResponseType(typeof(PlayerListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<IActionResult> Get([FromQuery] PlayerParameterRequest playerParameters)
        {
            var result = await _playerService.GetPlayersAsync(playerParameters);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PlayerListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _playerService.GetPlayerByIdAsync(id);

            return Ok(result);
        }

        [HttpGet("/byclub")]
        [ProducesResponseType(typeof(PlayerListResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery]PlayerClubParameterRequest request)
        {
            var result = await _playerService.GetPlayersByClubAsync(request);

            return Ok(result);
        }

        [HttpGet("/byfut22icon")]
        [ProducesResponseType(typeof(PlayerListFUT22ICONResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await _playerService.GetPlayerByFUT22ICONSAsync();

            return Ok(result);
        }


        [HttpGet("/GetPlayersByNationByLeague")]
        [ProducesResponseType(typeof(PlayerListFUT22ICONResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetPlayersByNationByLeague(int nationId, int leagueId)
        {
            var result = await _playerService.GetPlayersByNationByLeague(nationId, leagueId);

            return Ok(result);
        }


        [HttpGet("/GetTotalNationalityPlayerByNation")]
        [ProducesResponseType(typeof(TotalPlayersByLeagueByNationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTotalNationalityPlayerByNation()
        {
            var result = await _playerService.GetTotalNationalityPlayerByNation();

            return Ok(result);
        }


        

    }
}
