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
    public class FindPhoneNumberByIdTests
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
        public void FindPhoneNumberById_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<PhoneNumberDto>
            {
                Result = TestHelper.PhoneNumberDto()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.PhoneNumberService.FindPhoneNumberById(It.IsAny<Guid>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<PhoneNumberDto>();

            var action = new FindPhoneNumberById<GenericItemViewModel<PhoneNumberDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<PhoneNumberDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Item);
            Assert.IsInstanceOfType(result.Item, typeof(PhoneNumberDto));
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void FindPhoneNumberById_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<PhoneNumberDto> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.PhoneNumberService.FindPhoneNumberById(It.IsAny<Guid>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<PhoneNumberDto>();

            var action = new FindPhoneNumberById<GenericItemViewModel<PhoneNumberDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<PhoneNumberDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNull(result.Item);
        }
    }
}
