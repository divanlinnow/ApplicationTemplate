using Domain.Entities.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.EF.Contexts;
using ORM.EF.Repositories;
using System.Data.Entity;
using System.Diagnostics;
using System.Text;

namespace ORM.EF.Tests
{
    // TODO: Complete unit testing
    [Ignore]
    [TestClass]
    public class GenericRepositoryTests
    {
        private StringBuilder log = new StringBuilder();
        private CoreContext context;
        private GenericRepository repository;

        private void SetLog(string message)
        {
            log.Append(message);
        }

        [TestInitialize]
        public void Init()
        {
            Database.SetInitializer(new NullDatabaseInitializer<CoreContext>());
            context = new CoreContext();
            repository = new GenericRepository(context);
            context.Database.Log = SetLog;
        }

        [TestMethod]
        [TestCategory("Repositories - Generic - EF")]
        public void GenericRepository_All()
        {
            // Can pass in any type of T to the method.
            var results = repository.All<Country>();
            Debug.WriteLine(log.ToString());
            Assert.IsNotNull(results);
            Assert.IsTrue(log.ToString().Contains("FROM [AppTemplate].[Countries]"));
        }

        [TestMethod]
        [TestCategory("Repositories - Generic - EF")]
        public void GenericRepository_FindBy_WithDynamicLambda()
        {
            // Can pass in any type of T to the method.
            var results = repository.FindBy<Country>(x => x.Name == "Test Entity");
            Debug.WriteLine(log.ToString());
            Assert.IsTrue(log.ToString().Contains("WHERE N'Test Entity' = [Extent1].[Name]"));
        }

        [TestMethod]
        [TestCategory("Repositories - Generic - EF")]
        public void GenericRepository_FindById()
        {
            // Can pass in any type of T to the method.
            var results = repository.FindById<Country>(9999);
            Debug.WriteLine(log.ToString());
            Assert.IsTrue(log.ToString().Contains("FROM [AppTemplate].[Countries]"));
        }

        [TestMethod]
        [TestCategory("Repositories - Generic - EF")]
        public void GenericRepository_Insert()
        {
            var testEntity = new Country
            {
                ID = 9999,
                ISOCode = "TC",
                Abbreviation = "TC",
                Name = "Test Country"
            };

            repository.Insert(testEntity);

            Assert.IsNotNull(context.Countries.Local);
            Assert.IsTrue(context.Countries.Local.Count >= 1);
        }
    }
}