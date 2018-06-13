using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Entities.Business.Tests
{
    [TestClass]
    public class JobTests
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
        public void Job_Property_Organization()
        {
            // Arrange
            var job = new Job();
            var value = TestHelper.Organization();

            // Act
            job.Organization = value;

            // Assert
            Assert.IsNotNull(job.Organization);
            Assert.IsInstanceOfType(job.Organization, typeof(Organization));
            Assert.AreEqual(value, job.Organization);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_Branch()
        {
            // Arrange
            var job = new Job();
            var value = TestHelper.OrganizationBranch();

            // Act
            job.Branch = value;

            // Assert
            Assert.IsNotNull(job.Branch);
            Assert.IsInstanceOfType(job.Branch, typeof(OrganizationBranch));
            Assert.AreEqual(value, job.Branch);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_Department()
        {
            // Arrange
            var job = new Job();
            var value = TestHelper.OrganizationDepartment();

            // Act
            job.Department = value;

            // Assert
            Assert.IsNotNull(job.Department);
            Assert.IsInstanceOfType(job.Department, typeof(OrganizationDepartment));
            Assert.AreEqual(value, job.Department);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_Title()
        {
            // Arrange
            var job = new Job();
            var value = "Test Title";

            // Act
            job.Title = value;

            // Assert
            Assert.IsNotNull(job.Title);
            Assert.IsInstanceOfType(job.Title, typeof(string));
            Assert.AreEqual(value, job.Title);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_Role()
        {
            // Arrange
            var job = new Job();
            var value = Core.Tests.TestHelper.Role();

            // Act
            job.Role = value;

            // Assert
            Assert.IsNotNull(job.Role);
            Assert.IsInstanceOfType(job.Role, typeof(Role));
            Assert.AreEqual(value, job.Role);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_Created()
        {
            // Arrange
            var job = new Job();
            var value = DateTime.Now;

            // Act
            job.Created = value;

            // Assert
            Assert.IsNotNull(job.Created);
            Assert.IsInstanceOfType(job.Created, typeof(DateTime));
            Assert.AreEqual(value, job.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_CreatedBy()
        {
            // Arrange
            var job = new Job();
            var value = Core.Tests.TestHelper.User();

            // Act
            job.CreatedBy = value;

            // Assert
            Assert.IsNotNull(job.CreatedBy);
            Assert.IsInstanceOfType(job.CreatedBy, typeof(User));
            Assert.AreEqual(value, job.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_Modified()
        {
            // Arrange
            var job = new Job();
            var value = DateTime.Now;

            // Act
            job.Modified = value;

            // Assert
            Assert.IsNotNull(job.Modified);
            Assert.IsInstanceOfType(job.Modified, typeof(DateTime));
            Assert.AreEqual(value, job.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_ModifiedBy()
        {
            // Arrange
            var job = new Job();
            var value = Core.Tests.TestHelper.User();

            // Act
            job.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(job.ModifiedBy);
            Assert.IsInstanceOfType(job.ModifiedBy, typeof(User));
            Assert.AreEqual(value, job.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_IsActive()
        {
            // Arrange
            var job = new Job();
            var value = true;

            // Act
            job.IsActive = value;

            // Assert
            Assert.IsNotNull(job.IsActive);
            Assert.IsInstanceOfType(job.IsActive, typeof(bool));
            Assert.AreEqual(value, job.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Job_Property_IsDeleted()
        {
            // Arrange
            var job = new Job();
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
        [TestCategory("Entities - Properties")]
        public void Job_Property_Count()
        {
            var job = new Job();
            Assert.AreEqual(12, job.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Job_Extension_AsDTO_Null()
        {
            // Arrange
            Job job = null;

            // Act
            var result = job.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Job_Extension_AsDTO_NotNull()
        {
            // Arrange
            var job = TestHelper.Job();

            // Act
            var result = job.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(JobDto));

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(OrganizationDto));

            Assert.IsNotNull(result.Branch);
            Assert.IsInstanceOfType(result.Branch, typeof(OrganizationBranchDto));

            Assert.IsNotNull(result.Department);
            Assert.IsInstanceOfType(result.Department, typeof(OrganizationDepartmentDto));

            Assert.IsNotNull(result.Title);
            Assert.IsInstanceOfType(result.Title, typeof(string));
            Assert.AreEqual(job.Title, result.Title);

            Assert.IsNotNull(result.Role);
            Assert.IsInstanceOfType(result.Role, typeof(RoleDto));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(job.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(job.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

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