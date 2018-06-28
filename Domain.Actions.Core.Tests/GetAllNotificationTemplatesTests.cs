using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using Domain.ViewModels;
using Domain.Models.Core;
using Domain.Models.Core.Tests;
using Domain.Services.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Domain.Services.Core.ServiceProvider;

namespace Domain.Actions.Core.Tests
{
    [TestClass]
    public class GetAllNotificationTemplatesTests
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
        public void GetAllNotificationTemplates_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<IEnumerable<NotificationTemplateDto>>
            {
                Result = TestHelper.NotificationTemplateDtos()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.NotificationTemplateService.GetAllNotificationTemplates()).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericListViewModel<NotificationTemplateDto>();

            var action = new GetAllNotificationTemplates<GenericListViewModel<NotificationTemplateDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericListViewModel<NotificationTemplateDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Items);
            Assert.IsInstanceOfType(result.Items, typeof(IEnumerable<NotificationTemplateDto>));
            Assert.IsTrue(result.Items.ToList().Count() == TestHelper.NotificationTemplateDtos().Count());
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void GetAllNotificationTemplates_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<IEnumerable<NotificationTemplateDto>> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.NotificationTemplateService.GetAllNotificationTemplates()).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericListViewModel<NotificationTemplateDto>();

            var action = new GetAllNotificationTemplates<GenericListViewModel<NotificationTemplateDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericListViewModel<NotificationTemplateDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count() == 0);
            Assert.IsInstanceOfType(result.Items, typeof(IEnumerable<NotificationTemplateDto>));
            Assert.IsTrue(result.Items.ToList().Count() == 0);
        }
    }
}
