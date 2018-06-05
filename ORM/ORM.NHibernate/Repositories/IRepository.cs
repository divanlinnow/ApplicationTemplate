using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ORM.NHibernate.Repositories
{
    public interface IRepository
    {
        IEnumerable<TEntity> All<TEntity>() where TEntity : class;

        IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        TEntity FindById<TEntity>(Guid id) where TEntity : class;

        void Save(object entity);

        void Save(IEnumerable<object> entities);

        void Delete<TEntity>(Guid id) where TEntity : class;

        void Delete<TEntity>(TEntity entity) where TEntity : class;
        
    }
}