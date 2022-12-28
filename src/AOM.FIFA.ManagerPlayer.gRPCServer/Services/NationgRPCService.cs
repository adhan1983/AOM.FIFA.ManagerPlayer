using AOM.FIFA.ManagerPlayer.Application.Nation.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.gRPCServer.Services
{
    public class NationgRPCService : Nation.NationBase, INationgRPCService
    {
        private readonly INationService _nationService;
        public NationgRPCService(INationService nationService) => this._nationService = nationService;

        [Authorize]
        public override async Task<NationReply> InsertNation(NationRequest request, ServerCallContext context)
        {
            var result = await _nationService.InsertNationAsync(new NationDto
            {
                Name = request.Name,
                SourceId = request.SourceId
            });

            return new NationReply { Id = result };
        }

    }
}
