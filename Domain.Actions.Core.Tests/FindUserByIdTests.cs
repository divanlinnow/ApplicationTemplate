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
    public class FindUserByIdTests
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
        public void FindUserById_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<UserDto>
            {
                Result = TestHelper.UserDto()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.UserService.FindUserById(It.IsAny<Guid>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<UserDto>();

            var action = new FindUserById<GenericItemViewModel<UserDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<UserDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Item);
            Assert.IsInstanceOfType(result.Item, typeof(UserDto));
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void FindUserById_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<UserDto> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.UserService.FindUserById(It.IsAny<Guid>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<UserDto>();

            var action = new FindUserById<GenericItemViewModel<UserDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<UserDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNull(result.Item);
        }
    }
}
