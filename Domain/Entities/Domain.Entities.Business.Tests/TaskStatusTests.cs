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
    public class TaskStatusTests
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
        public void TaskStatus_Property_Name()
        {
            // Arrange
            var taskStatus = new TaskStatus();
            var value = "Test Task Status";

            // Act
            taskStatus.Name = value;

            // Assert
            Assert.IsNotNull(taskStatus.Name);
            Assert.IsInstanceOfType(taskStatus.Name, typeof(string));
            Assert.AreEqual(value, taskStatus.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void TaskStatus_Property_Created()
        {
            // Arrange
            var taskStatus = new TaskStatus();
            var value = DateTime.Now;

            // Act
            taskStatus.Created = value;

            // Assert
            Assert.IsNotNull(taskStatus.Created);
            Assert.IsInstanceOfType(taskStatus.Created, typeof(DateTime));
            Assert.AreEqual(value, taskStatus.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void TaskStatus_Property_CreatedBy()
        {
            // Arrange
            var taskStatus = new TaskStatus();
            var value = Core.Tests.TestHelper.User();

            // Act
            taskStatus.CreatedBy = value;

            // Assert
            Assert.IsNotNull(taskStatus.CreatedBy);
            Assert.IsInstanceOfType(taskStatus.CreatedBy, typeof(User));
            Assert.AreEqual(value, taskStatus.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void TaskStatus_Property_Modified()
        {
            // Arrange
            var taskStatus = new TaskStatus();
            var value = DateTime.Now;

            // Act
            taskStatus.Modified = value;

            // Assert
            Assert.IsNotNull(taskStatus.Modified);
            Assert.IsInstanceOfType(taskStatus.Modified, typeof(DateTime));
            Assert.AreEqual(value, taskStatus.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void TaskStatus_Property_ModifiedBy()
        {
            // Arrange
            var taskStatus = new TaskStatus();
            var value = Core.Tests.TestHelper.User();

            // Act
            taskStatus.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(taskStatus.ModifiedBy);
            Assert.IsInstanceOfType(taskStatus.ModifiedBy, typeof(User));
            Assert.AreEqual(value, taskStatus.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void TaskStatus_Property_IsActive()
        {
            // Arrange
            var taskStatus = new TaskStatus();
            var value = true;

            // Act
            taskStatus.IsActive = value;

            // Assert
            Assert.IsNotNull(taskStatus.IsActive);
            Assert.IsInstanceOfType(taskStatus.IsActive, typeof(bool));
            Assert.AreEqual(value, taskStatus.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void TaskStatus_Property_IsDeleted()
        {
            // Arrange
            var taskStatus = new TaskStatus();
            var value = false;

            // Act
            taskStatus.IsDeleted = value;

            // Assert
            Assert.IsNotNull(taskStatus.IsDeleted);
            Assert.IsInstanceOfType(taskStatus.IsDeleted, typeof(bool));
            Assert.AreEqual(value, taskStatus.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void TaskStatus_Property_Count()
        {
            var taskStatus = new TaskStatus();
            Assert.AreEqual(8, taskStatus.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void TaskStatus_Extension_AsDTO_Null()
        {
            // Arrange
            TaskStatus taskStatus = null;

            // Act
            var result = taskStatus.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void TaskStatus_Extension_AsDTO_NotNull()
        {
            // Arrange
            var taskStatus = TestHelper.TaskStatus();

            // Act
            var result = taskStatus.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TaskStatusDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(taskStatus.Name, result.Name);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(taskStatus.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(taskStatus.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

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