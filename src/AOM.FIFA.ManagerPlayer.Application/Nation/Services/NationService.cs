using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Nation.Dtos;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Services;
using entity = AOM.FIFA.ManagerPlayer.Application.Nation.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Nation.Services
{
    public class NationService : INationService
    {
        private readonly INationRepository _nationRepository;

        public NationService(INationRepository nationRepository)
        {
            this._nationRepository = nationRepository;
        }
        
        public async Task<int> InsertNationAsync(NationDto nationDto)
        {
            var model = new entity.Nation { Name = nationDto.Name, SourceId = nationDto.SourceId };

            var result = await _nationRepository.InsertAsync(model);

            return result.Id;
        }

        public async Task<NationDto> GetNationBySourceId(int sourceId)
        {
            var model = await _nationRepository.GetNationBySourceId(sourceId);

            var clubDto = new NationDto { Id = model.Id, Name = model.Name, SourceId = model.SourceId };
            
            return clubDto;
        }
    }
}
