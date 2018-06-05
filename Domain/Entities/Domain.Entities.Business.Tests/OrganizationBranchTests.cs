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
    public class OrganizationBranchTests
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
        public void OrganizationBranch_Property_Name()
        {
            // Arrange
            var organizationBranch = new OrganizationBranch();
            var value = "Test Branch";

            // Act
            organizationBranch.Name = value;

            // Assert
            Assert.IsNotNull(organizationBranch.Name);
            Assert.IsInstanceOfType(organizationBranch.Name, typeof(string));
            Assert.AreEqual(value, organizationBranch.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationBranch_Property_Organization()
        {
            // Arrange
            var organizationBranch = new OrganizationBranch();
            var value = TestHelper.Organization();

            // Act
            organizationBranch.Organization = value;

            // Assert
            Assert.IsNotNull(organizationBranch.Organization);
            Assert.IsInstanceOfType(organizationBranch.Organization, typeof(Organization));
            Assert.AreEqual(value, organizationBranch.Organization);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationBranch_Property_Departments()
        {
            // Arrange
            var organizationBranch = new OrganizationBranch();
            var value = TestHelper.OrganizationDepartments();

            // Act
            organizationBranch.Departments = value;

            // Assert
            Assert.IsNotNull(organizationBranch.Departments);
            Assert.IsInstanceOfType(organizationBranch.Departments, typeof(List<OrganizationDepartment>));
            Assert.AreEqual(value, organizationBranch.Departments);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationBranch_Property_Address()
        {
            // Arrange
            var organizationBranch = new OrganizationBranch();
            var value = Core.Tests.TestHelper.Address();

            // Act
            organizationBranch.Address = value;

            // Assert
            Assert.IsNotNull(organizationBranch.Address);
            Assert.IsInstanceOfType(organizationBranch.Address, typeof(Address));
            Assert.AreEqual(value, organizationBranch.Address);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationBranch_Property_Created()
        {
            // Arrange
            var organizationBranch = new OrganizationBranch();
            var value = DateTime.Now;

            // Act
            organizationBranch.Created = value;

            // Assert
            Assert.IsNotNull(organizationBranch.Created);
            Assert.IsInstanceOfType(organizationBranch.Created, typeof(DateTime));
            Assert.AreEqual(value, organizationBranch.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationBranch_Property_CreatedBy()
        {
            // Arrange
            var organizationBranch = new OrganizationBranch();
            var value = Core.Tests.TestHelper.User();

            // Act
            organizationBranch.CreatedBy = value;

            // Assert
            Assert.IsNotNull(organizationBranch.CreatedBy);
            Assert.IsInstanceOfType(organizationBranch.CreatedBy, typeof(User));
            Assert.AreEqual(value, organizationBranch.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationBranch_Property_Modified()
        {
            // Arrange
            var organizationBranch = new OrganizationBranch();
            var value = DateTime.Now;

            // Act
            organizationBranch.Modified = value;

            // Assert
            Assert.IsNotNull(organizationBranch.Modified);
            Assert.IsInstanceOfType(organizationBranch.Modified, typeof(DateTime));
            Assert.AreEqual(value, organizationBranch.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationBranch_Property_ModifiedBy()
        {
            // Arrange
            var organizationBranch = new OrganizationBranch();
            var value = Core.Tests.TestHelper.User();

            // Act
            organizationBranch.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(organizationBranch.ModifiedBy);
            Assert.IsInstanceOfType(organizationBranch.ModifiedBy, typeof(User));
            Assert.AreEqual(value, organizationBranch.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_IsDeleted()
        {
            // Arrange
            var organizationBranch = new OrganizationBranch();
            var value = false;

            // Act
            organizationBranch.IsDeleted = value;

            // Assert
            Assert.IsNotNull(organizationBranch.IsDeleted);
            Assert.IsInstanceOfType(organizationBranch.IsDeleted, typeof(bool));
            Assert.AreEqual(value, organizationBranch.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationBranch_Property_Count()
        {
            var organizationBranch = new OrganizationBranch();
            Assert.AreEqual(10, organizationBranch.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void OrganizationBranch_Extension_AsDTO_Null()
        {
            // Arrange
            OrganizationBranch organizationBranch = null;

            // Act
            var result = organizationBranch.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void OrganizationBranch_Extension_AsDTO_NotNull()
        {
            // Arrange
            var organizationBranch = TestHelper.OrganizationBranch();

            // Act
            var result = organizationBranch.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OrganizationBranchDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(organizationBranch.Name, result.Name);

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(OrganizationDto));

            Assert.IsNotNull(result.Departments);
            Assert.IsInstanceOfType(result.Departments, typeof(List<OrganizationDepartmentDto>));

            Assert.IsNotNull(result.Address);
            Assert.IsInstanceOfType(result.Address, typeof(AddressDto));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(organizationBranch.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(organizationBranch.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(organizationBranch.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}