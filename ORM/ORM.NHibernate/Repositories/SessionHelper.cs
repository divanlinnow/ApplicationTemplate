using NHibernate;

namespace ORM.NHibernate.Repositories
{
    public class SessionHelper : ISessionHelper
    {
        private ISession session;

        public ISession GetActiveSession()
        {
            if (session == null)
            {
                session = NhibernateSessionFactory.OpenSession();
            }

            return session;
        }
    }
}