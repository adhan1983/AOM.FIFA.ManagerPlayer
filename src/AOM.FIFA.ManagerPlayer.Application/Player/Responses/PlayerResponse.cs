using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Responses
{
    public class PlayerResponse
    {
        public PlayerResponse()
        {
            this.Player = new PlayerDto();
        }

        public PlayerDto Player { get; set; }

    }
}
