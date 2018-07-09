using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using Domain.Models.Core;
using Domain.Models.Core.Tests;
using Domain.Services.Core;
using Domain.Services.Core.ServiceProvider;
using Domain.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Domain.Actions.Core.Tests
{
    [TestClass]
    public class FindPermissionByIdTests
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
        public void FindPermissionById_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<PermissionDto>
            {
                Result = TestHelper.PermissionDto()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.PermissionService.FindPermissionById(It.IsAny<int>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<PermissionDto>();

            var action = new FindPermissionById<GenericItemViewModel<PermissionDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<PermissionDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Item);
            Assert.IsInstanceOfType(result.Item, typeof(PermissionDto));
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void FindPermissionById_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<PermissionDto> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.PermissionService.FindPermissionById(It.IsAny<int>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<PermissionDto>();

            var action = new FindPermissionById<GenericItemViewModel<PermissionDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<PermissionDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNull(result.Item);
        }
    }
}
