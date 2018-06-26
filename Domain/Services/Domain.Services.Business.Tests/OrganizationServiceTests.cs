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
    public class OrganizationServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IOrganizationService organizationService;

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
        public void GetAllOrganizations_Service_Success()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Organization>()).Returns(TestHelper.Organizations()).Verifiable();

            // Act
            var response = organizationService.GetAllOrganizations();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<OrganizationDto>>));
            mockRepository.Verify(x => x.All<Organization>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllOrganizations_Service_Fail()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Organization>()).Throws(new Exception()).Verifiable();

            // Act
            var response = organizationService.GetAllOrganizations();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<OrganizationDto>>));
            mockRepository.Verify(x => x.All<Organization>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindOrganizationById_Service_Success()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Organization>(Guid.Empty)).Returns(new Organization()).Verifiable();

            // Act
            var response = organizationService.FindOrganizationById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<OrganizationDto>));
            mockRepository.Verify(x => x.FindById<Organization>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindOrganizationById_Service_Fail()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Organization>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = organizationService.FindOrganizationById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<OrganizationDto>));
            mockRepository.Verify(x => x.FindById<Organization>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateOrganization_Service_Success()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Organization>())).Returns(true).Verifiable();

            // Act
            var organization = new OrganizationDto();
            var response = organizationService.CreateOrganization(organization);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Organization>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateOrganization_Service_Fail()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Organization>())).Returns(false).Verifiable();

            // Act
            var organization = new OrganizationDto();
            var response = organizationService.CreateOrganization(organization);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Organization>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateOrganization_Service_Success()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Organization>())).Returns(true).Verifiable();

            // Act
            var organization = new OrganizationDto();
            var response = organizationService.UpdateOrganization(organization);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Organization>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateOrganization_Service_Fail()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Organization>())).Returns(false).Verifiable();

            // Act
            var organization = new OrganizationDto();
            var response = organizationService.UpdateOrganization(organization);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Organization>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganization_Service_Success()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Organization>())).Returns(true).Verifiable();

            // Act
            var organization = new OrganizationDto();
            var response = organizationService.DeleteOrganization(organization);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Organization>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganization_Service_Fail()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Organization>())).Returns(false).Verifiable();

            // Act
            var organization = new OrganizationDto();
            var response = organizationService.DeleteOrganization(organization);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Organization>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationById_Service_Success()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Organization>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = organizationService.DeleteOrganization(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Organization>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationById_Service_Fail()
        {
            // Arrange
            organizationService = new OrganizationService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Organization>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = organizationService.DeleteOrganization(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Organization>(Guid.Empty), Times.Once);
        }
    }
}