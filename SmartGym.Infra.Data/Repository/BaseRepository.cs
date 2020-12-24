using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using SmartGym.Domain.Entities;
using SmartGym.Infra.Data.Context;
using System.Linq;

namespace SmartGym.Infra.Data
{
    public class BaseRepository<TEntity, TKeyType> where TEntity : BaseEntity<TKeyType>
    {
        protected readonly SqlServerDbContext _sqlServerDbContext;

        public BaseRepository(SqlServerDbContext sqlServerDbContext)
        {
            _sqlServerDbContext = sqlServerDbContext;
        }

        protected virtual void Insert(TEntity obj)
        {
            _sqlServerDbContext.Set<TEntity>().Add(obj);
            _sqlServerDbContext.SaveChanges();
        }

        protected virtual void Update(TEntity obj)
        {
            _sqlServerDbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _sqlServerDbContext.SaveChanges();
        }

        protected virtual void Update<TProperty>(TEntity obj, params PropertyEntry<TEntity, TProperty>[] propsToIgnore)
        {
            _sqlServerDbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            foreach (var item in propsToIgnore)
                item.IsModified = false;

            _sqlServerDbContext.SaveChanges();
        }

        protected virtual void Delete(int id)
        {
            _sqlServerDbContext.Set<TEntity>().Remove(Select(id));
            _sqlServerDbContext.SaveChanges();
        }

        protected virtual IList<TEntity> Select() =>
            _sqlServerDbContext.Set<TEntity>().ToList();

        protected virtual TEntity Select(int id) =>
            _sqlServerDbContext.Set<TEntity>().Find(id);
    }

}
