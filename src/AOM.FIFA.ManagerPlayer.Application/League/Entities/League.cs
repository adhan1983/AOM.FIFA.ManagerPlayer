using System.Collections.Generic;
using domainClub = AOM.FIFA.ManagerPlayer.Application.Club.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.League.Entities
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SourceId { get; set; }
        public ICollection<domainClub.Club> Clubs { get; set; }

    }
}
