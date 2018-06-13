using Domain.Entities.Business;
using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.Business.Tests
{
    [TestClass]
    public class OrganizationDepartmentDtoTests
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
        public void OrganizationDepartmentDto_Property_Name()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = "Test Department";

            organizationDepartment.Name = value;

            Assert.IsNotNull(organizationDepartment.Name);
            Assert.IsInstanceOfType(organizationDepartment.Name, typeof(string));
            Assert.AreEqual(value, organizationDepartment.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_Organization()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = TestHelper.OrganizationDto();

            organizationDepartment.Organization = value;

            Assert.IsNotNull(organizationDepartment.Organization);
            Assert.IsInstanceOfType(organizationDepartment.Organization, typeof(OrganizationDto));
            Assert.AreEqual(value, organizationDepartment.Organization);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_Branch()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = TestHelper.OrganizationBranchDto();

            organizationDepartment.Branch = value;

            Assert.IsNotNull(organizationDepartment.Branch);
            Assert.IsInstanceOfType(organizationDepartment.Branch, typeof(OrganizationBranchDto));
            Assert.AreEqual(value, organizationDepartment.Branch);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_Employees()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = TestHelper.EmployeeDtos();

            organizationDepartment.Employees = value;

            Assert.IsNotNull(organizationDepartment.Employees);
            Assert.IsInstanceOfType(organizationDepartment.Employees, typeof(List<EmployeeDto>));
            Assert.AreEqual(value, organizationDepartment.Employees);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_Address()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = Core.Tests.TestHelper.AddressDto();

            organizationDepartment.Address = value;

            Assert.IsNotNull(organizationDepartment.Address);
            Assert.IsInstanceOfType(organizationDepartment.Address, typeof(AddressDto));
            Assert.AreEqual(value, organizationDepartment.Address);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_Created()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = DateTime.Now;

            organizationDepartment.Created = value;

            Assert.IsNotNull(organizationDepartment.Created);
            Assert.IsInstanceOfType(organizationDepartment.Created, typeof(DateTime));
            Assert.AreEqual(value, organizationDepartment.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_CreatedBy()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = Core.Tests.TestHelper.UserDto();

            organizationDepartment.CreatedBy = value;

            Assert.IsNotNull(organizationDepartment.CreatedBy);
            Assert.IsInstanceOfType(organizationDepartment.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, organizationDepartment.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_Modified()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = DateTime.Now;

            organizationDepartment.Modified = value;

            Assert.IsNotNull(organizationDepartment.Modified);
            Assert.IsInstanceOfType(organizationDepartment.Modified, typeof(DateTime));
            Assert.AreEqual(value, organizationDepartment.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_ModifiedBy()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = Core.Tests.TestHelper.UserDto();

            organizationDepartment.ModifiedBy = value;

            Assert.IsNotNull(organizationDepartment.ModifiedBy);
            Assert.IsInstanceOfType(organizationDepartment.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, organizationDepartment.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_IsActive()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = true;

            organizationDepartment.IsActive = value;

            Assert.IsNotNull(organizationDepartment.IsActive);
            Assert.IsInstanceOfType(organizationDepartment.IsActive, typeof(bool));
            Assert.AreEqual(value, organizationDepartment.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_IsDeleted()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            var value = false;

            organizationDepartment.IsDeleted = value;

            Assert.IsNotNull(organizationDepartment.IsDeleted);
            Assert.IsInstanceOfType(organizationDepartment.IsDeleted, typeof(bool));
            Assert.AreEqual(value, organizationDepartment.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDepartmentDto_Property_Count()
        {
            var organizationDepartment = new OrganizationDepartmentDto();
            Assert.AreEqual(12, organizationDepartment.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void OrganizationDepartmentDto_Extension_AsEntity_Null()
        {
            OrganizationDepartmentDto organizationDepartment = null;
            var result = organizationDepartment.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void OrganizationDepartmentDto_Extension_AsEntity_NotNull()
        {
            var organizationDepartment = TestHelper.OrganizationDepartmentDto();
            var result = organizationDepartment.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OrganizationDepartment));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(organizationDepartment.Name, result.Name);

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(Organization));

            Assert.IsNotNull(result.Branch);
            Assert.IsInstanceOfType(result.Branch, typeof(OrganizationBranch));

            Assert.IsNotNull(result.Employees);
            Assert.IsInstanceOfType(result.Employees, typeof(List<Employee>));

            Assert.IsNotNull(result.Address);
            Assert.IsInstanceOfType(result.Address, typeof(Address));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(organizationDepartment.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(organizationDepartment.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

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