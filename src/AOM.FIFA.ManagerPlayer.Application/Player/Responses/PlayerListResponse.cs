using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Responses
{
    public class PlayerListResponse
    {
        public PlayerListResponse()
        {
            this.PlayersDto = new List<PlayerDto>();
        }

        public int Total { get; set; }
        public List<PlayerDto> PlayersDto { get; set; }
    }
}
