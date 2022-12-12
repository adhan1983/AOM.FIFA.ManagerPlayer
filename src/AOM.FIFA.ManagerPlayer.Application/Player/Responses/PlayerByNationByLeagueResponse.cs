using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Responses
{
    public class PlayerByNationByLeagueResponse
    {
        public PlayerByNationByLeagueResponse()
        {
            PlayersByNationByLeague = new List<PlayerByNationByLeagueDto>();
        }
        
        public List<PlayerByNationByLeagueDto> PlayersByNationByLeague { get; set; }

        public int Total { get; set; }
    }
}
