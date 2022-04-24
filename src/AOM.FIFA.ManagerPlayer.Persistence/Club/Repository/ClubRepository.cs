using AOM.FIFA.ManagerPlayer.Persistence.Context;
using repo = AOM.FIFA.ManagerPlayer.Persistence.Base;
using domain = AOM.FIFA.ManagerPlayer.Application.Club.Entities;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;

namespace AOM.FIFA.ManagerPlayer.Persistence.League.Repository
{
    public class ClubRepository : repo.Repository<domain.Club>, IClubRepository
    {
        
        protected FIFAManagerPlayerDbContext _dbContext;
        public ClubRepository(FIFAManagerPlayerDbContext dbContext) : base(dbContext)
        { }

    }
}
