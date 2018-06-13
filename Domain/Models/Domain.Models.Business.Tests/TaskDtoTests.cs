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
    public class TaskDtoTests
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
        public void TaskDto_Property_Name()
        {
            var task = new TaskDto();
            var value = "Test Task";

            task.Name = value;

            Assert.IsNotNull(task.Name);
            Assert.IsInstanceOfType(task.Name, typeof(string));
            Assert.AreEqual(value, task.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_Description()
        {
            var task = new TaskDto();
            var value = "Test Task Description";

            task.Description = value;

            Assert.IsNotNull(task.Description);
            Assert.IsInstanceOfType(task.Description, typeof(string));
            Assert.AreEqual(value, task.Description);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_AssignedTo()
        {
            var task = new TaskDto();
            var value = TestHelper.EmployeeDto();

            task.AssignedTo = value;

            Assert.IsNotNull(task.AssignedTo);
            Assert.IsInstanceOfType(task.AssignedTo, typeof(EmployeeDto));
            Assert.AreEqual(value, task.AssignedTo);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_AssignedBy()
        {
            var task = new TaskDto();
            var value = TestHelper.EmployeeDto();

            task.AssignedBy = value;

            Assert.IsNotNull(task.AssignedBy);
            Assert.IsInstanceOfType(task.AssignedBy, typeof(EmployeeDto));
            Assert.AreEqual(value, task.AssignedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_EstimatedStart()
        {
            var task = new TaskDto();
            var value = DateTime.Now;

            task.EstimatedStart = value;

            Assert.IsNotNull(task.EstimatedStart);
            Assert.IsInstanceOfType(task.EstimatedStart, typeof(DateTime));
            Assert.AreEqual(value, task.EstimatedStart);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_EstimatedEnd()
        {
            var task = new TaskDto();
            var value = DateTime.Now;

            task.EstimatedEnd = value;

            Assert.IsNotNull(task.EstimatedEnd);
            Assert.IsInstanceOfType(task.EstimatedEnd, typeof(DateTime));
            Assert.AreEqual(value, task.EstimatedEnd);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_ActualStart()
        {
            var task = new TaskDto();
            var value = DateTime.Now;

            task.ActualStart = value;

            Assert.IsNotNull(task.ActualStart);
            Assert.IsInstanceOfType(task.ActualStart, typeof(DateTime));
            Assert.AreEqual(value, task.ActualStart);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_ActualEnd()
        {
            var task = new TaskDto();
            var value = DateTime.Now;

            task.ActualEnd = value;

            Assert.IsNotNull(task.ActualEnd);
            Assert.IsInstanceOfType(task.ActualEnd, typeof(DateTime));
            Assert.AreEqual(value, task.ActualEnd);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_Status()
        {
            var task = new TaskDto();
            var value = TestHelper.TaskStatusDto();

            task.Status = value;

            Assert.IsNotNull(task.Status);
            Assert.IsInstanceOfType(task.Status, typeof(TaskStatusDto));
            Assert.AreEqual(value, task.Status);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_Created()
        {
            var task = new TaskDto();
            var value = DateTime.Now;

            task.Created = value;

            Assert.IsNotNull(task.Created);
            Assert.IsInstanceOfType(task.Created, typeof(DateTime));
            Assert.AreEqual(value, task.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_CreatedBy()
        {
            var task = new TaskDto();
            var value = Core.Tests.TestHelper.UserDto();

            task.CreatedBy = value;

            Assert.IsNotNull(task.CreatedBy);
            Assert.IsInstanceOfType(task.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, task.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_Modified()
        {
            var task = new TaskDto();
            var value = DateTime.Now;

            task.Modified = value;

            Assert.IsNotNull(task.Modified);
            Assert.IsInstanceOfType(task.Modified, typeof(DateTime));
            Assert.AreEqual(value, task.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_ModifiedBy()
        {
            var task = new TaskDto();
            var value = Core.Tests.TestHelper.UserDto();

            task.ModifiedBy = value;

            Assert.IsNotNull(task.ModifiedBy);
            Assert.IsInstanceOfType(task.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, task.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_IsActive()
        {
            var task = new TaskDto();
            var value = true;

            task.IsActive = value;

            Assert.IsNotNull(task.IsActive);
            Assert.IsInstanceOfType(task.IsActive, typeof(bool));
            Assert.AreEqual(value, task.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_IsDeleted()
        {
            var task = new TaskDto();
            var value = false;

            task.IsDeleted = value;

            Assert.IsNotNull(task.IsDeleted);
            Assert.IsInstanceOfType(task.IsDeleted, typeof(bool));
            Assert.AreEqual(value, task.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskDto_Property_Count()
        {
            var task = new TaskDto();
            Assert.AreEqual(16, task.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void TaskDto_Extension_AsEntity_Null()
        {
            TaskDto task = null;
            var result = task.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void TaskDto_Extension_AsEntity_NotNull()
        {
            var task = TestHelper.TaskDto();
            var result = task.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Task));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(task.Name, result.Name);

            Assert.IsNotNull(result.Description);
            Assert.IsInstanceOfType(result.Description, typeof(string));
            Assert.AreEqual(task.Description, result.Description);

            Assert.IsNotNull(result.AssignedTo);
            Assert.IsInstanceOfType(result.AssignedTo, typeof(Employee));

            Assert.IsNotNull(result.AssignedBy);
            Assert.IsInstanceOfType(result.AssignedBy, typeof(Employee));

            Assert.IsNotNull(result.EstimatedStart);
            Assert.IsInstanceOfType(result.EstimatedStart, typeof(DateTime));
            Assert.AreEqual(task.EstimatedStart, result.EstimatedStart);

            Assert.IsNotNull(result.EstimatedEnd);
            Assert.IsInstanceOfType(result.EstimatedEnd, typeof(DateTime));
            Assert.AreEqual(task.EstimatedEnd, result.EstimatedEnd);

            Assert.IsNotNull(result.ActualStart);
            Assert.IsInstanceOfType(result.ActualStart, typeof(DateTime));
            Assert.AreEqual(task.ActualStart, result.ActualStart);

            Assert.IsNotNull(result.ActualEnd);
            Assert.IsInstanceOfType(result.ActualEnd, typeof(DateTime));
            Assert.AreEqual(task.ActualEnd, result.ActualEnd);

            Assert.IsNotNull(result.Status);
            Assert.IsInstanceOfType(result.Status, typeof(TaskStatus));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(task.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(task.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(task.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(task.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}