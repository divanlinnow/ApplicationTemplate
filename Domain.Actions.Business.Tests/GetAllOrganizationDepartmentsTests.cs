using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using Domain.Models.Business;
using Domain.Models.Business.Tests;
using Domain.Services.Business.ServiceProvider;
using Domain.Services.Core;
using Domain.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Actions.Business.Tests
{
    [TestClass]
    public class GetAllOrganizationDepartmentsTests
    {
        private Mock<ILogger> mockLogger;
        private Mock<IServiceProviderBusiness> mockClientServicesProvider;

        [TestInitialize]
        public void Init()
        {
            mockLogger = new Mock<ILogger>();
            mockClientServicesProvider = new Mock<IServiceProviderBusiness>();
        }

        [TestMethod]
        [TestCategory("Actions - Business")]
        public void GetAllOrganizationDepartments_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<IEnumerable<OrganizationDepartmentDto>>
            {
                Result = TestHelper.OrganizationDepartmentDtos()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.OrganizationDepartmentService.GetAllOrganizationDepartments()).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericListViewModel<OrganizationDepartmentDto>();

            var action = new GetAllOrganizationDepartments<GenericListViewModel<OrganizationDepartmentDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericListViewModel<OrganizationDepartmentDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Items);
            Assert.IsInstanceOfType(result.Items, typeof(IEnumerable<OrganizationDepartmentDto>));
            Assert.IsTrue(result.Items.ToList().Count() == TestHelper.OrganizationDepartmentDtos().Count());
        }

        [TestMethod]
        [TestCategory("Actions - Business")]
        public void GetAllOrganizationDepartments_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<IEnumerable<OrganizationDepartmentDto>> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.OrganizationDepartmentService.GetAllOrganizationDepartments()).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericListViewModel<OrganizationDepartmentDto>();

            var action = new GetAllOrganizationDepartments<GenericListViewModel<OrganizationDepartmentDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericListViewModel<OrganizationDepartmentDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count() == 0);
            Assert.IsInstanceOfType(result.Items, typeof(IEnumerable<OrganizationDepartmentDto>));
            Assert.IsTrue(result.Items.ToList().Count() == 0);
        }
    }
}
