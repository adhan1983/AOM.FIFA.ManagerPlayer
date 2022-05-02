using System.Collections.Generic;
using p = AOM.FIFA.ManagerPlayer.Application.Player.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Nation.Entities
{
    public class Nation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SourceId { get; set; }
        public List<p.Player> Players { get; set; }
    }
}
