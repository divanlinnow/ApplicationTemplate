using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Business;
using Domain.Entities.Business.Tests;
using Domain.Models.Business;
using Domain.Services.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core.Tests
{
    [TestClass]
    public class TaskServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private ITaskService taskService;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IRepository>();
            mockLogger = new Mock<ILogger>();
            mockCache = new Mock<ICache>();
            mockTelemetry = new Mock<ITelemetry>();
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllTasks_Service_Success()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Task>()).Returns(TestHelper.Tasks()).Verifiable();

            // Act
            var response = taskService.GetAllTasks();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<TaskDto>>));
            mockRepository.Verify(x => x.All<Task>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllTasks_Service_Fail()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Task>()).Throws(new Exception()).Verifiable();

            // Act
            var response = taskService.GetAllTasks();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<TaskDto>>));
            mockRepository.Verify(x => x.All<Task>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindTaskById_Service_Success()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Task>(Guid.Empty)).Returns(new Task()).Verifiable();

            // Act
            var response = taskService.FindTaskById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<TaskDto>));
            mockRepository.Verify(x => x.FindById<Task>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindTaskById_Service_Fail()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Task>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = taskService.FindTaskById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<TaskDto>));
            mockRepository.Verify(x => x.FindById<Task>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateTask_Service_Success()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Task>())).Returns(true).Verifiable();

            // Act
            var task = new TaskDto();
            var response = taskService.CreateTask(task);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Task>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateTask_Service_Fail()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Task>())).Returns(false).Verifiable();

            // Act
            var task = new TaskDto();
            var response = taskService.CreateTask(task);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Task>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateTask_Service_Success()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Task>())).Returns(true).Verifiable();

            // Act
            var task = new TaskDto();
            var response = taskService.UpdateTask(task);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Task>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateTask_Service_Fail()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Task>())).Returns(false).Verifiable();

            // Act
            var task = new TaskDto();
            var response = taskService.UpdateTask(task);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Task>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteTask_Service_Success()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Task>())).Returns(true).Verifiable();

            // Act
            var task = new TaskDto();
            var response = taskService.DeleteTask(task);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Task>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteTask_Service_Fail()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Task>())).Returns(false).Verifiable();

            // Act
            var task = new TaskDto();
            var response = taskService.DeleteTask(task);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Task>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteTaskById_Service_Success()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Task>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = taskService.DeleteTask(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Task>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteTaskById_Service_Fail()
        {
            // Arrange
            taskService = new TaskService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Task>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = taskService.DeleteTask(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Task>(Guid.Empty), Times.Once);
        }
    }
}