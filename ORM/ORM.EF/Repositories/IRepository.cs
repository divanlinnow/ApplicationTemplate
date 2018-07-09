using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ORM.EF.Repositories
{
    public interface IRepository
    {
        IEnumerable<TEntity> All<TEntity>() where TEntity : class;

        IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class;

        TEntity FindById<TEntity>(int id) where TEntity : class;

        bool Insert<TEntity>(TEntity entity) where TEntity : class;

        bool Update<TEntity>(TEntity entity) where TEntity : class;

        bool Delete<TEntity>(int id) where TEntity : class;

        bool Delete<TEntity>(TEntity entity) where TEntity : class;
    }
}