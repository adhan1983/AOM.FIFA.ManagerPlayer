using System.Linq;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Base.Response;
using AOM.FIFA.ManagerPlayer.Application.Nation.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services;
using AOM.FIFA.ManagerPlayer.Application.Nation.Responses;
using entity = AOM.FIFA.ManagerPlayer.Application.Nation.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Nation.Services
{
    public class NationService : INationService
    {
        private readonly INationRepository _nationRepository;

        public NationService(INationRepository nationRepository) => this._nationRepository = nationRepository;
        
        public async Task<FIFAManagerResponse> InsertNationAsync(NationDto nationDto)        
        {
            var modelNation = await _nationRepository.GetNationBySourceId(nationDto.SourceId);

            if (modelNation != null)
            {
                return new FIFAManagerResponse() { Id = 0, Status = false, Message = "This league has been included" };
            }            
            
            var model = new entity.Nation { Name = nationDto.Name, SourceId = nationDto.SourceId };
            
            var result = await _nationRepository.InsertAsync(model);

            return new FIFAManagerResponse { Id = result.Id, Status = true, Message = "Success" };
        }

        public async Task<NationDto> GetNationBySourceId(int sourceId)
        {
            var model = await _nationRepository.GetNationBySourceId(sourceId);
            if (model == null)
                return  null;

            var clubDto = new NationDto { Id = model.Id, Name = model.Name, SourceId = model.SourceId };
            
            return clubDto;
        }

        public async Task<NationResponse> GetNationResponseAsync()
        {
            var models = await _nationRepository.GetAllAsync();
            
            var response = new NationResponse();

            response.Nations.AddRange(models.Select(model => new NationDto { Id = model.Id, Name = model.Name, SourceId = model.SourceId }).ToList());

            response.Total = models.Count;

            return response;
        }
    }
}
