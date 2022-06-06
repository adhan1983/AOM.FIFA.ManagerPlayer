using Grpc.Core;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.gRPCServer.Services.Interfaces
{
    public interface IClubgRPCService
    {
        Task<ClubReply> InsertClub(ClubRequest request, ServerCallContext context);
    }
}
