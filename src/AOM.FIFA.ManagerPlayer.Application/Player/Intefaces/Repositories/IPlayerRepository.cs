using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using domain = AOM.FIFA.ManagerPlayer.Application.Player.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Repositories
{
    public interface IPlayerRepository : IRepository<domain.Player>
    {
    }
}
