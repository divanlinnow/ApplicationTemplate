using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ORM.EF.Repositories
{
    public class GenericRepository : IRepository
    {
        internal DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TEntity> All<TEntity>() where TEntity : class
        {
            return context.Set<TEntity>().AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            IEnumerable<TEntity> results = context.Set<TEntity>().AsNoTracking().Where(predicate).ToList();
            return results;
        }

        public TEntity FindById<TEntity>(int id) where TEntity : class
        {
            Expression<Func<TEntity, bool>> lambda = RepositoryUtility.BuildLambdaForFindByKey<TEntity>(id);
            return context.Set<TEntity>().AsNoTracking().SingleOrDefault(lambda);
        }

        public bool Insert<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Add(entity);
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
            return true;
        }

        public bool Update<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return true;
        }

        public bool Delete<TEntity>(int id) where TEntity : class
        {
            var entity = FindById<TEntity>(id);
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
            return true;
        }

        public bool Delete<TEntity>(TEntity entity) where TEntity : class
        {
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}