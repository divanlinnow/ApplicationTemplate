using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using Domain.Services.Business.ServiceProvider;
using Domain.Services.Core;
using Domain.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Domain.Actions.Business.Tests
{
    [TestClass]
    public class DeleteServiceByIdTests
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
        public void DeleteServiceById_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<bool>
            {
                Result = true
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.ServiceService.DeleteService(It.IsAny<int>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericViewModel();

            var action = new DeleteServiceById<GenericViewModel>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(1);

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
        [TestCategory("Actions - Business")]
        public void DeleteServiceById_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<bool> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.ServiceService.DeleteService(It.IsAny<int>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericViewModel();

            var action = new DeleteServiceById<GenericViewModel>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(1);

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
