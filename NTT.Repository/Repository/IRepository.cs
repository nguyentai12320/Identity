using NTT.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Repository.Repository
{
    public interface IRepository<T> where T : CoreBaseEntity
    {
        Task<T> FindAsync(long id);
        IQueryable<T> Get(Expression<Func<T, bool>> precicate);
        Task<IList<T>> GetAsync(Expression<Func<T, bool>> precicate);
        IQueryable<T> GetAll();
        Task<T> InsertAsync(T entity);
        Task AddAsync(T entity);
        void Add(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<bool> UpdateAsync(T entity);
        Task<bool> UpdateRangeAsync(IEnumerable<T> entities);
        void Delete(T entity);
        Task<bool> DeleteRangeAsync(IEnumerable<T> entities);
        Task<IList<T>> GetAllAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> precicate);
        bool Any(Expression<Func<T, bool>> predicate);
    }
}
