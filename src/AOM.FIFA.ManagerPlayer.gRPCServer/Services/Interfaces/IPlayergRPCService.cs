using Grpc.Core;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces
{
    public interface IPlayergRPCService
    {
        Task<PlayerReply> InsertPlayer(PlayerRequest request, ServerCallContext context);
    }
}
