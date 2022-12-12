using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Base.Repository.Pagination;
using AOM.FIFA.ManagerPlayer.Application.League.Requests;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using domain = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories
{
    public  interface ILeagueRepository : IRepository<domain.League>
    {
        
        Task<List<domain.League>> GetLeaguesByParametersAsync(LeagueParametersRequest leagueParameters);

        Task<PagedList<domain.League>> GetPagedListLeaguesAsync(LeagueParametersRequest leagueParameters);

        Task<domain.League> GetLeagueBySourceId(int sourceId);

        Task<List<domain.League>> GetLeaguesByExpression(Expression<Func<domain.League, bool>> expression);

        Task<List<domain.League>> GetLeaguesAsync();

    }
}
