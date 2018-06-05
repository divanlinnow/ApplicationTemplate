using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Reflection;

namespace Domain.Entities.Core.Tests
{
    [TestClass]
    public class AssemblyTests
    {
        // Unit test to check if classes have been added or removed from the "Domain.Entities.Core" namespace / assembly.
        [TestMethod]
        [TestCategory("Entities - Assemblies")]
        public void Domain_Entities_Core_Assembly()
        {
            var count = Assembly.Load("Domain.Entities.Core").GetTypes().ToList().Count;

            Assert.IsNotNull(count);
            Assert.AreEqual(14, count);
        }
    }
}