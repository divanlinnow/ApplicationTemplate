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
    public class WorkflowServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IWorkflowService workflowService;

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
        public void GetAllWorkflows_Service_Success()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Workflow>()).Returns(TestHelper.Workflows()).Verifiable();

            // Act
            var response = workflowService.GetAllWorkflows();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<WorkflowDto>>));
            mockRepository.Verify(x => x.All<Workflow>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllWorkflows_Service_Fail()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Workflow>()).Throws(new Exception()).Verifiable();

            // Act
            var response = workflowService.GetAllWorkflows();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<WorkflowDto>>));
            mockRepository.Verify(x => x.All<Workflow>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindWorkflowById_Service_Success()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Workflow>(Guid.Empty)).Returns(new Workflow()).Verifiable();

            // Act
            var response = workflowService.FindWorkflowById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<WorkflowDto>));
            mockRepository.Verify(x => x.FindById<Workflow>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindWorkflowById_Service_Fail()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Workflow>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = workflowService.FindWorkflowById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<WorkflowDto>));
            mockRepository.Verify(x => x.FindById<Workflow>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateWorkflow_Service_Success()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Workflow>())).Returns(true).Verifiable();

            // Act
            var workflow = new WorkflowDto();
            var response = workflowService.CreateWorkflow(workflow);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Workflow>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateWorkflow_Service_Fail()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Workflow>())).Returns(false).Verifiable();

            // Act
            var workflow = new WorkflowDto();
            var response = workflowService.CreateWorkflow(workflow);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Workflow>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateWorkflow_Service_Success()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Workflow>())).Returns(true).Verifiable();

            // Act
            var workflow = new WorkflowDto();
            var response = workflowService.UpdateWorkflow(workflow);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Workflow>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateWorkflow_Service_Fail()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Workflow>())).Returns(false).Verifiable();

            // Act
            var workflow = new WorkflowDto();
            var response = workflowService.UpdateWorkflow(workflow);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Workflow>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteWorkflow_Service_Success()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Workflow>())).Returns(true).Verifiable();

            // Act
            var workflow = new WorkflowDto();
            var response = workflowService.DeleteWorkflow(workflow);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Workflow>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteWorkflow_Service_Fail()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Workflow>())).Returns(false).Verifiable();

            // Act
            var workflow = new WorkflowDto();
            var response = workflowService.DeleteWorkflow(workflow);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Workflow>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteWorkflowById_Service_Success()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Workflow>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = workflowService.DeleteWorkflow(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Workflow>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteWorkflowById_Service_Fail()
        {
            // Arrange
            workflowService = new WorkflowService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Workflow>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = workflowService.DeleteWorkflow(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Workflow>(Guid.Empty), Times.Once);
        }
    }
}