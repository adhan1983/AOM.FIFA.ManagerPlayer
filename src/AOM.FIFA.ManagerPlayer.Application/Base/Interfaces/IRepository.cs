﻿using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace AOM.FIFA.ManagerPlayer.Application.Base.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<bool> InsertManyAsync(List<T> entities);        
        Task<T> GetByIdAsync(int id);
        Task<T> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByExpressionAsync(Expression<Func<T, bool>> expression);
    }
}
