using Domain.Entities.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class CityDtoTests
    {
        #region Properties Tests

        /*
         * Why are we unit testing properties?
         * What is an auto-property today may end up having a backing field put against it tomorrow, and not necessarily by you.
         * What you're doing when you test an auto-property is, from the perspective of the caller, testing the public "interface" of your class.
         * The caller has no idea if this is an auto property with a framework-generated backing store, or if there is a million lines of complex code in the getter/setter.
         * Therefore the caller is testing the contract implied by the property - that if you put X into the box, you can get X back later on.
         * Therefore it behooves us to include a test since we are testing the behavior of our own code and not the behavior of the compiler.
         */

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CityDto_Property_ISOCode()
        {
            // Arrange
            var city = new CityDto();
            var value = "XXX";

            // Act
            city.ISOCode = value;

            // Assert
            Assert.IsNotNull(city.ISOCode);
            Assert.IsInstanceOfType(city.ISOCode, typeof(string));
            Assert.AreEqual(value, city.ISOCode);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CityDto_Property_Abbreviation()
        {
            // Arrange
            var city = new CityDto();
            var value = "TC";

            // Act
            city.Abbreviation = value;

            // Assert
            Assert.IsNotNull(city.Abbreviation);
            Assert.IsInstanceOfType(city.Abbreviation, typeof(string));
            Assert.AreEqual(value, city.Abbreviation);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CityDto_Property_Name()
        {
            // Arrange
            var city = new CityDto();
            var value = "Test City";

            // Act
            city.Name = value;

            // Assert
            Assert.IsNotNull(city.Name);
            Assert.IsInstanceOfType(city.Name, typeof(string));
            Assert.AreEqual(value, city.Name);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CityDto_Property_Count()
        {
            var city = new CityDto();
            Assert.AreEqual(6, city.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void CityDto_Extension_AsEntity_Null()
        {
            // Arrange
            CityDto city = null;

            // Act
            var result = city.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void CityDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var city = TestHelper.CityDto();

            // Act
            var result = city.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(City));

            Assert.IsNotNull(result.ISOCode);
            Assert.IsInstanceOfType(result.ISOCode, typeof(string));
            Assert.AreEqual(city.ISOCode, result.ISOCode);

            Assert.IsNotNull(result.Abbreviation);
            Assert.IsInstanceOfType(result.Abbreviation, typeof(string));
            Assert.AreEqual(city.Abbreviation, result.Abbreviation);

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(city.Name, result.Name);
        }

        #endregion Extensions Tests
    }
}