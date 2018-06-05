using Domain.Entities.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class LanguageDtoTests
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
        public void LanguageDto_Property_ISOCode()
        {
            // Arrange
            var language = new LanguageDto();
            var value = "XXX";

            // Act
            language.ISOCode = value;

            // Assert
            Assert.IsNotNull(language.ISOCode);
            Assert.IsInstanceOfType(language.ISOCode, typeof(string));
            Assert.AreEqual(value, language.ISOCode);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void LanguageDto_Property_Abbreviation()
        {
            // Arrange
            var language = new LanguageDto();
            var value = "TC";

            // Act
            language.Abbreviation = value;

            // Assert
            Assert.IsNotNull(language.Abbreviation);
            Assert.IsInstanceOfType(language.Abbreviation, typeof(string));
            Assert.AreEqual(value, language.Abbreviation);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void LanguageDto_Property_Name()
        {
            // Arrange
            var language = new LanguageDto();
            var value = "Test City";

            // Act
            language.Name = value;

            // Assert
            Assert.IsNotNull(language.Name);
            Assert.IsInstanceOfType(language.Name, typeof(string));
            Assert.AreEqual(value, language.Name);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void LanguageDto_Property_Count()
        {
            var language = new LanguageDto();
            Assert.AreEqual(4, language.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void LanguageDto_Extension_AsEntity_Null()
        {
            // Arrange
            LanguageDto language = null;

            // Act
            var result = language.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void LanguageDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var language = TestHelper.LanguageDto();

            // Act
            var result = language.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Language));

            Assert.IsNotNull(result.ISOCode);
            Assert.IsInstanceOfType(result.ISOCode, typeof(string));
            Assert.AreEqual(language.ISOCode, result.ISOCode);

            Assert.IsNotNull(result.Abbreviation);
            Assert.IsInstanceOfType(result.Abbreviation, typeof(string));
            Assert.AreEqual(language.Abbreviation, result.Abbreviation);

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(language.Name, result.Name);
        }

        #endregion Extensions Tests
    }
}