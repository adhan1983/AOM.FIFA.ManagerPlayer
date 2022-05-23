using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain = AOM.FIFA.ManagerPlayer.Application.Club.Entities;

namespace AOM.FIFA.ManagerPlayer.Application.Club.Interfaces.Repositories
{
    public interface IClubRepository : IRepository<domain.Club>
    {
        Task<List<domain.Club>> GetClubsByLeagueIdAsync(int leagueId);

        Task<domain.Club> GetClubBySourceId(int sourceId);
    }
}
