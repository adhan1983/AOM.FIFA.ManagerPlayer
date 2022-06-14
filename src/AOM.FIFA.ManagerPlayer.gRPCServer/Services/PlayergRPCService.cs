using Grpc.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using AOM.FIFA.ManagerPlayer.Application.Player.Dtos;
using AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Services;

namespace AOM.FIFA.ManagerPlayer.gRPCServer.Services
{
    public class PlayergRPCService : Player.PlayerBase, IPlayergRPCService
    {
        private readonly ILogger<PlayergRPCService> _logger;

        private readonly IPlayerService _playerService;
        
        public PlayergRPCService(ILogger<PlayergRPCService> logger, IPlayerService playerService)
        {
            _logger = logger;
            _playerService = playerService;
        }
        
        [Authorize]
        public override async Task<PlayerReply> InsertPlayer(PlayerRequest request, ServerCallContext context)
        {
            PlayerDto dto = MapToPlayerDto(request);

            var result = await _playerService.InsertPlayerAsync(dto);

            return new PlayerReply { Id = result };
        }

        private static PlayerDto MapToPlayerDto(PlayerRequest request)
        {
            return new PlayerDto
            {
                Name = request.Name,
                Age = request.Age,
                AttackWorkRate = request.AttackWorkRate,
                ClubId = request.SourceClubId,
                CommonName = request.CommonName,
                Defending = request.Defending,
                DefenseWorkRate = request.DefenseWorkRate,
                Dribbling = request.Dribbling,
                Foot = request.Foot,
                Height = request.Height,
                LastName = request.LastName,
                //NationId = request.SourceNationId,
                Pace = request.Pace,
                Passing = request.Passing,
                Physicality = request.Physicality,
                Position = request.Position,
                Rarity = request.Rarity,
                Rating = request.Rating,
                Shooting = request.Shooting,
                SourceId = request.SourceId,
                TotalStats = request.TotalStats,
                Weight = request.Weight,
                SourceClubId = request.SourceClubId,
                SourceNationId = request.SourceNationId,
            };
        }
    }
}
