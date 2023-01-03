using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Club.Responses;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Base.Response;

namespace AOM.FIFA.ManagerPlayer.Api.Controllers
{
    [Route("/club")]
    [ApiController]
    [Authorize]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService) => this._clubService = clubService;

        [HttpGet]
        [ProducesResponseType(typeof(ClubResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = await _clubService.GetClubsResponseAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClubDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _clubService.GetClubByIdAsync(id);

            return Ok(result);
        }

        [HttpGet("{leagueId}/clubsbyleagueid")]        
        [ProducesResponseType(typeof(ClubLeagueResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClubsByLeagueId(int leagueId)
        {
            var result = await _clubService.GetClubsByLeagueIdAsync(leagueId);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClubDto), StatusCodes.Status201Created)]
        public async Task<IActionResult> Post([FromBody] ClubDto clubDto)
        {
            var response = new FIFAManagerResponse();

            response.Id = await _clubService.InsertClubAsync(clubDto);

            return Ok(response);
        }

    }
}
