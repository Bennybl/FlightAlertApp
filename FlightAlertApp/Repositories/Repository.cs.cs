using FlightAlertApp.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FlightAlertApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext r_context;
        protected readonly DbSet<T> r_dbSet;

        public Repository(ApplicationDbContext context)
        {
            r_context = context;
            r_dbSet = context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await r_dbSet.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await r_dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await r_dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            await r_dbSet.AddAsync(entity);
            await r_context.SaveChangesAsync();
        }

        public virtual Task UpdateAsync(T entity)
        {
            r_dbSet.Attach(entity);
            r_context.Entry(entity).State = EntityState.Modified;
            r_context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public virtual Task DeleteAsync(T entity)
        {
            r_dbSet.Remove(entity);
            r_context.SaveChangesAsync();
            return Task.CompletedTask;
        }

    }
}