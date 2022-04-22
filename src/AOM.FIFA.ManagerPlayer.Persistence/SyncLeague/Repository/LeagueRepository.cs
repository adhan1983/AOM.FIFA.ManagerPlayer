using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using AOM.FIFA.ManagerPlayer.Application.League.Entities;
using AOM.FIFA.ManagerPlayer.Application.SyncLeague.Repositoies.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Persistence.SyncLeague.Repository
{
    public class LeagueRepository : ILeagueRepository
    {
        
        protected FIFAManagerPlayerDbContext _dbContext;
        
        public LeagueRepository(FIFAManagerPlayerDbContext dbContext) => _dbContext = dbContext;
        
        public async Task<bool> InsertAsync(League league)
        {
            await _dbContext.Leagues.AddAsync(league);
            
            return Convert.ToBoolean(await  _dbContext.SaveChangesAsync());
        }

        public async Task<bool> InsertManyAsync(List<League> leagues)
        {
            await _dbContext.Leagues.AddRangeAsync(leagues);

            return Convert.ToBoolean(await _dbContext.SaveChangesAsync());
        }
    }
}
