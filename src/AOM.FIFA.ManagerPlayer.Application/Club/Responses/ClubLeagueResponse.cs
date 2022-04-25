using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Responses
{
    public class ClubLeagueResponse
    {
        public int Total { get; set; }
        
        public string NameLeague { get; set; }
        
        public List<ClubLeagueDto> Clubs { get; set; }
    }
}
