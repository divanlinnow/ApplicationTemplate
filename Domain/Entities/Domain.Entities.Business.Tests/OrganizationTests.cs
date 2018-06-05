using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.Business.Tests
{
    [TestClass]
    public class OrganizationTests
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
        public void Organization_Property_RegisteredName()
        {
            // Arrange
            var organization = new Organization();
            var value = "Test Registered Organization Name";

            // Act
            organization.RegisteredName = value;

            // Assert
            Assert.IsNotNull(organization.RegisteredName);
            Assert.IsInstanceOfType(organization.RegisteredName, typeof(string));
            Assert.AreEqual(value, organization.RegisteredName);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_PrintName()
        {
            // Arrange
            var organization = new Organization();
            var value = "Test Organization";

            // Act
            organization.PrintName = value;

            // Assert
            Assert.IsNotNull(organization.PrintName);
            Assert.IsInstanceOfType(organization.PrintName, typeof(string));
            Assert.AreEqual(value, organization.PrintName);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_Branches()
        {
            // Arrange
            var organization = new Organization();
            var value = TestHelper.OrganizationBranches();

            // Act
            organization.Branches = value;

            // Assert
            Assert.IsNotNull(organization.Branches);
            Assert.IsInstanceOfType(organization.Branches, typeof(List<OrganizationBranch>));
            Assert.AreEqual(value, organization.Branches);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_Created()
        {
            // Arrange
            var organization = new Organization();
            var value = DateTime.Now;

            // Act
            organization.Created = value;

            // Assert
            Assert.IsNotNull(organization.Created);
            Assert.IsInstanceOfType(organization.Created, typeof(DateTime));
            Assert.AreEqual(value, organization.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_CreatedBy()
        {
            // Arrange
            var organization = new Organization();
            var value = Core.Tests.TestHelper.User();

            // Act
            organization.CreatedBy = value;

            // Assert
            Assert.IsNotNull(organization.CreatedBy);
            Assert.IsInstanceOfType(organization.CreatedBy, typeof(User));
            Assert.AreEqual(value, organization.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_Modified()
        {
            // Arrange
            var organization = new Organization();
            var value = DateTime.Now;

            // Act
            organization.Modified = value;

            // Assert
            Assert.IsNotNull(organization.Modified);
            Assert.IsInstanceOfType(organization.Modified, typeof(DateTime));
            Assert.AreEqual(value, organization.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_ModifiedBy()
        {
            // Arrange
            var organization = new Organization();
            var value = Core.Tests.TestHelper.User();

            // Act
            organization.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(organization.ModifiedBy);
            Assert.IsInstanceOfType(organization.ModifiedBy, typeof(User));
            Assert.AreEqual(value, organization.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_IsRegistered()
        {
            // Arrange
            var organization = new Organization();
            var value = true;

            // Act
            organization.IsRegistered = value;

            // Assert
            Assert.IsNotNull(organization.IsRegistered);
            Assert.IsInstanceOfType(organization.IsRegistered, typeof(bool));
            Assert.AreEqual(value, organization.IsRegistered);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_IsActive()
        {
            // Arrange
            var organization = new Organization();
            var value = true;

            // Act
            organization.IsActive = value;

            // Assert
            Assert.IsNotNull(organization.IsActive);
            Assert.IsInstanceOfType(organization.IsActive, typeof(bool));
            Assert.AreEqual(value, organization.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_IsDeleted()
        {
            // Arrange
            var organization = new Organization();
            var value = false;

            // Act
            organization.IsDeleted = value;

            // Assert
            Assert.IsNotNull(organization.IsDeleted);
            Assert.IsInstanceOfType(organization.IsDeleted, typeof(bool));
            Assert.AreEqual(value, organization.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Organization_Property_Count()
        {
            var organization = new Organization();
            Assert.AreEqual(11, organization.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Organization_Extension_AsDTO_Null()
        {
            // Arrange
            Organization organization = null;

            // Act
            var result = organization.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Organization_Extension_AsDTO_NotNull()
        {
            // Arrange
            var organization = TestHelper.Organization();

            // Act
            var result = organization.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OrganizationDto));

            Assert.IsNotNull(result.RegisteredName);
            Assert.IsInstanceOfType(result.RegisteredName, typeof(string));
            Assert.AreEqual(organization.RegisteredName, result.RegisteredName);

            Assert.IsNotNull(result.PrintName);
            Assert.IsInstanceOfType(result.PrintName, typeof(string));
            Assert.AreEqual(organization.PrintName, result.PrintName);

            Assert.IsNotNull(result.Branches);
            Assert.IsInstanceOfType(result.Branches, typeof(List<OrganizationBranchDto>));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(organization.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(organization.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsRegistered);
            Assert.IsInstanceOfType(result.IsRegistered, typeof(bool));
            Assert.AreEqual(organization.IsRegistered, result.IsRegistered);

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(organization.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(organization.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}