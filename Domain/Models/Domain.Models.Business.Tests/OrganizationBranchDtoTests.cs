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
    public class OrganizationBranchDtoTests
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
        public void OrganizationBranchDto_Property_Name()
        {
            var organizationBranch = new OrganizationBranchDto();
            var value = "Test Branch";

            organizationBranch.Name = value;

            Assert.IsNotNull(organizationBranch.Name);
            Assert.IsInstanceOfType(organizationBranch.Name, typeof(string));
            Assert.AreEqual(value, organizationBranch.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationBranchDto_Property_Organization()
        {
            var organizationBranch = new OrganizationBranchDto();
            var value = TestHelper.OrganizationDto();

            organizationBranch.Organization = value;

            Assert.IsNotNull(organizationBranch.Organization);
            Assert.IsInstanceOfType(organizationBranch.Organization, typeof(OrganizationDto));
            Assert.AreEqual(value, organizationBranch.Organization);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationBranchDto_Property_Departments()
        {
            var organizationBranch = new OrganizationBranchDto();
            var value = TestHelper.OrganizationDepartments();

            organizationBranch.Departments = value;

            Assert.IsNotNull(organizationBranch.Departments);
            Assert.IsInstanceOfType(organizationBranch.Departments, typeof(List<OrganizationDepartmentDto>));
            Assert.AreEqual(value, organizationBranch.Departments);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationBranchDto_Property_Address()
        {
            var organizationBranch = new OrganizationBranchDto();
            var value = Core.Tests.TestHelper.AddressDto();

            organizationBranch.Address = value;

            Assert.IsNotNull(organizationBranch.Address);
            Assert.IsInstanceOfType(organizationBranch.Address, typeof(AddressDto));
            Assert.AreEqual(value, organizationBranch.Address);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationBranchDto_Property_Created()
        {
            var organizationBranch = new OrganizationBranchDto();
            var value = DateTime.Now;

            organizationBranch.Created = value;

            Assert.IsNotNull(organizationBranch.Created);
            Assert.IsInstanceOfType(organizationBranch.Created, typeof(DateTime));
            Assert.AreEqual(value, organizationBranch.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationBranchDto_Property_CreatedBy()
        {
            var organizationBranch = new OrganizationBranchDto();
            var value = Core.Tests.TestHelper.UserDto();

            organizationBranch.CreatedBy = value;

            Assert.IsNotNull(organizationBranch.CreatedBy);
            Assert.IsInstanceOfType(organizationBranch.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, organizationBranch.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationBranchDto_Property_Modified()
        {
            var organizationBranch = new OrganizationBranchDto();
            var value = DateTime.Now;

            organizationBranch.Modified = value;

            Assert.IsNotNull(organizationBranch.Modified);
            Assert.IsInstanceOfType(organizationBranch.Modified, typeof(DateTime));
            Assert.AreEqual(value, organizationBranch.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationBranchDto_Property_ModifiedBy()
        {
            var organizationBranch = new OrganizationBranchDto();
            var value = Core.Tests.TestHelper.UserDto();

            organizationBranch.ModifiedBy = value;

            Assert.IsNotNull(organizationBranch.ModifiedBy);
            Assert.IsInstanceOfType(organizationBranch.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, organizationBranch.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void Order_Property_IsDeleted()
        {
            var organizationBranch = new OrganizationBranchDto();
            var value = false;

            organizationBranch.IsDeleted = value;

            Assert.IsNotNull(organizationBranch.IsDeleted);
            Assert.IsInstanceOfType(organizationBranch.IsDeleted, typeof(bool));
            Assert.AreEqual(value, organizationBranch.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationBranchDto_Property_Count()
        {
            var organizationBranch = new OrganizationBranchDto();
            Assert.AreEqual(10, organizationBranch.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void OrganizationBranchDto_Extension_AsEntity_Null()
        {
            OrganizationBranchDto organizationBranch = null;
            var result = organizationBranch.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void OrganizationBranchDto_Extension_AsEntity_NotNull()
        {
            var organizationBranch = TestHelper.OrganizationBranchDto();
            var result = organizationBranch.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OrganizationBranch));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(organizationBranch.Name, result.Name);

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(Organization));

            Assert.IsNotNull(result.Departments);
            Assert.IsInstanceOfType(result.Departments, typeof(List<OrganizationDepartment>));

            Assert.IsNotNull(result.Address);
            Assert.IsInstanceOfType(result.Address, typeof(Address));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(organizationBranch.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(organizationBranch.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(organizationBranch.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}