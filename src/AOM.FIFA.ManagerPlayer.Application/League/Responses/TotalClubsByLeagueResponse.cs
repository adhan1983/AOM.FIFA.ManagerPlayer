using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.League.Dtos;

namespace AOM.FIFA.ManagerPlayer.Application.League.Responses
{
    public class TotalClubsByLeagueResponse
    {
        public TotalClubsByLeagueResponse()
        {
            ClubsByLeague = new List<ClubByLeagueDto>();
        }

        public List<ClubByLeagueDto> ClubsByLeague { get; set; }
    }
}
