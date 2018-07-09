using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
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
    public class DeleteNotificationTemplateTests
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
        public void DeleteNotificationTemplate_Action_Success()
        {
            // Arrange
            var notificationTemplateDto = TestHelper.NotificationTemplateDto();

            var fakeResponse = new GenericServiceResponse<bool>
            {
                Result = true
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.NotificationTemplateService.DeleteNotificationTemplate(notificationTemplateDto)).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericViewModel();

            var action = new DeleteNotificationTemplate<GenericViewModel>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(notificationTemplateDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericViewModel));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Success);
            Assert.IsInstanceOfType(result.Success, typeof(bool));
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void DeleteNotificationTemplate_Action_Fails()
        {
            // Arrange
            var notificationTemplateDto = TestHelper.NotificationTemplateDto();

            GenericServiceResponse<bool> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.NotificationTemplateService.DeleteNotificationTemplate(notificationTemplateDto)).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericViewModel();

            var action = new DeleteNotificationTemplate<GenericViewModel>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(notificationTemplateDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericViewModel));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNotNull(result.Success);
            Assert.IsInstanceOfType(result.Success, typeof(bool));
            Assert.IsFalse(result.Success);
        }
    }
}
