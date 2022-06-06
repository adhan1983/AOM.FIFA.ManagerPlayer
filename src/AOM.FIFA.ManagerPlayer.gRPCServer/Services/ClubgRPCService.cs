using Grpc.Core;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Club.Dtos;
using AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Services;

namespace AOM.FIFA.ManagerPlayer.gRPCServer.Services
{
    public class ClubgRPCService : Club.ClubBase, IClubgRPCService
    {
        private readonly IClubService _clubService;
        public ClubgRPCService(IClubService clubService) => this._clubService = clubService;
        public override async Task<ClubReply> InsertClub(ClubRequest request, ServerCallContext context)
        {
            var clubDto = new ClubDto 
            {
                SourceId = request.SourceId,
                SourceLeagueId = request.SourceLeagueId,
                Name = request.Name,                
            };

            var result = await _clubService.InsertClubAsync(clubDto);

            return new ClubReply { Id = result };
        }

    }

}
