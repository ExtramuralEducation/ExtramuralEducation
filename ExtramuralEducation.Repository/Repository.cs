using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using ExtramuralEducation.Models;
using ExtramuralEducation.Repository.Contracts;

namespace ExtramuralEducation.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbContext _context;

        public Repository(DbContext context)
        {
            this._context = context;
        }

        private DbSet<TEntity> DbSet
        {
            get { return _context.Set<TEntity>(); }
        }

        public TEntity Get(object ID)
        {
            return DbSet.Find(ID);
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            var dbEntity = this.Get(entity.Id);

            if (dbEntity != null)
            {
                this._context.Entry(dbEntity).CurrentValues.SetValues(dbEntity);
            }

            throw new ObjectNotFoundException("Entity not found.");
        }

        public void Delete(object ID)
        {
            var dbEntity = this.Get(ID);

            if (dbEntity != null)
            {
                DbSet.Remove(dbEntity);
            }
        }

        public bool IsEntityExist(object ID)
        {
            return this.Get(ID) != null;
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }
    }
}
