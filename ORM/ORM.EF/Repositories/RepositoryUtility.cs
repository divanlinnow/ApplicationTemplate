using System;
using System.Linq.Expressions;

namespace ORM.EF.Repositories
{
    public static class RepositoryUtility
    {
        public static Expression<Func<TEntity, bool>> BuildLambdaForFindByKey<TEntity>(int ID)
        {
            var item = Expression.Parameter(typeof(TEntity), "entity");
            var prop = Expression.Property(item, "ID");
            var value = Expression.Constant(ID);
            var equal = Expression.Equal(prop, value);
            var lambda = Expression.Lambda<Func<TEntity, bool>>(equal, item);
            return lambda;
        }
    }
}