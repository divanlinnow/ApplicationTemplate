using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace Domain.Entities.Business.Tests
{
    [TestClass]
    public class AssemblyTests
    {
        // Unit test to check if classes have been added or removed from the "Domain.Entities.Business" namespace / assembly.
        [TestMethod]
        [TestCategory("Entities - Assemblies")]
        public void Domain_Entities_Business_Assembly()
        {
            var count = Assembly.Load("Domain.Entities.Business").GetTypes().ToList().Count;

            Assert.IsNotNull(count);
            Assert.AreEqual(16, count);
        }
    }
}