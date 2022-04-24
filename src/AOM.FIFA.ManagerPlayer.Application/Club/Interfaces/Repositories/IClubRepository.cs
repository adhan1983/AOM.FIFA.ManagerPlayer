using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using domain = AOM.FIFA.ManagerPlayer.Application.Club.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories
{
    public interface IClubRepository : IRepository<domain.Club>
    {
    }
}
