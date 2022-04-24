using AOM.FIFA.ManagerPlayer.Persistence.Context;
using repo = AOM.FIFA.ManagerPlayer.Persistence.Base;
using domain = AOM.FIFA.ManagerPlayer.Application.League.Entities;
using AOM.FIFA.ManagerPlayer.Application.League.Services.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Persistence.League.Repository
{
    public class LeagueRepository : repo.Repository<domain.League>, ILeagueRepository
    {
        
        protected FIFAManagerPlayerDbContext _dbContext;
        public LeagueRepository(FIFAManagerPlayerDbContext dbContext) : base(dbContext)
        { }

    }
}
