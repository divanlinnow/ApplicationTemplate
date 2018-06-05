using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Business;
using Domain.Entities.Business.Tests;
using Domain.Models.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core.Tests
{
    [TestClass]
    public class OrganizationDepartmentServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IOrganizationDepartmentService organizationDepartmentService;

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
        public void GetAllOrganizationDepartments_Service_Success()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<OrganizationDepartment>()).Returns(TestHelper.OrganizationDepartments()).Verifiable();

            // Act
            var response = organizationDepartmentService.GetAllOrganizationDepartments();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<OrganizationDepartmentDto>>));
            mockRepository.Verify(x => x.All<OrganizationDepartment>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllOrganizationDepartments_Service_Fail()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<OrganizationDepartment>()).Throws(new Exception()).Verifiable();

            // Act
            var response = organizationDepartmentService.GetAllOrganizationDepartments();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<OrganizationDepartmentDto>>));
            mockRepository.Verify(x => x.All<OrganizationDepartment>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindOrganizationDepartmentById_Service_Success()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<OrganizationDepartment>(Guid.Empty)).Returns(new OrganizationDepartment()).Verifiable();

            // Act
            var response = organizationDepartmentService.FindOrganizationDepartmentById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<OrganizationDepartmentDto>));
            mockRepository.Verify(x => x.FindById<OrganizationDepartment>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindOrganizationDepartmentById_Service_Fail()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<OrganizationDepartment>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = organizationDepartmentService.FindOrganizationDepartmentById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<OrganizationDepartmentDto>));
            mockRepository.Verify(x => x.FindById<OrganizationDepartment>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateOrganizationDepartment_Service_Success()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<OrganizationDepartment>())).Returns(true).Verifiable();

            // Act
            var organizationDepartment = new OrganizationDepartmentDto();
            var response = organizationDepartmentService.CreateOrganizationDepartment(organizationDepartment);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<OrganizationDepartment>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateOrganizationDepartment_Service_Fail()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<OrganizationDepartment>())).Returns(false).Verifiable();

            // Act
            var organizationDepartment = new OrganizationDepartmentDto();
            var response = organizationDepartmentService.CreateOrganizationDepartment(organizationDepartment);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<OrganizationDepartment>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateOrganizationDepartment_Service_Success()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<OrganizationDepartment>())).Returns(true).Verifiable();

            // Act
            var organizationDepartment = new OrganizationDepartmentDto();
            var response = organizationDepartmentService.UpdateOrganizationDepartment(organizationDepartment);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<OrganizationDepartment>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateOrganizationDepartment_Service_Fail()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<OrganizationDepartment>())).Returns(false).Verifiable();

            // Act
            var organizationDepartment = new OrganizationDepartmentDto();
            var response = organizationDepartmentService.UpdateOrganizationDepartment(organizationDepartment);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<OrganizationDepartment>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationDepartment_Service_Success()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<OrganizationDepartment>())).Returns(true).Verifiable();

            // Act
            var organizationDepartment = new OrganizationDepartmentDto();
            var response = organizationDepartmentService.DeleteOrganizationDepartment(organizationDepartment);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<OrganizationDepartment>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationDepartment_Service_Fail()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<OrganizationDepartment>())).Returns(false).Verifiable();

            // Act
            var organizationDepartment = new OrganizationDepartmentDto();
            var response = organizationDepartmentService.DeleteOrganizationDepartment(organizationDepartment);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<OrganizationDepartment>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationDepartmentById_Service_Success()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<OrganizationDepartment>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = organizationDepartmentService.DeleteOrganizationDepartment(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<OrganizationDepartment>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationDepartmentById_Service_Fail()
        {
            // Arrange
            organizationDepartmentService = new OrganizationDepartmentService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<OrganizationDepartment>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = organizationDepartmentService.DeleteOrganizationDepartment(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<OrganizationDepartment>(Guid.Empty), Times.Once);
        }
    }
}