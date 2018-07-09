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
    public class FindEmailByIdTests
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
        public void FindEmailById_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<EmailDto>
            {
                Result = TestHelper.EmailDto()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.EmailService.FindEmailById(It.IsAny<int>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<EmailDto>();

            var action = new FindEmailById<GenericItemViewModel<EmailDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<EmailDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Item);
            Assert.IsInstanceOfType(result.Item, typeof(EmailDto));
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void FindEmailById_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<EmailDto> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.EmailService.FindEmailById(It.IsAny<int>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<EmailDto>();

            var action = new FindEmailById<GenericItemViewModel<EmailDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<EmailDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNull(result.Item);
        }
    }
}
