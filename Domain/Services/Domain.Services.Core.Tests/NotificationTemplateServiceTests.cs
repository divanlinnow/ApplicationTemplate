using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Core;
using Domain.Entities.Core.Tests;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core.Tests
{
    [TestClass]
    public class NotificationTemplateServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private INotificationTemplateService notificationTemplateService;

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
        public void GetAllNotificationTemplates_Service_Success()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<NotificationTemplate>()).Returns(TestHelper.NotificationTemplates()).Verifiable();

            // Act
            var response = notificationTemplateService.GetAllNotificationTemplates();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<NotificationTemplateDto>>));
            mockRepository.Verify(x => x.All<NotificationTemplate>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllNotificationTemplates_Service_Fail()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<NotificationTemplate>()).Throws(new Exception()).Verifiable();

            // Act
            var response = notificationTemplateService.GetAllNotificationTemplates();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<NotificationTemplateDto>>));
            mockRepository.Verify(x => x.All<NotificationTemplate>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindNotificationTemplateById_Service_Success()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<NotificationTemplate>(It.IsAny<int>())).Returns(new NotificationTemplate()).Verifiable();

            // Act
            var response = notificationTemplateService.FindNotificationTemplateById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<NotificationTemplateDto>));
            mockRepository.Verify(x => x.FindById<NotificationTemplate>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindNotificationTemplateById_Service_Fail()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<NotificationTemplate>(It.IsAny<int>())).Throws(new Exception()).Verifiable();

            // Act
            var response = notificationTemplateService.FindNotificationTemplateById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<NotificationTemplateDto>));
            mockRepository.Verify(x => x.FindById<NotificationTemplate>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateNotificationTemplate_Service_Success()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<NotificationTemplate>())).Returns(true).Verifiable();

            // Act
            var notificationTemplate = new NotificationTemplateDto();
            var response = notificationTemplateService.CreateNotificationTemplate(notificationTemplate);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<NotificationTemplate>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateNotificationTemplate_Service_Fail()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<NotificationTemplate>())).Returns(false).Verifiable();

            // Act
            var notificationTemplate = new NotificationTemplateDto();
            var response = notificationTemplateService.CreateNotificationTemplate(notificationTemplate);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<NotificationTemplate>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateNotificationTemplate_Service_Success()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<NotificationTemplate>())).Returns(true).Verifiable();

            // Act
            var notificationTemplate = new NotificationTemplateDto();
            var response = notificationTemplateService.UpdateNotificationTemplate(notificationTemplate);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<NotificationTemplate>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateNotificationTemplate_Service_Fail()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<NotificationTemplate>())).Returns(false).Verifiable();

            // Act
            var notificationTemplate = new NotificationTemplateDto();
            var response = notificationTemplateService.UpdateNotificationTemplate(notificationTemplate);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<NotificationTemplate>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteNotificationTemplate_Service_Success()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<NotificationTemplate>())).Returns(true).Verifiable();

            // Act
            var notificationTemplate = new NotificationTemplateDto();
            var response = notificationTemplateService.DeleteNotificationTemplate(notificationTemplate);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<NotificationTemplate>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteNotificationTemplate_Service_Fail()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<NotificationTemplate>())).Returns(false).Verifiable();

            // Act
            var notificationTemplate = new NotificationTemplateDto();
            var response = notificationTemplateService.DeleteNotificationTemplate(notificationTemplate);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<NotificationTemplate>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteNotificationTemplateById_Service_Success()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<NotificationTemplate>(It.IsAny<int>())).Returns(true).Verifiable();

            // Act
            var response = notificationTemplateService.DeleteNotificationTemplate(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<NotificationTemplate>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteNotificationTemplateById_Service_Fail()
        {
            // Arrange
            notificationTemplateService = new NotificationTemplateService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<NotificationTemplate>(It.IsAny<int>())).Returns(false).Verifiable();

            // Act
            var response = notificationTemplateService.DeleteNotificationTemplate(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<NotificationTemplate>(It.IsAny<int>()), Times.Once);
        }
    }
}