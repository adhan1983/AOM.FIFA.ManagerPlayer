using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using System.Threading.Tasks;
using domain = AOM.FIFA.ManagerPlayer.Application.Nation.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Nation.Interfaces.Repositories
{
    public interface INationRepository : IRepository<domain.Nation>
    {
        Task<domain.Nation> GetNationBySourceId(int sourceId);
    }
}
