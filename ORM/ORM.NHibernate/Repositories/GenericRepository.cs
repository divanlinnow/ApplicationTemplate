using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ORM.NHibernate.Repositories
{
    public class GenericRepository : IRepository
    {
        private readonly ISessionHelper sessionHelper;

        private ISession Session
        {
            get { return sessionHelper.GetActiveSession(); }
        }

        public GenericRepository(ISessionHelper sessionHelper)
        {
            this.sessionHelper = sessionHelper;
        }

        public IEnumerable<TEntity> All<TEntity>() where TEntity : class
        {
            return Session.Query<TEntity>();
        }

        public IEnumerable<TEntity> FindBy<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return Session.Query<TEntity>().Where(predicate);
        }

        public TEntity FindById<TEntity>(Guid id) where TEntity : class
        {
            return Session.Load<TEntity>(id);
        }

        public void Save(object entity)
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(entity);
                transaction.Commit();
            }
        }

        public void Save(IEnumerable<object> entities)
        {
            using (var transaction = Session.BeginTransaction())
            {
                foreach (var entity in entities)
                {
                    Session.SaveOrUpdate(entity);
                }

                transaction.Commit();
            }
        }

        public void Delete<TEntity>(Guid id) where TEntity : class
        {
            var entity = Session.Load<TEntity>(id);

            using (var transaction = Session.BeginTransaction())
            {
                Session.Delete(entity);
                transaction.Commit();
            }
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            using (var transaction = Session.BeginTransaction())
            {
                Session.Delete(entity);
                transaction.Commit();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}