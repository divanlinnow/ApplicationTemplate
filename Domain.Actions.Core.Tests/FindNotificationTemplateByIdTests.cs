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
    public class FindNotificationTemplateByIdTests
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
        public void FindNotificationTemplateById_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<NotificationTemplateDto>
            {
                Result = TestHelper.NotificationTemplateDto()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.NotificationTemplateService.FindNotificationTemplateById(It.IsAny<Guid>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<NotificationTemplateDto>();

            var action = new FindNotificationTemplateById<GenericItemViewModel<NotificationTemplateDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<NotificationTemplateDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Item);
            Assert.IsInstanceOfType(result.Item, typeof(NotificationTemplateDto));
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void FindNotificationTemplateById_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<NotificationTemplateDto> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.NotificationTemplateService.FindNotificationTemplateById(It.IsAny<Guid>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<NotificationTemplateDto>();

            var action = new FindNotificationTemplateById<GenericItemViewModel<NotificationTemplateDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(Guid.NewGuid());

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<NotificationTemplateDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNull(result.Item);
        }
    }
}
