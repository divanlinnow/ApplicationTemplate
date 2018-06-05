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
    public class PhoneNumberServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IPhoneNumberService phoneNumberService;

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
        public void GetAllPhoneNumbers_Service_Success()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<PhoneNumber>()).Returns(TestHelper.PhoneNumbers()).Verifiable();

            // Act
            var response = phoneNumberService.GetAllPhoneNumbers();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<PhoneNumberDto>>));
            mockRepository.Verify(x => x.All<PhoneNumber>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllPhoneNumbers_Service_Fail()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<PhoneNumber>()).Throws(new Exception()).Verifiable();

            // Act
            var response = phoneNumberService.GetAllPhoneNumbers();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<PhoneNumberDto>>));
            mockRepository.Verify(x => x.All<PhoneNumber>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindPhoneNumberById_Service_Success()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<PhoneNumber>(Guid.Empty)).Returns(new PhoneNumber()).Verifiable();

            // Act
            var response = phoneNumberService.FindPhoneNumberById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<PhoneNumberDto>));
            mockRepository.Verify(x => x.FindById<PhoneNumber>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindPhoneNumberById_Service_Fail()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<PhoneNumber>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = phoneNumberService.FindPhoneNumberById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<PhoneNumberDto>));
            mockRepository.Verify(x => x.FindById<PhoneNumber>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreatePhoneNumber_Service_Success()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<PhoneNumber>())).Returns(true).Verifiable();

            // Act
            var phoneNumber = new PhoneNumberDto();
            var response = phoneNumberService.CreatePhoneNumber(phoneNumber);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<PhoneNumber>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreatePhoneNumber_Service_Fail()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<PhoneNumber>())).Returns(false).Verifiable();

            // Act
            var phoneNumber = new PhoneNumberDto();
            var response = phoneNumberService.CreatePhoneNumber(phoneNumber);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<PhoneNumber>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdatePhoneNumber_Service_Success()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<PhoneNumber>())).Returns(true).Verifiable();

            // Act
            var phoneNumber = new PhoneNumberDto();
            var response = phoneNumberService.UpdatePhoneNumber(phoneNumber);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<PhoneNumber>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdatePhoneNumber_Service_Fail()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<PhoneNumber>())).Returns(false).Verifiable();

            // Act
            var phoneNumber = new PhoneNumberDto();
            var response = phoneNumberService.UpdatePhoneNumber(phoneNumber);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<PhoneNumber>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeletePhoneNumber_Service_Success()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<PhoneNumber>())).Returns(true).Verifiable();

            // Act
            var phoneNumber = new PhoneNumberDto();
            var response = phoneNumberService.DeletePhoneNumber(phoneNumber);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<PhoneNumber>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeletePhoneNumber_Service_Fail()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<PhoneNumber>())).Returns(false).Verifiable();

            // Act
            var phoneNumber = new PhoneNumberDto();
            var response = phoneNumberService.DeletePhoneNumber(phoneNumber);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<PhoneNumber>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeletePhoneNumberById_Service_Success()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<PhoneNumber>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = phoneNumberService.DeletePhoneNumber(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<PhoneNumber>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeletePhoneNumberById_Service_Fail()
        {
            // Arrange
            phoneNumberService = new PhoneNumberService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<PhoneNumber>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = phoneNumberService.DeletePhoneNumber(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<PhoneNumber>(Guid.Empty), Times.Once);
        }
    }
}