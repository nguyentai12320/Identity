using Microsoft.EntityFrameworkCore;
using NTT.Domain.Base;
using NTT.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Infractructure
{
    public class Repository<T> : IRepository<T> where T : CoreBaseEntity
    {
        protected readonly Context _context;
        protected DbSet<T> _dbSet => _context.Set<T>();
        public Repository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        } //done

        public async Task AddRangeAsync(IEnumerable<T> entities) //done
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public void Delete(T entity) //done
        {
            _dbSet.Remove(entity);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).Any();
        } //done

        public async Task<bool> DeleteRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
            return await _context.SaveChangesAsync() > 0;
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> precicate)
        {
            return _dbSet.Where(precicate);
        }

        public async Task<IList<T>> GetAsync(Expression<Func<T, bool>> precicate) //done
        {
            return await _dbSet.Where(precicate).ToListAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            var result = (await _dbSet.AddAsync(entity)).Entity;
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        } //modify

        public async Task<bool> UpdateRangeAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            return await _context.SaveChangesAsync() > 0;
        }//modify

        public async Task<T> FindAsync(long id)
        {
            return await _dbSet.FindAsync(id);
        } //done

        public IQueryable<T> GetAll() //done
        {
            return _dbSet.AsQueryable();
        }

        public async Task<IList<T>> GetAllAsync() //done
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> precicate) //done
        {
            return await _dbSet.FirstOrDefaultAsync(precicate);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
    }
}
