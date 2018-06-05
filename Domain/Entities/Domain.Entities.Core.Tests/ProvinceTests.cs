using Domain.Mappings.Core;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Domain.Entities.Core.Tests
{
    [TestClass]
    public class ProvinceTests
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
        [TestCategory("Entities - Properties")]
        public void Province_Property_ISOCode()
        {
            // Arrange
            var province = new Province();
            var value = "XXX";

            // Act
            province.ISOCode = value;

            // Assert
            Assert.IsNotNull(province.ISOCode);
            Assert.IsInstanceOfType(province.ISOCode, typeof(string));
            Assert.AreEqual(value, province.ISOCode);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Province_Property_Abbreviation()
        {
            // Arrange
            var province = new Province();
            var value = "TP";

            // Act
            province.Abbreviation = value;

            // Assert
            Assert.IsNotNull(province.Abbreviation);
            Assert.IsInstanceOfType(province.Abbreviation, typeof(string));
            Assert.AreEqual(value, province.Abbreviation);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Province_Property_Name()
        {
            // Arrange
            var province = new Province();
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
        [TestCategory("Entities - Properties")]
        public void Province_Property_Count()
        {
            var province = new Province();
            Assert.AreEqual(6, province.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Province_Extension_AsDTO_Null()
        {
            // Arrange
            Province province = null;

            // Act
            var result = province.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Province_Extension_AsDTO_NotNull()
        {
            // Arrange
            var province = TestHelper.Province();

            // Act
            var result = province.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ProvinceDto));

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