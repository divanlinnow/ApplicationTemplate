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
    public class PermissionServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IPermissionService permissionService;

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
        public void GetAllPermissions_Service_Success()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Permission>()).Returns(TestHelper.Permissions()).Verifiable();

            // Act
            var response = permissionService.GetAllPermissions();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<PermissionDto>>));
            mockRepository.Verify(x => x.All<Permission>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllPermissions_Service_Fail()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Permission>()).Throws(new Exception()).Verifiable();

            // Act
            var response = permissionService.GetAllPermissions();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<PermissionDto>>));
            mockRepository.Verify(x => x.All<Permission>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindPermissionById_Service_Success()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Permission>(Guid.Empty)).Returns(new Permission()).Verifiable();

            // Act
            var response = permissionService.FindPermissionById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<PermissionDto>));
            mockRepository.Verify(x => x.FindById<Permission>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindPermissionById_Service_Fail()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Permission>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = permissionService.FindPermissionById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<PermissionDto>));
            mockRepository.Verify(x => x.FindById<Permission>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreatePermission_Service_Success()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Permission>())).Returns(true).Verifiable();

            // Act
            var permission = new PermissionDto();
            var response = permissionService.CreatePermission(permission);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Permission>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreatePermission_Service_Fail()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Permission>())).Returns(false).Verifiable();

            // Act
            var permission = new PermissionDto();
            var response = permissionService.CreatePermission(permission);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Permission>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdatePermission_Service_Success()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Permission>())).Returns(true).Verifiable();

            // Act
            var permission = new PermissionDto();
            var response = permissionService.UpdatePermission(permission);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Permission>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdatePermission_Service_Fail()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Permission>())).Returns(false).Verifiable();

            // Act
            var permission = new PermissionDto();
            var response = permissionService.UpdatePermission(permission);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Permission>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeletePermission_Service_Success()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Permission>())).Returns(true).Verifiable();

            // Act
            var permission = new PermissionDto();
            var response = permissionService.DeletePermission(permission);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Permission>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeletePermission_Service_Fail()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Permission>())).Returns(false).Verifiable();

            // Act
            var permission = new PermissionDto();
            var response = permissionService.DeletePermission(permission);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Permission>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeletePermissionById_Service_Success()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Permission>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = permissionService.DeletePermission(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Permission>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeletePermissionById_Service_Fail()
        {
            // Arrange
            permissionService = new PermissionService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Permission>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = permissionService.DeletePermission(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Permission>(Guid.Empty), Times.Once);
        }
    }
}