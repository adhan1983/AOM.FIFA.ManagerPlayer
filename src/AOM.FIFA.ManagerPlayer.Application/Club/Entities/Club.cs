using domainLeague = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Entities
{
    public class Club
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public domainLeague.League League { get; set; }

        public int LeagueId { get; set; }

        public int SourceId { get; set; }
    }
}
