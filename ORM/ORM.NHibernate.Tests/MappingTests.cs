using Domain.Entities.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORM.NHibernate.Repositories;
using System.Linq;

namespace ORM.NHibernate.Tests
{
    // TODO: Unit tests here are still in development. Not completed yet. 
    //[TestClass]
    //public class MappingTests
    //{
    //    private GenericRepository repository;

    //    [TestInitialize]
    //    public void Init()
    //    {
    //        repository = new GenericRepository(new SessionHelper());
    //    }

    //    private void TestMapping<T>(T instance = null) where T : EntityBase
    //    {
    //        if (instance != null)
    //        {
    //            repository.Save(instance);
    //        }

    //        var result = repository.All<T>().ToList();
    //        Assert.IsTrue(result.Any() && result.First() != null);

    //        if (instance != null)
    //        {
    //            repository.Delete<T>(instance.ID);
    //        }
    //    }

    //    [TestMethod]
    //    public void EnsureMappingsAreCorrect()
    //    {
    //        TestMapping<Country>();
    //    }
    //}
}