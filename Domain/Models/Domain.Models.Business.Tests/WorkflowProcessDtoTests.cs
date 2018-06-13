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
    public class WorkflowProcessDtoTests
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
        public void WorkflowProcessDto_Property_Name()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = "Test Workflow Process";

            workflowProcess.Name = value;

            Assert.IsNotNull(workflowProcess.Name);
            Assert.IsInstanceOfType(workflowProcess.Name, typeof(string));
            Assert.AreEqual(value, workflowProcess.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_Description()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = "Test Workflow Process Description";

            workflowProcess.Description = value;

            Assert.IsNotNull(workflowProcess.Description);
            Assert.IsInstanceOfType(workflowProcess.Description, typeof(string));
            Assert.AreEqual(value, workflowProcess.Description);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_Department()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = TestHelper.OrganizationDepartmentDto();

            workflowProcess.Department = value;

            Assert.IsNotNull(workflowProcess.Department);
            Assert.IsInstanceOfType(workflowProcess.Department, typeof(OrganizationDepartmentDto));
            Assert.AreEqual(value, workflowProcess.Department);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_Employees()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = TestHelper.EmployeeDtos();

            workflowProcess.Employees = value;

            Assert.IsNotNull(workflowProcess.Employees);
            Assert.IsInstanceOfType(workflowProcess.Employees, typeof(List<EmployeeDto>));
            Assert.AreEqual(value, workflowProcess.Employees);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_Tasks()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = TestHelper.TaskDtos();

            workflowProcess.Tasks = value;

            Assert.IsNotNull(workflowProcess.Tasks);
            Assert.IsInstanceOfType(workflowProcess.Tasks, typeof(List<TaskDto>));
            Assert.AreEqual(value, workflowProcess.Tasks);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_Created()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = DateTime.Now;

            workflowProcess.Created = value;

            Assert.IsNotNull(workflowProcess.Created);
            Assert.IsInstanceOfType(workflowProcess.Created, typeof(DateTime));
            Assert.AreEqual(value, workflowProcess.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_CreatedBy()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = Core.Tests.TestHelper.UserDto();

            workflowProcess.CreatedBy = value;

            Assert.IsNotNull(workflowProcess.CreatedBy);
            Assert.IsInstanceOfType(workflowProcess.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, workflowProcess.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_Modified()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = DateTime.Now;

            workflowProcess.Modified = value;

            Assert.IsNotNull(workflowProcess.Modified);
            Assert.IsInstanceOfType(workflowProcess.Modified, typeof(DateTime));
            Assert.AreEqual(value, workflowProcess.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_ModifiedBy()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = Core.Tests.TestHelper.UserDto();

            workflowProcess.ModifiedBy = value;

            Assert.IsNotNull(workflowProcess.ModifiedBy);
            Assert.IsInstanceOfType(workflowProcess.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, workflowProcess.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_IsActive()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = true;

            workflowProcess.IsActive = value;

            Assert.IsNotNull(workflowProcess.IsActive);
            Assert.IsInstanceOfType(workflowProcess.IsActive, typeof(bool));
            Assert.AreEqual(value, workflowProcess.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_IsDeleted()
        {
            var workflowProcess = new WorkflowProcessDto();
            var value = false;

            workflowProcess.IsDeleted = value;

            Assert.IsNotNull(workflowProcess.IsDeleted);
            Assert.IsInstanceOfType(workflowProcess.IsDeleted, typeof(bool));
            Assert.AreEqual(value, workflowProcess.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void WorkflowProcessDto_Property_Count()
        {
            var workflowProcess = new WorkflowProcessDto();
            Assert.AreEqual(12, workflowProcess.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void WorkflowProcessDto_Extension_AsEntity_Null()
        {
            WorkflowProcessDto workflowProcess = null;
            var result = workflowProcess.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void WorkflowProcessDto_Extension_AsEntity_NotNull()
        {
            var workflowProcess = TestHelper.WorkflowProcess();
            var result = workflowProcess.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(WorkflowProcess));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(workflowProcess.Name, result.Name);

            Assert.IsNotNull(result.Description);
            Assert.IsInstanceOfType(result.Description, typeof(string));
            Assert.AreEqual(workflowProcess.Description, result.Description);

            Assert.IsNotNull(result.Department);
            Assert.IsInstanceOfType(result.Department, typeof(OrganizationDepartment));

            Assert.IsNotNull(result.Employees);
            Assert.IsInstanceOfType(result.Employees, typeof(List<Employee>));

            Assert.IsNotNull(result.Tasks);
            Assert.IsInstanceOfType(result.Tasks, typeof(List<Task>));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(workflowProcess.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(workflowProcess.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(workflowProcess.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(workflowProcess.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}