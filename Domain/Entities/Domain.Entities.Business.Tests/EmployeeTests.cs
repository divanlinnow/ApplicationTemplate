using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Domain.Entities.Business.Tests
{
    [TestClass]
    public class EmployeeTests
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
        public void Employee_Property_User()
        {
            // Arrange
            var employee = new Employee();
            var value = Core.Tests.TestHelper.User();

            // Act
            employee.User = value;

            // Assert
            Assert.IsNotNull(employee.User);
            Assert.IsInstanceOfType(employee.User, typeof(User));
            Assert.AreEqual(value, employee.User);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Employee_Property_Organization()
        {
            // Arrange
            var employee = new Employee();
            var value = TestHelper.Organization();

            // Act
            employee.Organization = value;

            // Assert
            Assert.IsNotNull(employee.Organization);
            Assert.IsInstanceOfType(employee.Organization, typeof(Organization));
            Assert.AreEqual(value, employee.Organization);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Employee_Property_Branch()
        {
            // Arrange
            var employee = new Employee();
            var value = TestHelper.OrganizationBranch();

            // Act
            employee.Branch = value;

            // Assert
            Assert.IsNotNull(employee.Branch);
            Assert.IsInstanceOfType(employee.Branch, typeof(OrganizationBranch));
            Assert.AreEqual(value, employee.Branch);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Employee_Property_Department()
        {
            // Arrange
            var employee = new Employee();
            var value = TestHelper.OrganizationDepartment();

            // Act
            employee.Department = value;

            // Assert
            Assert.IsNotNull(employee.Department);
            Assert.IsInstanceOfType(employee.Department, typeof(OrganizationDepartment));
            Assert.AreEqual(value, employee.Department);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Employee_Property_Job()
        {
            // Arrange
            var employee = new Employee();
            var value = TestHelper.Job();

            // Act
            employee.Job = value;

            // Assert
            Assert.IsNotNull(employee.Job);
            Assert.IsInstanceOfType(employee.Job, typeof(Job));
            Assert.AreEqual(value, employee.Job);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Employee_Property_Count()
        {
            var employee = new Employee();
            Assert.AreEqual(6, employee.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Employee_Extension_AsDTO_Null()
        {
            // Arrange
            Employee employee = null;

            // Act
            var result = employee.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Employee_Extension_AsDTO_NotNull()
        {
            // Arrange
            var employee = TestHelper.Employee();

            // Act
            var result = employee.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(EmployeeDto));

            Assert.IsNotNull(result.User);
            Assert.IsInstanceOfType(result.User, typeof(UserDto));

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(OrganizationDto));

            Assert.IsNotNull(result.Branch);
            Assert.IsInstanceOfType(result.Branch, typeof(OrganizationBranchDto));

            Assert.IsNotNull(result.Department);
            Assert.IsInstanceOfType(result.Department, typeof(OrganizationDepartmentDto));

            Assert.IsNotNull(result.Job);
            Assert.IsInstanceOfType(result.Job, typeof(JobDto));
        }

        #endregion Extensions Tests
    }
}