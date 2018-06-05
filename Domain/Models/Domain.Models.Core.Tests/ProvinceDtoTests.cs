using Domain.Entities.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class ProvinceDtoTests
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
        public void Province_Property_ISOCode()
        {
            // Arrange
            var province = new ProvinceDto();
            var value = "XXX";

            // Act
            province.ISOCode = value;

            // Assert
            Assert.IsNotNull(province.ISOCode);
            Assert.IsInstanceOfType(province.ISOCode, typeof(string));
            Assert.AreEqual(value, province.ISOCode);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void Province_Property_Abbreviation()
        {
            // Arrange
            var province = new ProvinceDto();
            var value = "TP";

            // Act
            province.Abbreviation = value;

            // Assert
            Assert.IsNotNull(province.Abbreviation);
            Assert.IsInstanceOfType(province.Abbreviation, typeof(string));
            Assert.AreEqual(value, province.Abbreviation);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void Province_Property_Name()
        {
            // Arrange
            var province = new ProvinceDto();
            var value = "Test Province";

            // Act
            province.Name = value;

            // Assert
            Assert.IsNotNull(province.Name);
            Assert.IsInstanceOfType(province.Name, typeof(string));
            Assert.AreEqual(value, province.Name);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void Province_Property_Count()
        {
            var province = new ProvinceDto();
            Assert.AreEqual(4, province.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void Province_Extension_AsEntity_Null()
        {
            // Arrange
            ProvinceDto province = null;

            // Act
            var result = province.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void Province_Extension_AsEntity_NotNull()
        {
            // Arrange
            var province = TestHelper.ProvinceDto();

            // Act
            var result = province.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Province));

            Assert.IsNotNull(result.ISOCode);
            Assert.IsInstanceOfType(result.ISOCode, typeof(string));
            Assert.AreEqual(province.ISOCode, result.ISOCode);

            Assert.IsNotNull(result.Abbreviation);
            Assert.IsInstanceOfType(result.Abbreviation, typeof(string));
            Assert.AreEqual(province.Abbreviation, result.Abbreviation);

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(province.Name, result.Name);
        }

        #endregion Extensions Tests
    }
}