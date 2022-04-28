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
        protected FIFASynchronizationDbContext _dbContext;

        public BaseSynchronizationRepository(FIFASynchronizationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await this._dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> InsertAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);

            return Convert.ToBoolean(await _dbContext.SaveChangesAsync());
        }
    }
}
