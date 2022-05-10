using AOM.FIFA.ManagerPlayer.Persistence.Base;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using p = AOM.FIFA.ManagerPlayer.Application.Player.Entities;
using AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Repositories;
using domain = AOM.FIFA.ManagerPlayer.Application.Player.Entities;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Application.Base.Repository.Pagination;
using AOM.FIFA.ManagerPlayer.Application.Player.Requests;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq.Expressions;

namespace AOM.FIFA.ManagerPlayer.Persistence.Player.Repository
{
    public class PlayerRepository : Repository<p.Player>, IPlayerRepository
    {
        public PlayerRepository(FIFAManagerPlayerDbContext fifaManagerPlayerDbContext) : base(fifaManagerPlayerDbContext)
        {
        }

        public async Task<domain.Player> GetPlayerByExpression(Expression<Func<domain.Player, bool>> expression)
        {
            var models = await this._fifaManagerPlayerDbContext.
                                    Players.
                                    Include(x => x.Nation).
                                    Include(x => x.Club).
                                    FirstOrDefaultAsync(expression);

            return models;
        }

        public async Task<PagedList<domain.Player>> GetPagedListPlayersAsync(PlayerParameterRequest leagueParameters)
        {
            var models = await PagedList<domain.Player>.ToPagedListAsync(this._fifaManagerPlayerDbContext.
                               Players.Include(x => x.Nation).Include(x => x.Club).                               
                               OrderBy(x => x.Name), leagueParameters.PageNumber, leagueParameters.PageSize);

            return models;
        }

        public async Task<List<domain.Player>> GetPlayersByExpression(Expression<Func<domain.Player, bool>> expression)
        {
            var models = await this._fifaManagerPlayerDbContext.
                               Players.
                               Include(x => x.Nation).
                               Include(x => x.Club).
                               Where(expression).
                               OrderBy(x => x.Name).
                               ToListAsync();
            return models;
        }        
    }
}
