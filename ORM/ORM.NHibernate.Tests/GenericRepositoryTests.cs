using Domain.Entities.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.NHibernate.Repositories;

namespace ORM.NHibernate.Tests
{
    [TestClass]
    public class GenericRepositoryTests
    {
        private GenericRepository repository;

        [TestInitialize]
        public void Init()
        {
            repository = new GenericRepository(new SessionHelper());
        }

        // TODO: Complete unit testing NHibernate Generic Repository
        [TestMethod]
        [Ignore]
        [TestCategory("Repositories - Generic - NHibernate")]
        public void GenericRepository_All()
        {
            // Can pass in any type of T to the method.
            var results = repository.All<Country>();
            Assert.IsNotNull(results);
        }
    }
}