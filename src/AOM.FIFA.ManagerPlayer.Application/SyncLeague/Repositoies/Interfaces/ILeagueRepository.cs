using System.Threading.Tasks;
using domain = AOM.FIFA.ManagerPlayer.Application.League.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.SyncLeague.Repositoies.Interfaces
{
    public  interface ILeagueRepository
    {
        Task<bool> InsertAsync(domain.League league);
    }
}
