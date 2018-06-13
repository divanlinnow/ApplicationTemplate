using Domain.Mappings.Business;
using Domain.Models.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Domain.Entities.Business.Tests
{
    [TestClass]
    public class CurrencyTests
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
        public void Currency_Property_ISOCode()
        {
            // Arrange
            var currency = new Currency();
            var value = "XXX";

            // Act
            currency.ISOCode = value;

            // Assert
            Assert.IsNotNull(currency.ISOCode);
            Assert.IsInstanceOfType(currency.ISOCode, typeof(string));
            Assert.AreEqual(value, currency.ISOCode);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Currency_Property_Abbreviation()
        {
            // Arrange
            var currency = new Currency();
            var value = "TC";

            // Act
            currency.Abbreviation = value;

            // Assert
            Assert.IsNotNull(currency.Abbreviation);
            Assert.IsInstanceOfType(currency.Abbreviation, typeof(string));
            Assert.AreEqual(value, currency.Abbreviation);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Currency_Property_Name()
        {
            // Arrange
            var currency = new Currency();
            var value = "Test Currency";

            // Act
            currency.Name = value;

            // Assert
            Assert.IsNotNull(currency.Name);
            Assert.IsInstanceOfType(currency.Name, typeof(string));
            Assert.AreEqual(value, currency.Name);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Currency_Property_Count()
        {
            var currency = new Currency();
            Assert.AreEqual(4, currency.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Currency_Extension_AsDTO_Null()
        {
            // Arrange
            Currency currency = null;

            // Act
            var result = currency.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Currency_Extension_AsDTO_NotNull()
        {
            // Arrange
            var currency = TestHelper.Currency();

            // Act
            var result = currency.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CurrencyDto));

            Assert.IsNotNull(result.ISOCode);
            Assert.IsInstanceOfType(result.ISOCode, typeof(string));
            Assert.AreEqual(currency.ISOCode, result.ISOCode);

            Assert.IsNotNull(result.Abbreviation);
            Assert.IsInstanceOfType(result.Abbreviation, typeof(string));
            Assert.AreEqual(currency.Abbreviation, result.Abbreviation);

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(currency.Name, result.Name);
        }

        #endregion Extensions Tests
    }
}