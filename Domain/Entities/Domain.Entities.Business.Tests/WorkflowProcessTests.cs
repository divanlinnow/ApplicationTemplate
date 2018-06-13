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
    public class WorkflowProcessTests
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
        public void WorkflowProcess_Property_Name()
        {
            var workflowProcess = new WorkflowProcess();
            var value = "Test Workflow Process";

            workflowProcess.Name = value;

            Assert.IsNotNull(workflowProcess.Name);
            Assert.IsInstanceOfType(workflowProcess.Name, typeof(string));
            Assert.AreEqual(value, workflowProcess.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_Description()
        {
            var workflowProcess = new WorkflowProcess();
            var value = "Test Workflow Process Description";

            workflowProcess.Description = value;

            Assert.IsNotNull(workflowProcess.Description);
            Assert.IsInstanceOfType(workflowProcess.Description, typeof(string));
            Assert.AreEqual(value, workflowProcess.Description);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_Department()
        {
            var workflowProcess = new WorkflowProcess();
            var value = TestHelper.OrganizationDepartment();

            workflowProcess.Department = value;

            Assert.IsNotNull(workflowProcess.Department);
            Assert.IsInstanceOfType(workflowProcess.Department, typeof(OrganizationDepartment));
            Assert.AreEqual(value, workflowProcess.Department);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_Employees()
        {
            var workflowProcess = new WorkflowProcess();
            var value = TestHelper.Employees();

            workflowProcess.Employees = value;

            Assert.IsNotNull(workflowProcess.Employees);
            Assert.IsInstanceOfType(workflowProcess.Employees, typeof(List<Employee>));
            Assert.AreEqual(value, workflowProcess.Employees);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_Tasks()
        {
            var workflowProcess = new WorkflowProcess();
            var value = TestHelper.Tasks();

            workflowProcess.Tasks = value;

            Assert.IsNotNull(workflowProcess.Tasks);
            Assert.IsInstanceOfType(workflowProcess.Tasks, typeof(List<Task>));
            Assert.AreEqual(value, workflowProcess.Tasks);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_Created()
        {
            var workflowProcess = new WorkflowProcess();
            var value = DateTime.Now;

            workflowProcess.Created = value;

            Assert.IsNotNull(workflowProcess.Created);
            Assert.IsInstanceOfType(workflowProcess.Created, typeof(DateTime));
            Assert.AreEqual(value, workflowProcess.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_CreatedBy()
        {
            var workflowProcess = new WorkflowProcess();
            var value = Core.Tests.TestHelper.User();

            workflowProcess.CreatedBy = value;

            Assert.IsNotNull(workflowProcess.CreatedBy);
            Assert.IsInstanceOfType(workflowProcess.CreatedBy, typeof(User));
            Assert.AreEqual(value, workflowProcess.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_Modified()
        {
            var workflowProcess = new WorkflowProcess();
            var value = DateTime.Now;

            workflowProcess.Modified = value;

            Assert.IsNotNull(workflowProcess.Modified);
            Assert.IsInstanceOfType(workflowProcess.Modified, typeof(DateTime));
            Assert.AreEqual(value, workflowProcess.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_ModifiedBy()
        {
            var workflowProcess = new WorkflowProcess();
            var value = Core.Tests.TestHelper.User();

            workflowProcess.ModifiedBy = value;

            Assert.IsNotNull(workflowProcess.ModifiedBy);
            Assert.IsInstanceOfType(workflowProcess.ModifiedBy, typeof(User));
            Assert.AreEqual(value, workflowProcess.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_IsActive()
        {
            var workflowProcess = new WorkflowProcess();
            var value = true;

            workflowProcess.IsActive = value;

            Assert.IsNotNull(workflowProcess.IsActive);
            Assert.IsInstanceOfType(workflowProcess.IsActive, typeof(bool));
            Assert.AreEqual(value, workflowProcess.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_IsDeleted()
        {
            var workflowProcess = new WorkflowProcess();
            var value = false;

            workflowProcess.IsDeleted = value;

            Assert.IsNotNull(workflowProcess.IsDeleted);
            Assert.IsInstanceOfType(workflowProcess.IsDeleted, typeof(bool));
            Assert.AreEqual(value, workflowProcess.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProcess_Property_Count()
        {
            var workflowProcess = new WorkflowProcess();
            Assert.AreEqual(12, workflowProcess.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void WorkflowProcess_Extension_AsDTO_Null()
        {
            WorkflowProcess workflowProcess = null;
            var result = workflowProcess.AsDto();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void WorkflowProcess_Extension_AsDTO_NotNull()
        {
            var workflowProcess = TestHelper.WorkflowProcess();
            var result = workflowProcess.AsDto();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(WorkflowProcessDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(workflowProcess.Name, result.Name);

            Assert.IsNotNull(result.Description);
            Assert.IsInstanceOfType(result.Description, typeof(string));
            Assert.AreEqual(workflowProcess.Description, result.Description);

            Assert.IsNotNull(result.Department);
            Assert.IsInstanceOfType(result.Department, typeof(OrganizationDepartmentDto));

            Assert.IsNotNull(result.Employees);
            Assert.IsInstanceOfType(result.Employees, typeof(List<EmployeeDto>));

            Assert.IsNotNull(result.Tasks);
            Assert.IsInstanceOfType(result.Tasks, typeof(List<TaskDto>));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(workflowProcess.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(workflowProcess.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

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