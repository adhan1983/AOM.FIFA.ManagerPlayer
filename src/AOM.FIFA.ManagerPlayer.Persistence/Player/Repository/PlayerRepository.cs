using AOM.FIFA.ManagerPlayer.Persistence.Base;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using p = AOM.FIFA.ManagerPlayer.Application.Player.Entities;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Persistence.Player.Repository
{
    public class PlayerRepository : Repository<p.Player>, IPlayerRepository
    {
        public PlayerRepository(FIFAManagerPlayerDbContext fifaManagerPlayerDbContext) : base(fifaManagerPlayerDbContext)
        {
        }
    }
}
