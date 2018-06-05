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
    public class OrganizationDtoTests
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
        public void OrganizationDto_Property_RegisteredName()
        {
            var organization = new OrganizationDto();
            var value = "Test Registered Organization Name";

            organization.RegisteredName = value;

            Assert.IsNotNull(organization.RegisteredName);
            Assert.IsInstanceOfType(organization.RegisteredName, typeof(string));
            Assert.AreEqual(value, organization.RegisteredName);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_PrintName()
        {
            var organization = new OrganizationDto();
            var value = "Test Organization";

            organization.PrintName = value;

            Assert.IsNotNull(organization.PrintName);
            Assert.IsInstanceOfType(organization.PrintName, typeof(string));
            Assert.AreEqual(value, organization.PrintName);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_Branches()
        {
            var organization = new OrganizationDto();
            var value = TestHelper.OrganizationBranchDtos();

            organization.Branches = value;

            Assert.IsNotNull(organization.Branches);
            Assert.IsInstanceOfType(organization.Branches, typeof(List<OrganizationBranchDto>));
            Assert.AreEqual(value, organization.Branches);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_Created()
        {
            var organization = new OrganizationDto();
            var value = DateTime.Now;

            organization.Created = value;

            Assert.IsNotNull(organization.Created);
            Assert.IsInstanceOfType(organization.Created, typeof(DateTime));
            Assert.AreEqual(value, organization.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_CreatedBy()
        {
            var organization = new OrganizationDto();
            var value = Core.Tests.TestHelper.UserDto();

            organization.CreatedBy = value;

            Assert.IsNotNull(organization.CreatedBy);
            Assert.IsInstanceOfType(organization.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, organization.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_Modified()
        {
            var organization = new OrganizationDto();
            var value = DateTime.Now;

            organization.Modified = value;

            Assert.IsNotNull(organization.Modified);
            Assert.IsInstanceOfType(organization.Modified, typeof(DateTime));
            Assert.AreEqual(value, organization.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_ModifiedBy()
        {
            var organization = new OrganizationDto();
            var value = Core.Tests.TestHelper.UserDto();

            organization.ModifiedBy = value;

            Assert.IsNotNull(organization.ModifiedBy);
            Assert.IsInstanceOfType(organization.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, organization.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_IsRegistered()
        {
            var organization = new OrganizationDto();
            var value = true;

            organization.IsRegistered = value;

            Assert.IsNotNull(organization.IsRegistered);
            Assert.IsInstanceOfType(organization.IsRegistered, typeof(bool));
            Assert.AreEqual(value, organization.IsRegistered);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_IsActive()
        {
            var organization = new OrganizationDto();
            var value = true;

            organization.IsActive = value;

            Assert.IsNotNull(organization.IsActive);
            Assert.IsInstanceOfType(organization.IsActive, typeof(bool));
            Assert.AreEqual(value, organization.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_IsDeleted()
        {
            var organization = new OrganizationDto();
            var value = false;

            organization.IsDeleted = value;

            Assert.IsNotNull(organization.IsDeleted);
            Assert.IsInstanceOfType(organization.IsDeleted, typeof(bool));
            Assert.AreEqual(value, organization.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrganizationDto_Property_Count()
        {
            var organization = new OrganizationDto();
            Assert.AreEqual(11, organization.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void OrganizationDto_Extension_AsEntity_Null()
        {
            OrganizationDto organization = null;
            var result = organization.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void OrganizationDto_Extension_AsEntity_NotNull()
        {
            var organization = TestHelper.OrganizationDto();
            var result = organization.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Organization));

            Assert.IsNotNull(result.RegisteredName);
            Assert.IsInstanceOfType(result.RegisteredName, typeof(string));
            Assert.AreEqual(organization.RegisteredName, result.RegisteredName);

            Assert.IsNotNull(result.PrintName);
            Assert.IsInstanceOfType(result.PrintName, typeof(string));
            Assert.AreEqual(organization.PrintName, result.PrintName);

            Assert.IsNotNull(result.Branches);
            Assert.IsInstanceOfType(result.Branches, typeof(List<OrganizationBranch>));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(organization.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(organization.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

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