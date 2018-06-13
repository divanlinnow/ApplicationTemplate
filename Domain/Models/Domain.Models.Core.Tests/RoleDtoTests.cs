using Domain.Entities.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class RoleDtoTests
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
        public void RoleDto_Property_Name()
        {
            // Arrange
            var role = new RoleDto();
            var value = "Test Role";

            // Act
            role.Name = value;

            // Assert
            Assert.IsNotNull(role.Name);
            Assert.IsInstanceOfType(role.Name, typeof(string));
            Assert.AreEqual(value, role.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void RoleDto_Property_Permissions()
        {
            // Arrange
            var role = new RoleDto();
            var value = TestHelper.PermissionDtos();

            // Act
            role.Permissions = value;

            // Assert
            Assert.IsNotNull(role.Permissions);
            Assert.IsInstanceOfType(role.Permissions, typeof(List<PermissionDto>));
            Assert.AreEqual(value, role.Permissions);
            Assert.AreEqual(2, role.Permissions.Count);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void RoleDto_Property_IsActive()
        {
            // Arrange
            var role = new RoleDto();
            var value = true;

            // Act
            role.IsActive = value;

            // Assert
            Assert.IsNotNull(role.IsActive);
            Assert.IsInstanceOfType(role.IsActive, typeof(bool));
            Assert.AreEqual(value, role.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void RoleDto_Property_IsDeleted()
        {
            // Arrange
            var role = new RoleDto();
            var value = false;

            // Act
            role.IsDeleted = value;

            // Assert
            Assert.IsNotNull(role.IsDeleted);
            Assert.IsInstanceOfType(role.IsDeleted, typeof(bool));
            Assert.AreEqual(value, role.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void RoleDto_Property_Count()
        {
            var role = new RoleDto();
            Assert.AreEqual(5, role.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void RoleDto_Extension_AsEntity_Null()
        {
            // Arrange
            RoleDto role = null;

            // Act
            var result = role.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void RoleDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var role = TestHelper.RoleDto();

            // Act
            var result = role.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Role));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(role.Name, result.Name);

            Assert.IsNotNull(result.Permissions);
            Assert.IsInstanceOfType(result.Permissions, typeof(List<Permission>));
            Assert.AreEqual(2, result.Permissions.Count);

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(role.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(role.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}