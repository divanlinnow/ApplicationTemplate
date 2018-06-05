using Domain.Mappings.Core;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Domain.Entities.Core.Tests
{
    [TestClass]
    public class PermissionTests
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
        public void Permission_Property_Name()
        {
            // Arrange
            var permission = new Permission();
            var value = "Test Permission";

            // Act
            permission.Name = value;

            // Assert
            Assert.IsNotNull(permission.Name);
            Assert.IsInstanceOfType(permission.Name, typeof(string));
            Assert.AreEqual(value, permission.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Permission_Property_IsActive()
        {
            // Arrange
            var permission = new Permission();
            var value = true;

            // Act
            permission.IsActive = value;

            // Assert
            Assert.IsNotNull(permission.IsActive);
            Assert.IsInstanceOfType(permission.IsActive, typeof(bool));
            Assert.AreEqual(value, permission.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Permission_Property_IsDeleted()
        {
            // Arrange
            var permission = new Permission();
            var value = false;

            // Act
            permission.IsDeleted = value;

            // Assert
            Assert.IsNotNull(permission.IsDeleted);
            Assert.IsInstanceOfType(permission.IsDeleted, typeof(bool));
            Assert.AreEqual(value, permission.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Permission_Property_Count()
        {
            var permission = new Permission();
            Assert.AreEqual(4, permission.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Permission_Extension_AsDTO_Null()
        {
            // Arrange
            Permission permission = null;

            // Act
            var result = permission.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Permission_Extension_AsDTO_NotNull()
        {
            // Arrange
            var permission = TestHelper.Permission();

            // Act
            var result = permission.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(PermissionDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(permission.Name, result.Name);

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(permission.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(permission.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}