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
    public class RoleServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IRoleService roleService;

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
        public void GetAllRoles_Service_Success()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Role>()).Returns(TestHelper.Roles()).Verifiable();

            // Act
            var response = roleService.GetAllRoles();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<RoleDto>>));
            mockRepository.Verify(x => x.All<Role>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllRoles_Service_Fail()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Role>()).Throws(new Exception()).Verifiable();

            // Act
            var response = roleService.GetAllRoles();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<RoleDto>>));
            mockRepository.Verify(x => x.All<Role>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindRoleById_Service_Success()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Role>(It.IsAny<int>())).Returns(new Role()).Verifiable();

            // Act
            var response = roleService.FindRoleById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<RoleDto>));
            mockRepository.Verify(x => x.FindById<Role>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindRoleById_Service_Fail()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Role>(It.IsAny<int>())).Throws(new Exception()).Verifiable();

            // Act
            var response = roleService.FindRoleById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<RoleDto>));
            mockRepository.Verify(x => x.FindById<Role>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateRole_Service_Success()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Role>())).Returns(true).Verifiable();

            // Act
            var role = new RoleDto();
            var response = roleService.CreateRole(role);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Role>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateRole_Service_Fail()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Role>())).Returns(false).Verifiable();

            // Act
            var role = new RoleDto();
            var response = roleService.CreateRole(role);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Role>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateRole_Service_Success()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Role>())).Returns(true).Verifiable();

            // Act
            var role = new RoleDto();
            var response = roleService.UpdateRole(role);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Role>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateRole_Service_Fail()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Role>())).Returns(false).Verifiable();

            // Act
            var role = new RoleDto();
            var response = roleService.UpdateRole(role);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Role>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteRole_Service_Success()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Role>())).Returns(true).Verifiable();

            // Act
            var role = new RoleDto();
            var response = roleService.DeleteRole(role);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Role>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteRole_Service_Fail()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Role>())).Returns(false).Verifiable();

            // Act
            var role = new RoleDto();
            var response = roleService.DeleteRole(role);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Role>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteRoleById_Service_Success()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Role>(It.IsAny<int>())).Returns(true).Verifiable();

            // Act
            var response = roleService.DeleteRole(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Role>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteRoleById_Service_Fail()
        {
            // Arrange
            roleService = new RoleService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Role>(It.IsAny<int>())).Returns(false).Verifiable();

            // Act
            var response = roleService.DeleteRole(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Role>(It.IsAny<int>()), Times.Once);
        }
    }
}