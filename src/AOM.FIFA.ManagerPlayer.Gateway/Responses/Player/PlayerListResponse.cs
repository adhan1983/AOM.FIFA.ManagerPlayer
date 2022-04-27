using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Gateway.Responses.Base;

namespace AOM.FIFA.ManagerPlayer.Gateway.Responses.Player
{
    public class PlayerListResponse : BaseResponse
    {
        public List<Player> items { get; set; } = new();
    }

    public class Player
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string common_name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public int nation { get; set; }
        public int? club { get; set; }
        public int? league { get; set; }
        public int? rarity { get; set; }

    }
}


	

	
