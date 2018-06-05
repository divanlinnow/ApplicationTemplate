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
    public class TaskStatusDtoTests
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
        public void TaskStatusDto_Property_Name()
        {
            var taskStatus = new TaskStatusDto();
            var value = "Test Task Status";

            taskStatus.Name = value;

            Assert.IsNotNull(taskStatus.Name);
            Assert.IsInstanceOfType(taskStatus.Name, typeof(string));
            Assert.AreEqual(value, taskStatus.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskStatusDto_Property_Created()
        {
            var taskStatus = new TaskStatusDto();
            var value = DateTime.Now;

            taskStatus.Created = value;

            Assert.IsNotNull(taskStatus.Created);
            Assert.IsInstanceOfType(taskStatus.Created, typeof(DateTime));
            Assert.AreEqual(value, taskStatus.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskStatusDto_Property_CreatedBy()
        {
            var taskStatus = new TaskStatusDto();
            var value = Core.Tests.TestHelper.UserDto();

            taskStatus.CreatedBy = value;

            Assert.IsNotNull(taskStatus.CreatedBy);
            Assert.IsInstanceOfType(taskStatus.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, taskStatus.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskStatusDto_Property_Modified()
        {
            var taskStatus = new TaskStatusDto();
            var value = DateTime.Now;

            taskStatus.Modified = value;

            Assert.IsNotNull(taskStatus.Modified);
            Assert.IsInstanceOfType(taskStatus.Modified, typeof(DateTime));
            Assert.AreEqual(value, taskStatus.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskStatusDto_Property_ModifiedBy()
        {
            var taskStatus = new TaskStatusDto();
            var value = Core.Tests.TestHelper.UserDto();

            taskStatus.ModifiedBy = value;

            Assert.IsNotNull(taskStatus.ModifiedBy);
            Assert.IsInstanceOfType(taskStatus.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, taskStatus.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskStatusDto_Property_IsActive()
        {
            var taskStatus = new TaskStatusDto();
            var value = true;

            taskStatus.IsActive = value;

            Assert.IsNotNull(taskStatus.IsActive);
            Assert.IsInstanceOfType(taskStatus.IsActive, typeof(bool));
            Assert.AreEqual(value, taskStatus.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskStatusDto_Property_IsDeleted()
        {
            var taskStatus = new TaskStatusDto();
            var value = false;

            taskStatus.IsDeleted = value;

            Assert.IsNotNull(taskStatus.IsDeleted);
            Assert.IsInstanceOfType(taskStatus.IsDeleted, typeof(bool));
            Assert.AreEqual(value, taskStatus.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void TaskStatusDto_Property_Count()
        {
            var taskStatus = new TaskStatusDto();
            Assert.AreEqual(8, taskStatus.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void TaskStatusDto_Extension_AsEntity_Null()
        {
            TaskStatusDto taskStatus = null;
            var result = taskStatus.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void TaskStatusDto_Extension_AsEntity_NotNull()
        {
            var taskStatus = TestHelper.TaskStatusDto();
            var result = taskStatus.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TaskStatus));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(taskStatus.Name, result.Name);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(taskStatus.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(taskStatus.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(taskStatus.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(taskStatus.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}