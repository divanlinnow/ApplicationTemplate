using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using Domain.Actions.Core.Services;
using Domain.Actions.Core.ViewModels;
using Domain.Models.Core;
using Domain.Models.Core.Tests;
using Domain.Services.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Actions.Core.Tests
{
    [TestClass]
    public class GetAllCountriesTests
    {
        private Mock<ILogger> mockLogger;
        private Mock<IClientServicesProvider> mockClientServicesProvider;

        [TestInitialize]
        public void Init()
        {
            mockLogger = new Mock<ILogger>();
            mockClientServicesProvider = new Mock<IClientServicesProvider>();
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void GetAllCountries_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<IEnumerable<CountryDto>>
            {
                Result = TestHelper.CountryDtos()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.CountryService.GetAllCountries()).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericListViewModel<CountryDto>();

            var action = new GetAllCountries<GenericListViewModel<CountryDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericListViewModel<CountryDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Items);
            Assert.IsInstanceOfType(result.Items, typeof(IEnumerable<CountryDto>));
            Assert.IsTrue(result.Items.ToList().Count() == TestHelper.CountryDtos().Count());
        }

        [TestMethod]
        [TestCategory("Actions - Core")]
        public void GetAllCountries_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<IEnumerable<CountryDto>> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.CountryService.GetAllCountries()).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericListViewModel<CountryDto>();

            var action = new GetAllCountries<GenericListViewModel<CountryDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericListViewModel<CountryDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNotNull(result.Items);
            Assert.IsTrue(result.Items.Count() == 0);
            Assert.IsInstanceOfType(result.Items, typeof(IEnumerable<CountryDto>));
            Assert.IsTrue(result.Items.ToList().Count() == 0);
        }
    }
}
