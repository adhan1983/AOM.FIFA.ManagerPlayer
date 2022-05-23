using Grpc.Core;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces
{
    public interface ILeaguegRPCService
    {
        Task<LeagueReply> InsertLeague(LeagueRequest request, ServerCallContext context);
    }
}
