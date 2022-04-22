using AOM.FIFA.ManagerPlayer.Application.League.Entities;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Repositories.Interfaces;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using repo = AOM.FIFA.ManagerPlayer.Persistence.Base;

namespace AOM.FIFA.ManagerPlayer.Persistence.SyncLeague.Repository
{
    public class LeagueRepository : repo.Repository<League>, ILeagueRepository
    {
        
        protected FIFAManagerPlayerDbContext _dbContext;
        public LeagueRepository(FIFAManagerPlayerDbContext dbContext) : base(dbContext)
        { }
    }
}
