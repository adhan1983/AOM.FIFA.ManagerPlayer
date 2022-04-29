using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Context;

namespace AOM.FIFA.ManagerPlayer.Persistence.Synchronization.Base
{
    public abstract class BaseSynchronizationRepository<T> : IBaseSynchronizationRepository<T> where T: class
    {
        protected FIFASynchronizationDbContext _fifaSynchronizationDbContext;

        public BaseSynchronizationRepository(FIFASynchronizationDbContext fifaSynchronizationDbContext)
        {
            this._fifaSynchronizationDbContext = fifaSynchronizationDbContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._fifaSynchronizationDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _fifaSynchronizationDbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> InsertAsync(T entity)
        {
            await _fifaSynchronizationDbContext.Set<T>().AddAsync(entity);

            return Convert.ToBoolean(await _fifaSynchronizationDbContext.SaveChangesAsync());
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _fifaSynchronizationDbContext.Set<T>().Update(entity);

            return Convert.ToBoolean(await _fifaSynchronizationDbContext.SaveChangesAsync());
        }

    }
}
