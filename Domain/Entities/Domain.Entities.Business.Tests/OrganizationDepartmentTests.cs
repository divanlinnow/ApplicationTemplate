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
    public class OrganizationDepartmentTests
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
        public void OrganizationDepartment_Property_Name()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = "Test Department";

            // Act
            organizationDepartment.Name = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.Name);
            Assert.IsInstanceOfType(organizationDepartment.Name, typeof(string));
            Assert.AreEqual(value, organizationDepartment.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_Organization()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = TestHelper.Organization();

            // Act
            organizationDepartment.Organization = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.Organization);
            Assert.IsInstanceOfType(organizationDepartment.Organization, typeof(Organization));
            Assert.AreEqual(value, organizationDepartment.Organization);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_Branch()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = TestHelper.OrganizationBranch();

            // Act
            organizationDepartment.Branch = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.Branch);
            Assert.IsInstanceOfType(organizationDepartment.Branch, typeof(OrganizationBranch));
            Assert.AreEqual(value, organizationDepartment.Branch);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_Employees()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = TestHelper.Employees();

            // Act
            organizationDepartment.Employees = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.Employees);
            Assert.IsInstanceOfType(organizationDepartment.Employees, typeof(List<Employee>));
            Assert.AreEqual(value, organizationDepartment.Employees);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_Address()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = Core.Tests.TestHelper.Address();

            // Act
            organizationDepartment.Address = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.Address);
            Assert.IsInstanceOfType(organizationDepartment.Address, typeof(Address));
            Assert.AreEqual(value, organizationDepartment.Address);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_Created()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = DateTime.Now;

            // Act
            organizationDepartment.Created = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.Created);
            Assert.IsInstanceOfType(organizationDepartment.Created, typeof(DateTime));
            Assert.AreEqual(value, organizationDepartment.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_CreatedBy()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = Core.Tests.TestHelper.User();

            // Act
            organizationDepartment.CreatedBy = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.CreatedBy);
            Assert.IsInstanceOfType(organizationDepartment.CreatedBy, typeof(User));
            Assert.AreEqual(value, organizationDepartment.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_Modified()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = DateTime.Now;

            // Act
            organizationDepartment.Modified = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.Modified);
            Assert.IsInstanceOfType(organizationDepartment.Modified, typeof(DateTime));
            Assert.AreEqual(value, organizationDepartment.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_ModifiedBy()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = Core.Tests.TestHelper.User();

            // Act
            organizationDepartment.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.ModifiedBy);
            Assert.IsInstanceOfType(organizationDepartment.ModifiedBy, typeof(User));
            Assert.AreEqual(value, organizationDepartment.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_IsActive()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = true;

            // Act
            organizationDepartment.IsActive = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.IsActive);
            Assert.IsInstanceOfType(organizationDepartment.IsActive, typeof(bool));
            Assert.AreEqual(value, organizationDepartment.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_IsDeleted()
        {
            // Arrange
            var organizationDepartment = new OrganizationDepartment();
            var value = false;

            // Act
            organizationDepartment.IsDeleted = value;

            // Assert
            Assert.IsNotNull(organizationDepartment.IsDeleted);
            Assert.IsInstanceOfType(organizationDepartment.IsDeleted, typeof(bool));
            Assert.AreEqual(value, organizationDepartment.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void OrganizationDepartment_Property_Count()
        {
            var organizationDepartment = new OrganizationDepartment();
            Assert.AreEqual(12, organizationDepartment.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void OrganizationDepartment_Extension_AsDTO_Null()
        {
            // Arrange
            OrganizationDepartment organizationDepartment = null;

            // Act
            var result = organizationDepartment.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void OrganizationDepartment_Extension_AsDTO_NotNull()
        {
            // Arrange
            var organizationDepartment = TestHelper.OrganizationDepartment();

            // Act
            var result = organizationDepartment.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OrganizationDepartmentDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(organizationDepartment.Name, result.Name);

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(OrganizationDto));

            Assert.IsNotNull(result.Branch);
            Assert.IsInstanceOfType(result.Branch, typeof(OrganizationBranchDto));

            Assert.IsNotNull(result.Employees);
            Assert.IsInstanceOfType(result.Employees, typeof(List<EmployeeDto>));

            Assert.IsNotNull(result.Address);
            Assert.IsInstanceOfType(result.Address, typeof(AddressDto));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(organizationDepartment.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(organizationDepartment.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(organizationDepartment.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(organizationDepartment.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}