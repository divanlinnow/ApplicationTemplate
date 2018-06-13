using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Cfg;

namespace ORM.NHibernate.Repositories
{
    public static class NhibernateSessionFactory
    {
        private static ISessionFactory sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (sessionFactory == null)
                {
                    var configuration = new Configuration();

                    configuration.AddAssembly(typeof(Entity).Assembly);
                    configuration.Configure();
                    sessionFactory = configuration.BuildSessionFactory();
                }

                return sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}