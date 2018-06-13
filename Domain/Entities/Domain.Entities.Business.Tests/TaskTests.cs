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
    public class TaskTests
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
        public void Task_Property_Name()
        {
            // Arrange
            var task = new Task();
            var value = "Test Task";

            // Act
            task.Name = value;

            // Assert
            Assert.IsNotNull(task.Name);
            Assert.IsInstanceOfType(task.Name, typeof(string));
            Assert.AreEqual(value, task.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_Description()
        {
            // Arrange
            var task = new Task();
            var value = "Test Task Description";

            // Act
            task.Description = value;

            // Assert
            Assert.IsNotNull(task.Description);
            Assert.IsInstanceOfType(task.Description, typeof(string));
            Assert.AreEqual(value, task.Description);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_AssignedTo()
        {
            // Arrange
            var task = new Task();
            var value = TestHelper.Employee();

            // Act
            task.AssignedTo = value;

            // Assert
            Assert.IsNotNull(task.AssignedTo);
            Assert.IsInstanceOfType(task.AssignedTo, typeof(Employee));
            Assert.AreEqual(value, task.AssignedTo);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_AssignedBy()
        {
            // Arrange
            var task = new Task();
            var value = TestHelper.Employee();

            // Act
            task.AssignedBy = value;

            // Assert
            Assert.IsNotNull(task.AssignedBy);
            Assert.IsInstanceOfType(task.AssignedBy, typeof(Employee));
            Assert.AreEqual(value, task.AssignedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_EstimatedStart()
        {
            // Arrange
            var task = new Task();
            var value = DateTime.Now;

            // Act
            task.EstimatedStart = value;

            // Assert
            Assert.IsNotNull(task.EstimatedStart);
            Assert.IsInstanceOfType(task.EstimatedStart, typeof(DateTime));
            Assert.AreEqual(value, task.EstimatedStart);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_EstimatedEnd()
        {
            // Arrange
            var task = new Task();
            var value = DateTime.Now;

            // Act
            task.EstimatedEnd = value;

            // Assert
            Assert.IsNotNull(task.EstimatedEnd);
            Assert.IsInstanceOfType(task.EstimatedEnd, typeof(DateTime));
            Assert.AreEqual(value, task.EstimatedEnd);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_ActualStart()
        {
            // Arrange
            var task = new Task();
            var value = DateTime.Now;

            // Act
            task.ActualStart = value;

            // Assert
            Assert.IsNotNull(task.ActualStart);
            Assert.IsInstanceOfType(task.ActualStart, typeof(DateTime));
            Assert.AreEqual(value, task.ActualStart);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_ActualEnd()
        {
            // Arrange
            var task = new Task();
            var value = DateTime.Now;

            // Act
            task.ActualEnd = value;

            // Assert
            Assert.IsNotNull(task.ActualEnd);
            Assert.IsInstanceOfType(task.ActualEnd, typeof(DateTime));
            Assert.AreEqual(value, task.ActualEnd);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_Status()
        {
            // Arrange
            var task = new Task();
            var value = TestHelper.TaskStatus();

            // Act
            task.Status = value;

            // Assert
            Assert.IsNotNull(task.Status);
            Assert.IsInstanceOfType(task.Status, typeof(TaskStatus));
            Assert.AreEqual(value, task.Status);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_Created()
        {
            // Arrange
            var task = new Task();
            var value = DateTime.Now;

            // Act
            task.Created = value;

            // Assert
            Assert.IsNotNull(task.Created);
            Assert.IsInstanceOfType(task.Created, typeof(DateTime));
            Assert.AreEqual(value, task.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_CreatedBy()
        {
            // Arrange
            var task = new Task();
            var value = Core.Tests.TestHelper.User();

            // Act
            task.CreatedBy = value;

            // Assert
            Assert.IsNotNull(task.CreatedBy);
            Assert.IsInstanceOfType(task.CreatedBy, typeof(User));
            Assert.AreEqual(value, task.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_Modified()
        {
            // Arrange
            var task = new Task();
            var value = DateTime.Now;

            // Act
            task.Modified = value;

            // Assert
            Assert.IsNotNull(task.Modified);
            Assert.IsInstanceOfType(task.Modified, typeof(DateTime));
            Assert.AreEqual(value, task.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_ModifiedBy()
        {
            // Arrange
            var task = new Task();
            var value = Core.Tests.TestHelper.User();

            // Act
            task.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(task.ModifiedBy);
            Assert.IsInstanceOfType(task.ModifiedBy, typeof(User));
            Assert.AreEqual(value, task.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_IsActive()
        {
            // Arrange
            var task = new Task();
            var value = true;

            // Act
            task.IsActive = value;

            // Assert
            Assert.IsNotNull(task.IsActive);
            Assert.IsInstanceOfType(task.IsActive, typeof(bool));
            Assert.AreEqual(value, task.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_IsDeleted()
        {
            // Arrange
            var task = new Task();
            var value = false;

            // Act
            task.IsDeleted = value;

            // Assert
            Assert.IsNotNull(task.IsDeleted);
            Assert.IsInstanceOfType(task.IsDeleted, typeof(bool));
            Assert.AreEqual(value, task.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Task_Property_Count()
        {
            var task = new Task();
            Assert.AreEqual(16, task.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Task_Extension_AsDTO_Null()
        {
            // Arrange
            Task task = null;

            // Act
            var result = task.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Task_Extension_AsDTO_NotNull()
        {
            // Arrange
            var task = TestHelper.Task();

            // Act
            var result = task.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(TaskDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(task.Name, result.Name);

            Assert.IsNotNull(result.Description);
            Assert.IsInstanceOfType(result.Description, typeof(string));
            Assert.AreEqual(task.Description, result.Description);

            Assert.IsNotNull(result.AssignedTo);
            Assert.IsInstanceOfType(result.AssignedTo, typeof(EmployeeDto));

            Assert.IsNotNull(result.AssignedBy);
            Assert.IsInstanceOfType(result.AssignedBy, typeof(EmployeeDto));

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
            Assert.IsInstanceOfType(result.Status, typeof(TaskStatusDto));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(task.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(task.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

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