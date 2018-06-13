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
    public class WorkflowProjectTests
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
        public void WorkflowProject_Property_Name()
        {
            var workflowProject = new WorkflowProject();
            var value = "Test Workflow Project";

            workflowProject.Name = value;

            Assert.IsNotNull(workflowProject.Name);
            Assert.IsInstanceOfType(workflowProject.Name, typeof(string));
            Assert.AreEqual(value, workflowProject.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_Description()
        {
            var workflowProject = new WorkflowProject();
            var value = "Test Workflow Project Description";

            workflowProject.Description = value;

            Assert.IsNotNull(workflowProject.Description);
            Assert.IsInstanceOfType(workflowProject.Description, typeof(string));
            Assert.AreEqual(value, workflowProject.Description);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_Department()
        {
            var workflowProject = new WorkflowProject();
            var value = TestHelper.OrganizationDepartment();

            workflowProject.Department = value;

            Assert.IsNotNull(workflowProject.Department);
            Assert.IsInstanceOfType(workflowProject.Department, typeof(OrganizationDepartment));
            Assert.AreEqual(value, workflowProject.Department);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_Employees()
        {
            var workflowProject = new WorkflowProject();
            var value = TestHelper.Employees();

            workflowProject.Employees = value;

            Assert.IsNotNull(workflowProject.Employees);
            Assert.IsInstanceOfType(workflowProject.Employees, typeof(List<Employee>));
            Assert.AreEqual(value, workflowProject.Employees);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_Tasks()
        {
            var workflowProject = new WorkflowProject();
            var value = TestHelper.Tasks();

            workflowProject.Tasks = value;

            Assert.IsNotNull(workflowProject.Tasks);
            Assert.IsInstanceOfType(workflowProject.Tasks, typeof(List<Task>));
            Assert.AreEqual(value, workflowProject.Tasks);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_Created()
        {
            var workflowProject = new WorkflowProject();
            var value = DateTime.Now;

            workflowProject.Created = value;

            Assert.IsNotNull(workflowProject.Created);
            Assert.IsInstanceOfType(workflowProject.Created, typeof(DateTime));
            Assert.AreEqual(value, workflowProject.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_CreatedBy()
        {
            var workflowProject = new WorkflowProject();
            var value = Core.Tests.TestHelper.User();

            workflowProject.CreatedBy = value;

            Assert.IsNotNull(workflowProject.CreatedBy);
            Assert.IsInstanceOfType(workflowProject.CreatedBy, typeof(User));
            Assert.AreEqual(value, workflowProject.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_Modified()
        {
            var workflowProject = new WorkflowProject();
            var value = DateTime.Now;

            workflowProject.Modified = value;

            Assert.IsNotNull(workflowProject.Modified);
            Assert.IsInstanceOfType(workflowProject.Modified, typeof(DateTime));
            Assert.AreEqual(value, workflowProject.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_ModifiedBy()
        {
            var workflowProject = new WorkflowProject();
            var value = Core.Tests.TestHelper.User();

            workflowProject.ModifiedBy = value;

            Assert.IsNotNull(workflowProject.ModifiedBy);
            Assert.IsInstanceOfType(workflowProject.ModifiedBy, typeof(User));
            Assert.AreEqual(value, workflowProject.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_IsActive()
        {
            var workflowProject = new WorkflowProject();
            var value = true;

            workflowProject.IsActive = value;

            Assert.IsNotNull(workflowProject.IsActive);
            Assert.IsInstanceOfType(workflowProject.IsActive, typeof(bool));
            Assert.AreEqual(value, workflowProject.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_IsDeleted()
        {
            var workflowProject = new WorkflowProject();
            var value = false;

            workflowProject.IsDeleted = value;

            Assert.IsNotNull(workflowProject.IsDeleted);
            Assert.IsInstanceOfType(workflowProject.IsDeleted, typeof(bool));
            Assert.AreEqual(value, workflowProject.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void WorkflowProject_Property_Count()
        {
            var workflowProject = new WorkflowProject();
            Assert.AreEqual(12, workflowProject.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void WorkflowProject_Extension_AsDTO_Null()
        {
            WorkflowProject workflowProject = null;
            var result = workflowProject.AsDto();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void WorkflowProject_Extension_AsDTO_NotNull()
        {
            var workflowProject = TestHelper.WorkflowProject();
            var result = workflowProject.AsDto();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(WorkflowProjectDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(workflowProject.Name, result.Name);

            Assert.IsNotNull(result.Description);
            Assert.IsInstanceOfType(result.Description, typeof(string));
            Assert.AreEqual(workflowProject.Description, result.Description);

            Assert.IsNotNull(result.Department);
            Assert.IsInstanceOfType(result.Department, typeof(OrganizationDepartmentDto));

            Assert.IsNotNull(result.Employees);
            Assert.IsInstanceOfType(result.Employees, typeof(List<EmployeeDto>));

            Assert.IsNotNull(result.Tasks);
            Assert.IsInstanceOfType(result.Tasks, typeof(List<TaskDto>));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(workflowProject.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(workflowProject.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(workflowProject.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(workflowProject.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}