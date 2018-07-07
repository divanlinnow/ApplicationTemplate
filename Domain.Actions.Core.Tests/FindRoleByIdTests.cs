using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using Domain.ViewModels;
using Domain.Models.Core;
using Domain.Models.Core.Tests;
using Domain.Services.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using Domain.Services.Core.ServiceProvider;
using System;

namespace Domain.Actions.Core.Tests
{
    [TestClass]
    public class FindRoleByIdTests
    {
        private Mock<ILogger> mockLogger;
        private Mock<IServiceProviderCore> mockClientServicesProvider;

        [TestInitialize]
        public void Init()
        {
            mockLogger = new Mock<ILogger>();
            mockClientServicesProvider = new Mock<IServiceProviderCore>();
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void FindRoleById_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<RoleDto>
            {
                Result = TestHelper.RoleDto()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.RoleService.FindRoleById(It.IsAny<Guid>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<RoleDto>();

            var action = new FindRoleById<GenericItemViewModel<RoleDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<RoleDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Item);
            Assert.IsInstanceOfType(result.Item, typeof(RoleDto));
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void FindRoleById_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<RoleDto> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.RoleService.FindRoleById(It.IsAny<Guid>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<RoleDto>();

            var action = new FindRoleById<GenericItemViewModel<RoleDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<RoleDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNull(result.Item);
        }
    }
}
