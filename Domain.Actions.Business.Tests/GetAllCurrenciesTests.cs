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
    public class GetAllCurrenciesTests
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
        public void GetAllCurrencies_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<IEnumerable<CurrencyDto>>
            {
                Result = TestHelper.CurrencyDtos()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.CurrencyService.GetAllCurrencies()).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericListViewModel<CurrencyDto>();

            var action = new GetAllCurrencies<GenericListViewModel<CurrencyDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericListViewModel<CurrencyDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Items);
            Assert.IsInstanceOfType(result.Items, typeof(IEnumerable<CurrencyDto>));
            Assert.IsTrue(result.Items.ToList().Count() == TestHelper.CurrencyDtos().Count());
        }

        [TestMethod]
        [TestCategory("Actions - Business")]
        public void GetAllCurrencies_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<IEnumerable<CurrencyDto>> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.CurrencyService.GetAllCurrencies()).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericListViewModel<CurrencyDto>();

            var action = new GetAllCurrencies<GenericListViewModel<CurrencyDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericListViewModel<CurrencyDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count() == 0);
            Assert.IsInstanceOfType(result.Items, typeof(IEnumerable<CurrencyDto>));
            Assert.IsTrue(result.Items.ToList().Count() == 0);
        }
    }
}
