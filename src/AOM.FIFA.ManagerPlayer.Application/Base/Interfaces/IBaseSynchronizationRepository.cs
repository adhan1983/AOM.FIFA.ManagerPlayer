using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Application.Base.Interfaces
{
    public interface IBaseSynchronizationRepository<T>
    {
        Task<List<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task<bool> InsertAsync(T entity);

        Task<bool> UpdateAsync(T entity);
    }
}
