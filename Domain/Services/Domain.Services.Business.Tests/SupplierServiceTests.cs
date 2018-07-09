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
    public class SupplierServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private ISupplierService supplierService;

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
        public void GetAllSuppliers_Service_Success()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Supplier>()).Returns(TestHelper.Suppliers()).Verifiable();

            // Act
            var response = supplierService.GetAllSuppliers();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<SupplierDto>>));
            mockRepository.Verify(x => x.All<Supplier>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllSuppliers_Service_Fail()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Supplier>()).Throws(new Exception()).Verifiable();

            // Act
            var response = supplierService.GetAllSuppliers();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<SupplierDto>>));
            mockRepository.Verify(x => x.All<Supplier>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindSupplierById_Service_Success()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Supplier>(It.IsAny<int>())).Returns(new Supplier()).Verifiable();

            // Act
            var response = supplierService.FindSupplierById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<SupplierDto>));
            mockRepository.Verify(x => x.FindById<Supplier>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindSupplierById_Service_Fail()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Supplier>(It.IsAny<int>())).Throws(new Exception()).Verifiable();

            // Act
            var response = supplierService.FindSupplierById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<SupplierDto>));
            mockRepository.Verify(x => x.FindById<Supplier>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateSupplier_Service_Success()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Supplier>())).Returns(true).Verifiable();

            // Act
            var supplier = new SupplierDto();
            var response = supplierService.CreateSupplier(supplier);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Supplier>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateSupplier_Service_Fail()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Supplier>())).Returns(false).Verifiable();

            // Act
            var supplier = new SupplierDto();
            var response = supplierService.CreateSupplier(supplier);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Supplier>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateSupplier_Service_Success()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Supplier>())).Returns(true).Verifiable();

            // Act
            var supplier = new SupplierDto();
            var response = supplierService.UpdateSupplier(supplier);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Supplier>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateSupplier_Service_Fail()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Supplier>())).Returns(false).Verifiable();

            // Act
            var supplier = new SupplierDto();
            var response = supplierService.UpdateSupplier(supplier);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Supplier>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteSupplier_Service_Success()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Supplier>())).Returns(true).Verifiable();

            // Act
            var supplier = new SupplierDto();
            var response = supplierService.DeleteSupplier(supplier);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Supplier>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteSupplier_Service_Fail()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Supplier>())).Returns(false).Verifiable();

            // Act
            var supplier = new SupplierDto();
            var response = supplierService.DeleteSupplier(supplier);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Supplier>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteSupplierById_Service_Success()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Supplier>(It.IsAny<int>())).Returns(true).Verifiable();

            // Act
            var response = supplierService.DeleteSupplier(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Supplier>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteSupplierById_Service_Fail()
        {
            // Arrange
            supplierService = new SupplierService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Supplier>(It.IsAny<int>())).Returns(false).Verifiable();

            // Act
            var response = supplierService.DeleteSupplier(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Supplier>(It.IsAny<int>()), Times.Once);
        }
    }
}