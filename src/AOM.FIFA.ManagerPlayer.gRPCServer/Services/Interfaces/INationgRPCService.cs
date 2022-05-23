using Grpc.Core;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces
{
    public interface INationgRPCService
    {
        Task<NationReply> InsertNation(NationRequest request, ServerCallContext context);
    }
}
