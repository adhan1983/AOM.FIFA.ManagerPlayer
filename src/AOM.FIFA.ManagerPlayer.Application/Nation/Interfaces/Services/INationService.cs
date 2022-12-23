using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Nation.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Nation.Responses;

namespace AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services
{
    public interface INationService
    {
        Task<int> InsertNationAsync(NationDto nationDto);

        Task<NationDto> GetNationBySourceId(int sourceId);
        
        Task<NationResponse> GetNationResponseAsync();
    }
}
