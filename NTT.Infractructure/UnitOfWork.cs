using Microsoft.EntityFrameworkCore;
using NTT.Domain.Base;
using NTT.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Infractructure
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly Context _dbContext;
        private readonly Dictionary<Type, object> repositories;

        public UnitOfWork(Context dbContext)
        {
            _dbContext = dbContext;
            repositories = new Dictionary<Type, object>();
        }
        public void BeginTransaction()
        {
            _dbContext.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _dbContext.Database.CommitTransaction();
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : CoreBaseEntity
        {
            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
                repositories.Add(type, new Repository<TEntity>(_dbContext));
            return (IRepository<TEntity>)repositories[type];
        }
        public void RollBackTransaction()
        {
            _dbContext.Database.RollbackTransaction();
        }
        public bool SaveChange()
        {
            return _dbContext.SaveChanges() > 0;
        }
        public async Task<bool> SaveChangeAsync()
        {
            return (await _dbContext.SaveChangesAsync()) > 0;
        }

    }
}
