using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;
using System.Collections.Generic;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Responses
{
    public class PlayerListFUT22ICONResponse
    {
        public PlayerListFUT22ICONResponse()
        {
            this.Players = new List<PlayerFUT22IconDto>();
        }

        public int Total { get; set; }
        public List<PlayerFUT22IconDto> Players { get; set; }
    }
}
