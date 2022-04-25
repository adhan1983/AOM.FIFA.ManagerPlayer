using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using domain = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.League.Interfaces.Repositories
{
    public  interface ILeagueRepository : IRepository<domain.League>
    {
        //custom operations here
        //Task<T>> GetLeagueByName(string leagueName);
    }
}
