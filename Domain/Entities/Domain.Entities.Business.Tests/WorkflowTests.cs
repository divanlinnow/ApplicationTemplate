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
    public class WorkflowTests
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
        public void Workflow_Property_Name()
        {
            // Arrange
            var workflow = new Workflow();
            var value = "Test Workflow";

            // Act
            workflow.Name = value;

            // Assert
            Assert.IsNotNull(workflow.Name);
            Assert.IsInstanceOfType(workflow.Name, typeof(string));
            Assert.AreEqual(value, workflow.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_Description()
        {
            // Arrange
            var workflow = new Workflow();
            var value = "Test Workflow Description";

            // Act
            workflow.Description = value;

            // Assert
            Assert.IsNotNull(workflow.Description);
            Assert.IsInstanceOfType(workflow.Description, typeof(string));
            Assert.AreEqual(value, workflow.Description);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_Department()
        {
            // Arrange
            var workflow = new Workflow();
            var value = TestHelper.OrganizationDepartment();

            // Act
            workflow.Department = value;

            // Assert
            Assert.IsNotNull(workflow.Department);
            Assert.IsInstanceOfType(workflow.Department, typeof(OrganizationDepartment));
            Assert.AreEqual(value, workflow.Department);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_Employees()
        {
            // Arrange
            var workflow = new Workflow();
            var value = TestHelper.Employees();

            // Act
            workflow.Employees = value;

            // Assert
            Assert.IsNotNull(workflow.Employees);
            Assert.IsInstanceOfType(workflow.Employees, typeof(List<Employee>));
            Assert.AreEqual(value, workflow.Employees);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_Tasks()
        {
            // Arrange
            var workflow = new Workflow();
            var value = TestHelper.Tasks();

            // Act
            workflow.Tasks = value;

            // Assert
            Assert.IsNotNull(workflow.Tasks);
            Assert.IsInstanceOfType(workflow.Tasks, typeof(List<Task>));
            Assert.AreEqual(value, workflow.Tasks);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_Created()
        {
            // Arrange
            var workflow = new Workflow();
            var value = DateTime.Now;

            // Act
            workflow.Created = value;

            // Assert
            Assert.IsNotNull(workflow.Created);
            Assert.IsInstanceOfType(workflow.Created, typeof(DateTime));
            Assert.AreEqual(value, workflow.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_CreatedBy()
        {
            // Arrange
            var workflow = new Workflow();
            var value = Core.Tests.TestHelper.User();

            // Act
            workflow.CreatedBy = value;

            // Assert
            Assert.IsNotNull(workflow.CreatedBy);
            Assert.IsInstanceOfType(workflow.CreatedBy, typeof(User));
            Assert.AreEqual(value, workflow.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_Modified()
        {
            // Arrange
            var workflow = new Workflow();
            var value = DateTime.Now;

            // Act
            workflow.Modified = value;

            // Assert
            Assert.IsNotNull(workflow.Modified);
            Assert.IsInstanceOfType(workflow.Modified, typeof(DateTime));
            Assert.AreEqual(value, workflow.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_ModifiedBy()
        {
            // Arrange
            var workflow = new Workflow();
            var value = Core.Tests.TestHelper.User();

            // Act
            workflow.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(workflow.ModifiedBy);
            Assert.IsInstanceOfType(workflow.ModifiedBy, typeof(User));
            Assert.AreEqual(value, workflow.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_IsActive()
        {
            // Arrange
            var workflow = new Workflow();
            var value = true;

            // Act
            workflow.IsActive = value;

            // Assert
            Assert.IsNotNull(workflow.IsActive);
            Assert.IsInstanceOfType(workflow.IsActive, typeof(bool));
            Assert.AreEqual(value, workflow.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_IsDeleted()
        {
            // Arrange
            var workflow = new Workflow();
            var value = false;

            // Act
            workflow.IsDeleted = value;

            // Assert
            Assert.IsNotNull(workflow.IsDeleted);
            Assert.IsInstanceOfType(workflow.IsDeleted, typeof(bool));
            Assert.AreEqual(value, workflow.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Workflow_Property_Count()
        {
            var workflow = new Workflow();
            Assert.AreEqual(12, workflow.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Workflow_Extension_AsDTO_Null()
        {
            // Arrange
            Workflow workflow = null;

            // Act
            var result = workflow.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Workflow_Extension_AsDTO_NotNull()
        {
            // Arrange
            var workflow = TestHelper.Workflow();

            // Act
            var result = workflow.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(WorkflowDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(workflow.Name, result.Name);

            Assert.IsNotNull(result.Description);
            Assert.IsInstanceOfType(result.Description, typeof(string));
            Assert.AreEqual(workflow.Description, result.Description);

            Assert.IsNotNull(result.Department);
            Assert.IsInstanceOfType(result.Department, typeof(OrganizationDepartmentDto));

            Assert.IsNotNull(result.Employees);
            Assert.IsInstanceOfType(result.Employees, typeof(List<EmployeeDto>));

            Assert.IsNotNull(result.Tasks);
            Assert.IsInstanceOfType(result.Tasks, typeof(List<TaskDto>));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(workflow.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(workflow.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(workflow.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(workflow.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}