using System.Collections.Generic;
using domainLeague = AOM.FIFA.ManagerPlayer.Application.League.Entities;
using domainPlayer = AOM.FIFA.ManagerPlayer.Application.Player.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Entities
{
    public class Club
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public domainLeague.League League { get; set; }

        public int LeagueId { get; set; }

        public int SourceId { get; set; }

        public List<domainPlayer.Player> Players { get; set; }
    }
}
