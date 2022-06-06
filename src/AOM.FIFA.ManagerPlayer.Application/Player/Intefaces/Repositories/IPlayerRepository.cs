using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Application.Player.Requests;
using domain = AOM.FIFA.ManagerPlayer.Application.Player.Entities;
using AOM.FIFA.ManagerPlayer.Application.Base.Repository.Pagination;

namespace AOM.FIFA.ManagerPlayer.Application.Player.Intefaces.Repositories
{
    public interface IPlayerRepository : IRepository<domain.Player>
    {
        Task<domain.Player> GetPlayerByExpression(Expression<Func<domain.Player, bool>> expression);

        Task<PagedList<domain.Player>> GetPagedListPlayersAsync(PlayerParameterRequest leagueParameters);

        Task<List<domain.Player>> GetPlayersByExpression(Expression<Func<domain.Player, bool>> expression);
        
        Task<int> InsertAndUpdatePlayerAsync(domain.Player playerInsert, List<domain.Player> playerUpdate);

    }
}
