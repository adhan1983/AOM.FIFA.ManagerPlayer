using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using repo = AOM.FIFA.ManagerPlayer.Persistence.Base;
using AOM.FIFA.ManagerPlayer.Application.League.Requests;
using domain = AOM.FIFA.ManagerPlayer.Application.League.Entities;
using AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories;
using AOM.FIFA.ManagerPlayer.Application.Base.Repository.Pagination;
using System;
using System.Linq.Expressions;

namespace AOM.FIFA.ManagerPlayer.Persistence.League.Repository
{
    public class LeagueRepository : repo.Repository<domain.League>, ILeagueRepository
    {       
        
        public LeagueRepository(FIFAManagerPlayerDbContext dbContext) : base(dbContext)
        { }

        public async Task<List<domain.League>> GetLeaguesByParametersAsync(LeagueParametersRequest leagueParameters)
        {
            var models = await this._fifaManagerPlayerDbContext.
                                Leagues.
                                OrderBy(x => x.Name).
                                Skip((leagueParameters.PageNumber - 1) * leagueParameters.PageSize).
                                Take(leagueParameters.PageSize).
                                ToListAsync();

            return models;
        }

        public async Task<PagedList<domain.League>> GetPagedListLeaguesAsync(LeagueParametersRequest leagueParameters)
        {
            var models = await PagedList<domain.League>.ToPagedListAsync(this._fifaManagerPlayerDbContext.
                                Leagues.OrderBy(x => x.Name), leagueParameters.PageNumber, leagueParameters.PageSize);                                                                

            return models;
        }

        public async Task<domain.League> GetLeagueBySourceId(int sourceId)
        {
            var model = await this._fifaManagerPlayerDbContext.Leagues.FirstOrDefaultAsync(x => x.SourceId == sourceId);

            return model;
        }

        public async Task<List<domain.League>> GetLeaguesByExpression(Expression<Func<domain.League, bool>> expression = null)
        {
            var models = await this._fifaManagerPlayerDbContext.
                                    Leagues.                                    
                                    Include(x => x.Clubs).
                                    ThenInclude(y => y.Players).                                    
                                    Where(expression).
                                    ToListAsync();
            return models;
        }

        public async Task<List<domain.League>> GetLeaguesAsync()
        {
            var models = await this._fifaManagerPlayerDbContext.
                                    Leagues.
                                    Include(x => x.Clubs).                                    
                                    OrderBy(x => x.Name).
                                    ToListAsync();
            return models;
        }
    }
}
