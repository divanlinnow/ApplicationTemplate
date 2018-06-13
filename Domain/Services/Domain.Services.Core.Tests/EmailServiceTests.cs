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
    public class EmailServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IEmailService emailService;

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
        public void GetAllEmails_Service_Success()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Email>()).Returns(TestHelper.Emails()).Verifiable();

            // Act
            var response = emailService.GetAllEmails();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<EmailDto>>));
            mockRepository.Verify(x => x.All<Email>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllEmails_Service_Fail()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Email>()).Throws(new Exception()).Verifiable();

            // Act
            var response = emailService.GetAllEmails();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<EmailDto>>));
            mockRepository.Verify(x => x.All<Email>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindEmailById_Service_Success()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Email>(Guid.Empty)).Returns(new Email()).Verifiable();

            // Act
            var response = emailService.FindEmailById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<EmailDto>));
            mockRepository.Verify(x => x.FindById<Email>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindEmailById_Service_Fail()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Email>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = emailService.FindEmailById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<EmailDto>));
            mockRepository.Verify(x => x.FindById<Email>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateEmail_Service_Success()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Email>())).Returns(true).Verifiable();

            // Act
            var email = new EmailDto();
            var response = emailService.CreateEmail(email);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Email>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateEmail_Service_Fail()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Email>())).Returns(false).Verifiable();

            // Act
            var email = new EmailDto();
            var response = emailService.CreateEmail(email);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Email>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateEmail_Service_Success()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Email>())).Returns(true).Verifiable();

            // Act
            var email = new EmailDto();
            var response = emailService.UpdateEmail(email);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Email>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateEmail_Service_Fail()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Email>())).Returns(false).Verifiable();

            // Act
            var email = new EmailDto();
            var response = emailService.UpdateEmail(email);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Email>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteEmail_Service_Success()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Email>())).Returns(true).Verifiable();

            // Act
            var email = new EmailDto();
            var response = emailService.DeleteEmail(email);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Email>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteEmail_Service_Fail()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Email>())).Returns(false).Verifiable();

            // Act
            var email = new EmailDto();
            var response = emailService.DeleteEmail(email);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Email>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteEmailById_Service_Success()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Email>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = emailService.DeleteEmail(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Email>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteEmailById_Service_Fail()
        {
            // Arrange
            emailService = new EmailService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Email>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = emailService.DeleteEmail(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Email>(Guid.Empty), Times.Once);
        }
    }
}