using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.League.Dtos;

namespace AOM.FIFA.ManagerPlayer.Application.League.Responses
{
    public class LeaguesResponse
    {
        public LeaguesResponse()
        {
            Leagues = new List<LeagueDto>();
        }

        public int Total { get; set; }
        public List<LeagueDto> Leagues { get; set; }
    }
}
