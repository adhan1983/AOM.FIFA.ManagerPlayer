using Grpc.Core;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using AOM.FIFA.ManagerPlayer.Application.League.Dtos;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AOM.FIFA.ManagerPlayer.gRPCServer.Services
{
    public class LeaguegRPCService : League.LeagueBase, ILeaguegRPCService
    {
        private readonly ILogger<LeaguegRPCService> _logger;

        private readonly ILeagueService _leagueService;
        
        public LeaguegRPCService(ILogger<LeaguegRPCService> logger, ILeagueService leagueService)
        {
            _logger = logger;
            _leagueService = leagueService;
        }

        [Authorize]
        public override async Task<LeagueReply> InsertLeague(LeagueRequest request, ServerCallContext context)
        {
            var result = await _leagueService.InsertLeagueAsync(new LeagueDto 
            {
                Name = request.Name,
                SourceId = request.SourceId
            });

            return new LeagueReply { Id = result.Id };
        }
    }
}
