using NHibernate;

namespace ORM.NHibernate.Repositories
{
    public interface ISessionHelper
    {
        ISession GetActiveSession();
    }
}