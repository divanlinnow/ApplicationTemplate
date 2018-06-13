using Domain.Entities.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class CountryDtoTests
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
        public void CountryDto_Property_ISOCode()
        {
            // Arrange
            var country = new CountryDto();
            var value = "XXX";

            // Act
            country.ISOCode = value;

            // Assert
            Assert.IsNotNull(country.ISOCode);
            Assert.IsInstanceOfType(country.ISOCode, typeof(string));
            Assert.AreEqual(value, country.ISOCode);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CountryDto_Property_Abbreviation()
        {
            // Arrange
            var country = new CountryDto();
            var value = "TC";

            // Act
            country.Abbreviation = value;

            // Assert
            Assert.IsNotNull(country.Abbreviation);
            Assert.IsInstanceOfType(country.Abbreviation, typeof(string));
            Assert.AreEqual(value, country.Abbreviation);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CountryDto_Property_Name()
        {
            // Arrange
            var country = new CountryDto();
            var value = "Test Country";

            // Act
            country.Name = value;

            // Assert
            Assert.IsNotNull(country.Name);
            Assert.IsInstanceOfType(country.Name, typeof(string));
            Assert.AreEqual(value, country.Name);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CountryDto_Property_Count()
        {
            var country = new CountryDto();
            Assert.AreEqual(4, country.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void CountryDto_Extension_AsEntity_Null()
        {
            // Arrange
            CountryDto country = null;

            // Act
            var result = country.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void CountryDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var country = TestHelper.CountryDto();

            // Act
            var result = country.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Country));

            Assert.IsNotNull(result.ISOCode);
            Assert.IsInstanceOfType(result.ISOCode, typeof(string));
            Assert.AreEqual(country.ISOCode, result.ISOCode);

            Assert.IsNotNull(result.Abbreviation);
            Assert.IsInstanceOfType(result.Abbreviation, typeof(string));
            Assert.AreEqual(country.Abbreviation, result.Abbreviation);

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(country.Name, result.Name);
        }

        #endregion Extensions Tests
    }
}