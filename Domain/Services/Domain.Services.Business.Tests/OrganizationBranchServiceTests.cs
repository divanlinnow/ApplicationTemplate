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
    public class OrganizationBranchServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IOrganizationBranchService organizationBranchService;

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
        public void GetAllOrganizationBranches_Service_Success()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<OrganizationBranch>()).Returns(TestHelper.OrganizationBranches()).Verifiable();

            // Act
            var response = organizationBranchService.GetAllOrganizationBranches();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<OrganizationBranchDto>>));
            mockRepository.Verify(x => x.All<OrganizationBranch>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllOrganizationBranches_Service_Fail()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<OrganizationBranch>()).Throws(new Exception()).Verifiable();

            // Act
            var response = organizationBranchService.GetAllOrganizationBranches();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<OrganizationBranchDto>>));
            mockRepository.Verify(x => x.All<OrganizationBranch>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindOrganizationBranchById_Service_Success()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<OrganizationBranch>(It.IsAny<int>())).Returns(new OrganizationBranch()).Verifiable();

            // Act
            var response = organizationBranchService.FindOrganizationBranchById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<OrganizationBranchDto>));
            mockRepository.Verify(x => x.FindById<OrganizationBranch>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindOrganizationBranchById_Service_Fail()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<OrganizationBranch>(It.IsAny<int>())).Throws(new Exception()).Verifiable();

            // Act
            var response = organizationBranchService.FindOrganizationBranchById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<OrganizationBranchDto>));
            mockRepository.Verify(x => x.FindById<OrganizationBranch>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateOrganizationBranch_Service_Success()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<OrganizationBranch>())).Returns(true).Verifiable();

            // Act
            var organizationBranch = new OrganizationBranchDto();
            var response = organizationBranchService.CreateOrganizationBranch(organizationBranch);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<OrganizationBranch>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateOrganizationBranch_Service_Fail()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<OrganizationBranch>())).Returns(false).Verifiable();

            // Act
            var organizationBranch = new OrganizationBranchDto();
            var response = organizationBranchService.CreateOrganizationBranch(organizationBranch);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<OrganizationBranch>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateOrganizationBranch_Service_Success()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<OrganizationBranch>())).Returns(true).Verifiable();

            // Act
            var organizationBranch = new OrganizationBranchDto();
            var response = organizationBranchService.UpdateOrganizationBranch(organizationBranch);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<OrganizationBranch>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateOrganizationBranch_Service_Fail()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<OrganizationBranch>())).Returns(false).Verifiable();

            // Act
            var organizationBranch = new OrganizationBranchDto();
            var response = organizationBranchService.UpdateOrganizationBranch(organizationBranch);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<OrganizationBranch>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationBranch_Service_Success()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<OrganizationBranch>())).Returns(true).Verifiable();

            // Act
            var organizationBranch = new OrganizationBranchDto();
            var response = organizationBranchService.DeleteOrganizationBranch(organizationBranch);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<OrganizationBranch>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationBranch_Service_Fail()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<OrganizationBranch>())).Returns(false).Verifiable();

            // Act
            var organizationBranch = new OrganizationBranchDto();
            var response = organizationBranchService.DeleteOrganizationBranch(organizationBranch);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<OrganizationBranch>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationBranchById_Service_Success()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<OrganizationBranch>(It.IsAny<int>())).Returns(true).Verifiable();

            // Act
            var response = organizationBranchService.DeleteOrganizationBranch(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<OrganizationBranch>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteOrganizationBranchById_Service_Fail()
        {
            // Arrange
            organizationBranchService = new OrganizationBranchService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<OrganizationBranch>(It.IsAny<int>())).Returns(false).Verifiable();

            // Act
            var response = organizationBranchService.DeleteOrganizationBranch(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<OrganizationBranch>(It.IsAny<int>()), Times.Once);
        }
    }
}