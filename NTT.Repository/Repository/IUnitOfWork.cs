using NTT.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTT.Repository.Repository
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void CommitTransaction();
        IRepository<TEntity> Repository<TEntity>() where TEntity : CoreBaseEntity;
        void RollBackTransaction();
        bool SaveChange();
        Task<bool> SaveChangeAsync();
    }
}
