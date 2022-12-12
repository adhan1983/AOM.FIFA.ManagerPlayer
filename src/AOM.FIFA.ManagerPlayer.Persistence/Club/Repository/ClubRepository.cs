using AOM.FIFA.ManagerPlayer.Persistence.Context;
using repo = AOM.FIFA.ManagerPlayer.Persistence.Base;
using domain = AOM.FIFA.ManagerPlayer.Application.Club.Entities;
using AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AOM.FIFA.ManagerPlayer.Persistence.Club.Repository
{
    public class ClubRepository : repo.Repository<domain.Club>, IClubRepository
    {
        public ClubRepository(FIFAManagerPlayerDbContext fifaManagerPlayerDbContext) : base(fifaManagerPlayerDbContext) { }        
        
        public async Task<List<domain.Club>> GetClubsByLeagueIdAsync(int leagueId)
        {
            var clubs = await _fifaManagerPlayerDbContext.
                              Clubs.
                                Include(x => x.League).
                                Where(a => a.LeagueId == leagueId).
                                ToListAsync();
           

            return clubs;
        }


        public async Task<List<domain.Club>> GetClubsByLeagueAsync()
        {
            var clubs = await _fifaManagerPlayerDbContext.
                              Clubs.
                                Include(x => x.League).                                
                                ToListAsync();

            return clubs;
        }

        public async Task<domain.Club> GetClubBySourceId(int sourceId)
        {
            var models = await this._fifaManagerPlayerDbContext.
                                    Clubs.
                                    FirstOrDefaultAsync(x => x.SourceId == sourceId);

            return models;
        }
    }
    
}