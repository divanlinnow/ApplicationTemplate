using Domain.Entities.Business;
using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Models.Business.Tests
{
    [TestClass]
    public class JobDtoTests
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
        public void JobDto_Property_Organization()
        {
            // Arrange
            var job = new JobDto();
            var value = TestHelper.OrganizationDto();

            // Act
            job.Organization = value;

            // Assert
            Assert.IsNotNull(job.Organization);
            Assert.IsInstanceOfType(job.Organization, typeof(OrganizationDto));
            Assert.AreEqual(value, job.Organization);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_Branch()
        {
            // Arrange
            var job = new JobDto();
            var value = TestHelper.OrganizationBranchDto();

            // Act
            job.Branch = value;

            // Assert
            Assert.IsNotNull(job.Branch);
            Assert.IsInstanceOfType(job.Branch, typeof(OrganizationBranchDto));
            Assert.AreEqual(value, job.Branch);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_Department()
        {
            // Arrange
            var job = new JobDto();
            var value = TestHelper.OrganizationDepartmentDto();

            // Act
            job.Department = value;

            // Assert
            Assert.IsNotNull(job.Department);
            Assert.IsInstanceOfType(job.Department, typeof(OrganizationDepartmentDto));
            Assert.AreEqual(value, job.Department);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_Title()
        {
            // Arrange
            var job = new JobDto();
            var value = "Test Title";

            // Act
            job.Title = value;

            // Assert
            Assert.IsNotNull(job.Title);
            Assert.IsInstanceOfType(job.Title, typeof(string));
            Assert.AreEqual(value, job.Title);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_Role()
        {
            // Arrange
            var job = new JobDto();
            var value = Core.Tests.TestHelper.RoleDto();

            // Act
            job.Role = value;

            // Assert
            Assert.IsNotNull(job.Role);
            Assert.IsInstanceOfType(job.Role, typeof(RoleDto));
            Assert.AreEqual(value, job.Role);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_Created()
        {
            // Arrange
            var job = new JobDto();
            var value = DateTime.Now;

            // Act
            job.Created = value;

            // Assert
            Assert.IsNotNull(job.Created);
            Assert.IsInstanceOfType(job.Created, typeof(DateTime));
            Assert.AreEqual(value, job.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_CreatedBy()
        {
            // Arrange
            var job = new JobDto();
            var value = Core.Tests.TestHelper.UserDto();

            // Act
            job.CreatedBy = value;

            // Assert
            Assert.IsNotNull(job.CreatedBy);
            Assert.IsInstanceOfType(job.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, job.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_Modified()
        {
            // Arrange
            var job = new JobDto();
            var value = DateTime.Now;

            // Act
            job.Modified = value;

            // Assert
            Assert.IsNotNull(job.Modified);
            Assert.IsInstanceOfType(job.Modified, typeof(DateTime));
            Assert.AreEqual(value, job.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_ModifiedBy()
        {
            // Arrange
            var job = new JobDto();
            var value = Core.Tests.TestHelper.UserDto();

            // Act
            job.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(job.ModifiedBy);
            Assert.IsInstanceOfType(job.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, job.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_IsActive()
        {
            // Arrange
            var job = new JobDto();
            var value = true;

            // Act
            job.IsActive = value;

            // Assert
            Assert.IsNotNull(job.IsActive);
            Assert.IsInstanceOfType(job.IsActive, typeof(bool));
            Assert.AreEqual(value, job.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_IsDeleted()
        {
            // Arrange
            var job = new JobDto();
            var value = false;

            // Act
            job.IsDeleted = value;

            // Assert
            Assert.IsNotNull(job.IsDeleted);
            Assert.IsInstanceOfType(job.IsDeleted, typeof(bool));
            Assert.AreEqual(value, job.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void JobDto_Property_Count()
        {
            var job = new JobDto();
            Assert.AreEqual(12, job.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void JobDto_Extension_AsEntity_Null()
        {
            // Arrange
            JobDto job = null;

            // Act
            var result = job.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void JobDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var job = TestHelper.JobDto();

            // Act
            var result = job.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Job));

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(Organization));

            Assert.IsNotNull(result.Branch);
            Assert.IsInstanceOfType(result.Branch, typeof(OrganizationBranch));

            Assert.IsNotNull(result.Department);
            Assert.IsInstanceOfType(result.Department, typeof(OrganizationDepartment));

            Assert.IsNotNull(result.Title);
            Assert.IsInstanceOfType(result.Title, typeof(string));
            Assert.AreEqual(job.Title, result.Title);

            Assert.IsNotNull(result.Role);
            Assert.IsInstanceOfType(result.Role, typeof(Role));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(job.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(job.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(job.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(job.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}