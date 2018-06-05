using Domain.Entities.Business;
using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Domain.Models.Business.Tests
{
    [TestClass]
    public class EmployeeDtoTests
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
        public void EmployeeDto_Property_User()
        {
            // Arrange
            var employee = new EmployeeDto();
            var value = Core.Tests.TestHelper.UserDto();

            // Act
            employee.User = value;

            // Assert
            Assert.IsNotNull(employee.User);
            Assert.IsInstanceOfType(employee.User, typeof(UserDto));
            Assert.AreEqual(value, employee.User);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmployeeDto_Property_Organization()
        {
            // Arrange
            var employee = new EmployeeDto();
            var value = TestHelper.OrganizationDto();

            // Act
            employee.Organization = value;

            // Assert
            Assert.IsNotNull(employee.Organization);
            Assert.IsInstanceOfType(employee.Organization, typeof(OrganizationDto));
            Assert.AreEqual(value, employee.Organization);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmployeeDto_Property_Branch()
        {
            // Arrange
            var employee = new EmployeeDto();
            var value = TestHelper.OrganizationBranchDto();

            // Act
            employee.Branch = value;

            // Assert
            Assert.IsNotNull(employee.Branch);
            Assert.IsInstanceOfType(employee.Branch, typeof(OrganizationBranchDto));
            Assert.AreEqual(value, employee.Branch);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmployeeDto_Property_Department()
        {
            // Arrange
            var employee = new EmployeeDto();
            var value = TestHelper.OrganizationDepartmentDto();

            // Act
            employee.Department = value;

            // Assert
            Assert.IsNotNull(employee.Department);
            Assert.IsInstanceOfType(employee.Department, typeof(OrganizationDepartmentDto));
            Assert.AreEqual(value, employee.Department);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmployeeDto_Property_Job()
        {
            // Arrange
            var employee = new EmployeeDto();
            var value = TestHelper.JobDto();

            // Act
            employee.Job = value;

            // Assert
            Assert.IsNotNull(employee.Job);
            Assert.IsInstanceOfType(employee.Job, typeof(JobDto));
            Assert.AreEqual(value, employee.Job);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmployeeDto_Property_Count()
        {
            var employee = new EmployeeDto();
            Assert.AreEqual(6, employee.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void EmployeeDto_Extension_AsEntity_Null()
        {
            // Arrange
            EmployeeDto employee = null;

            // Act
            var result = employee.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void EmployeeDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var employee = TestHelper.EmployeeDto();

            // Act
            var result = employee.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Employee));

            Assert.IsNotNull(result.User);
            Assert.IsInstanceOfType(result.User, typeof(User));

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(Organization));

            Assert.IsNotNull(result.Branch);
            Assert.IsInstanceOfType(result.Branch, typeof(OrganizationBranch));

            Assert.IsNotNull(result.Department);
            Assert.IsInstanceOfType(result.Department, typeof(OrganizationDepartment));

            Assert.IsNotNull(result.Job);
            Assert.IsInstanceOfType(result.Job, typeof(Job));
        }

        #endregion Extensions Tests
    }
}