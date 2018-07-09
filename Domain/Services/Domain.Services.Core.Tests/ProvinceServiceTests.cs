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
    public class ProvinceServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IProvinceService provinceService;

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
        public void GetAllProvinces_Service_Success()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Province>()).Returns(TestHelper.Provinces()).Verifiable();

            // Act
            var response = provinceService.GetAllProvinces();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<ProvinceDto>>));
            mockRepository.Verify(x => x.All<Province>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllProvinces_Service_Fail()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Province>()).Throws(new Exception()).Verifiable();

            // Act
            var response = provinceService.GetAllProvinces();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<ProvinceDto>>));
            mockRepository.Verify(x => x.All<Province>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindProvinceById_Service_Success()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Province>(It.IsAny<int>())).Returns(new Province()).Verifiable();

            // Act
            var response = provinceService.FindProvinceById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<ProvinceDto>));
            mockRepository.Verify(x => x.FindById<Province>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindProvinceById_Service_Fail()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Province>(It.IsAny<int>())).Throws(new Exception()).Verifiable();

            // Act
            var response = provinceService.FindProvinceById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<ProvinceDto>));
            mockRepository.Verify(x => x.FindById<Province>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateProvince_Service_Success()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Province>())).Returns(true).Verifiable();

            // Act
            var province = new ProvinceDto();
            var response = provinceService.CreateProvince(province);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Province>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateProvince_Service_Fail()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Province>())).Returns(false).Verifiable();

            // Act
            var province = new ProvinceDto();
            var response = provinceService.CreateProvince(province);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Province>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateProvince_Service_Success()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Province>())).Returns(true).Verifiable();

            // Act
            var province = new ProvinceDto();
            var response = provinceService.UpdateProvince(province);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Province>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateProvince_Service_Fail()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Province>())).Returns(false).Verifiable();

            // Act
            var province = new ProvinceDto();
            var response = provinceService.UpdateProvince(province);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Province>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteProvince_Service_Success()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Province>())).Returns(true).Verifiable();

            // Act
            var province = new ProvinceDto();
            var response = provinceService.DeleteProvince(province);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Province>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteProvince_Service_Fail()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Province>())).Returns(false).Verifiable();

            // Act
            var province = new ProvinceDto();
            var response = provinceService.DeleteProvince(province);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Province>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteProvinceById_Service_Success()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Province>(It.IsAny<int>())).Returns(true).Verifiable();

            // Act
            var response = provinceService.DeleteProvince(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Province>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteProvinceById_Service_Fail()
        {
            // Arrange
            provinceService = new ProvinceService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Province>(It.IsAny<int>())).Returns(false).Verifiable();

            // Act
            var response = provinceService.DeleteProvince(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Province>(It.IsAny<int>()), Times.Once);
        }
    }
}