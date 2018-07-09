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
    public class ServiceServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IServiceService serviceService;

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
        public void GetAllServices_Service_Success()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Service>()).Returns(TestHelper.Services()).Verifiable();

            // Act
            var response = serviceService.GetAllServices();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<ServiceDto>>));
            mockRepository.Verify(x => x.All<Service>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllServices_Service_Fail()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Service>()).Throws(new Exception()).Verifiable();

            // Act
            var response = serviceService.GetAllServices();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<ServiceDto>>));
            mockRepository.Verify(x => x.All<Service>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindServiceById_Service_Success()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Service>(It.IsAny<int>())).Returns(new Service()).Verifiable();

            // Act
            var response = serviceService.FindServiceById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<ServiceDto>));
            mockRepository.Verify(x => x.FindById<Service>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindServiceById_Service_Fail()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Service>(It.IsAny<int>())).Throws(new Exception()).Verifiable();

            // Act
            var response = serviceService.FindServiceById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<ServiceDto>));
            mockRepository.Verify(x => x.FindById<Service>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateService_Service_Success()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Service>())).Returns(true).Verifiable();

            // Act
            var service = new ServiceDto();
            var response = serviceService.CreateService(service);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Service>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateService_Service_Fail()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Service>())).Returns(false).Verifiable();

            // Act
            var service = new ServiceDto();
            var response = serviceService.CreateService(service);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Service>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateService_Service_Success()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Service>())).Returns(true).Verifiable();

            // Act
            var service = new ServiceDto();
            var response = serviceService.UpdateService(service);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Service>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateService_Service_Fail()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Service>())).Returns(false).Verifiable();

            // Act
            var service = new ServiceDto();
            var response = serviceService.UpdateService(service);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Service>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteService_Service_Success()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Service>())).Returns(true).Verifiable();

            // Act
            var service = new ServiceDto();
            var response = serviceService.DeleteService(service);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Service>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteService_Service_Fail()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Service>())).Returns(false).Verifiable();

            // Act
            var service = new ServiceDto();
            var response = serviceService.DeleteService(service);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Service>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteServiceById_Service_Success()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Service>(It.IsAny<int>())).Returns(true).Verifiable();

            // Act
            var response = serviceService.DeleteService(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Service>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteServiceById_Service_Fail()
        {
            // Arrange
            serviceService = new ServiceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Service>(It.IsAny<int>())).Returns(false).Verifiable();

            // Act
            var response = serviceService.DeleteService(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Service>(It.IsAny<int>()), Times.Once);
        }
    }
}