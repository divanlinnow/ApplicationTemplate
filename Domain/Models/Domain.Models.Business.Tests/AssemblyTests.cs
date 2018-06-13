using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace Domain.Models.Business.Tests
{
    [TestClass]
    public class AssemblyTests
    {
        // Unit test to check if classes have been added or removed from the "Domain.Entities.Core" namespace / assembly.
        [TestMethod]
        [TestCategory("Models - Assemblies")]
        public void Domain_Models_Business_Assembly()
        {
            var count = Assembly.Load("Domain.Models.Business").GetTypes().ToList().Count;

            Assert.IsNotNull(count);
            Assert.AreEqual(17, count);
        }
    }
}