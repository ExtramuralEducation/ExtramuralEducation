using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ExtramuralEducation.Repository.Contracts
{
    public interface IRepository<TEntity>
    {
        TEntity Get(object ID);

        bool IsEntityExist(object ID);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(object ID);

        void Commit();
    }
}
