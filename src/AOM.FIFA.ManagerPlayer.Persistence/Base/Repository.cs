using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AOM.FIFA.ManagerPlayer.Persistence.Context;
using AOM.FIFA.ManagerPlayer.Application.Base.Interfaces;
using System.Linq.Expressions;

namespace AOM.FIFA.ManagerPlayer.Persistence.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly FIFAManagerPlayerDbContext _fifaManagerPlayerDbContext;
        public Repository(FIFAManagerPlayerDbContext fifaManagerPlayerDbContext)
        {
            _fifaManagerPlayerDbContext = fifaManagerPlayerDbContext;
        }
        public async Task<T> InsertAsync(T entity)
        {
            await _fifaManagerPlayerDbContext.Set<T>().AddAsync(entity);
            await _fifaManagerPlayerDbContext.SaveChangesAsync();
            return entity;
        }        
        public async Task<bool> InsertManyAsync(List<T> entities)
        {            
            await _fifaManagerPlayerDbContext.Set<T>().AddRangeAsync(entities);            
            var result = Convert.ToBoolean(await _fifaManagerPlayerDbContext.SaveChangesAsync());            
            return result;
        }
        public async Task DeleteAsync(T entity)
        {
            _fifaManagerPlayerDbContext.Set<T>().Remove(entity);
            await _fifaManagerPlayerDbContext.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _fifaManagerPlayerDbContext.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _fifaManagerPlayerDbContext.Set<T>().FindAsync(id);
        }       

        //TO DO: Testar
        public async Task<IReadOnlyList<T>> GetAllByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return (IReadOnlyList<T>)await _fifaManagerPlayerDbContext.Set<T>().FindAsync(expression);
        }
        
        public async Task<bool> UpdateAsync(T entity)
        {
            _fifaManagerPlayerDbContext.Set<T>().Update(entity);

            return Convert.ToBoolean(await _fifaManagerPlayerDbContext.SaveChangesAsync());
        }
    }
}
