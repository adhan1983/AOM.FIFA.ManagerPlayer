using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Base.Repository.Pagination;
using AOM.FIFA.ManagerPlayer.Application.League.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories
{
    public  interface ILeagueRepository : IRepository<domain.League>
    {
        
        Task<List<domain.League>> GetLeaguesByParametersAsync(LeagueParametersRequest leagueParameters);

        Task<PagedList<domain.League>> GetPagedListLeaguesAsync(LeagueParametersRequest leagueParameters);
    }
}
