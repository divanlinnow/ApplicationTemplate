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
    public class WorkflowDtoTests
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
        public void WorkflowDto_Property_Name()
        {
            var workflow = new WorkflowDto();
            var value = "Test Workflow";

            workflow.Name = value;

            Assert.IsNotNull(workflow.Name);
            Assert.IsInstanceOfType(workflow.Name, typeof(string));
            Assert.AreEqual(value, workflow.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_Description()
        {
            var workflow = new WorkflowDto();
            var value = "Test Workflow Description";

            workflow.Description = value;

            Assert.IsNotNull(workflow.Description);
            Assert.IsInstanceOfType(workflow.Description, typeof(string));
            Assert.AreEqual(value, workflow.Description);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_Department()
        {
            var workflow = new WorkflowDto();
            var value = TestHelper.OrganizationDepartmentDto();

            workflow.Department = value;

            Assert.IsNotNull(workflow.Department);
            Assert.IsInstanceOfType(workflow.Department, typeof(OrganizationDepartmentDto));
            Assert.AreEqual(value, workflow.Department);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_Employees()
        {
            var workflow = new WorkflowDto();
            var value = TestHelper.EmployeeDtos();

            workflow.Employees = value;

            Assert.IsNotNull(workflow.Employees);
            Assert.IsInstanceOfType(workflow.Employees, typeof(List<EmployeeDto>));
            Assert.AreEqual(value, workflow.Employees);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_Tasks()
        {
            var workflow = new WorkflowDto();
            var value = TestHelper.TaskDtos();

            workflow.Tasks = value;

            Assert.IsNotNull(workflow.Tasks);
            Assert.IsInstanceOfType(workflow.Tasks, typeof(List<TaskDto>));
            Assert.AreEqual(value, workflow.Tasks);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_Created()
        {
            var workflow = new WorkflowDto();
            var value = DateTime.Now;

            workflow.Created = value;

            Assert.IsNotNull(workflow.Created);
            Assert.IsInstanceOfType(workflow.Created, typeof(DateTime));
            Assert.AreEqual(value, workflow.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_CreatedBy()
        {
            var workflow = new WorkflowDto();
            var value = Core.Tests.TestHelper.UserDto();

            workflow.CreatedBy = value;

            Assert.IsNotNull(workflow.CreatedBy);
            Assert.IsInstanceOfType(workflow.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, workflow.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_Modified()
        {
            var workflow = new WorkflowDto();
            var value = DateTime.Now;

            workflow.Modified = value;

            Assert.IsNotNull(workflow.Modified);
            Assert.IsInstanceOfType(workflow.Modified, typeof(DateTime));
            Assert.AreEqual(value, workflow.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_ModifiedBy()
        {
            var workflow = new WorkflowDto();
            var value = Core.Tests.TestHelper.UserDto();

            workflow.ModifiedBy = value;

            Assert.IsNotNull(workflow.ModifiedBy);
            Assert.IsInstanceOfType(workflow.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, workflow.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_IsActive()
        {
            var workflow = new WorkflowDto();
            var value = true;

            workflow.IsActive = value;

            Assert.IsNotNull(workflow.IsActive);
            Assert.IsInstanceOfType(workflow.IsActive, typeof(bool));
            Assert.AreEqual(value, workflow.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_IsDeleted()
        {
            var workflow = new WorkflowDto();
            var value = false;

            workflow.IsDeleted = value;

            Assert.IsNotNull(workflow.IsDeleted);
            Assert.IsInstanceOfType(workflow.IsDeleted, typeof(bool));
            Assert.AreEqual(value, workflow.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowDto_Property_Count()
        {
            var workflow = new WorkflowDto();
            Assert.AreEqual(12, workflow.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void WorkflowDto_Extension_AsEntity_Null()
        {
            WorkflowDto workflow = null;
            var result = workflow.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void WorkflowDto_Extension_AsEntity_NotNull()
        {
            var workflow = TestHelper.WorkflowDto();
            var result = workflow.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Workflow));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(workflow.Name, result.Name);

            Assert.IsNotNull(result.Description);
            Assert.IsInstanceOfType(result.Description, typeof(string));
            Assert.AreEqual(workflow.Description, result.Description);

            Assert.IsNotNull(result.Department);
            Assert.IsInstanceOfType(result.Department, typeof(OrganizationDepartment));

            Assert.IsNotNull(result.Employees);
            Assert.IsInstanceOfType(result.Employees, typeof(List<Employee>));

            Assert.IsNotNull(result.Tasks);
            Assert.IsInstanceOfType(result.Tasks, typeof(List<Task>));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(workflow.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(workflow.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

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