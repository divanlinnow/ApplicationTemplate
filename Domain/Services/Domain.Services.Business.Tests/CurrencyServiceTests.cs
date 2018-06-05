using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Business;
using Domain.Entities.Business.Tests;
using Domain.Models.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core.Tests
{
    [TestClass]
    public class CurrencyServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private ICurrencyService currencyService;

        [TestInitialize]
        public void Init()
        {
            mockRepository = new Mock<IRepository>();
            mockLogger = new Mock<ILogger>();
            mockCache = new Mock<ICache>();
            mockTelemetry = new Mock<ITelemetry>();
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllCurrencies_Service_Success()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Currency>()).Returns(TestHelper.Currencies()).Verifiable();

            // Act
            var response = currencyService.GetAllCurrencies();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<CurrencyDto>>));
            mockRepository.Verify(x => x.All<Currency>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllCurrencies_Service_Fail()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Currency>()).Throws(new Exception()).Verifiable();

            // Act
            var response = currencyService.GetAllCurrencies();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<CurrencyDto>>));
            mockRepository.Verify(x => x.All<Currency>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindCurrencyById_Service_Success()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Currency>(Guid.Empty)).Returns(new Currency()).Verifiable();

            // Act
            var response = currencyService.FindCurrencyById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<CurrencyDto>));
            mockRepository.Verify(x => x.FindById<Currency>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindCurrencyById_Service_Fail()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Currency>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = currencyService.FindCurrencyById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<CurrencyDto>));
            mockRepository.Verify(x => x.FindById<Currency>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateCurrency_Service_Success()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Currency>())).Returns(true).Verifiable();

            // Act
            var currency = new CurrencyDto();
            var response = currencyService.CreateCurrency(currency);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Currency>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateCurrency_Service_Fail()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Currency>())).Returns(false).Verifiable();

            // Act
            var currency = new CurrencyDto();
            var response = currencyService.CreateCurrency(currency);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Currency>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateCurrency_Service_Success()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Currency>())).Returns(true).Verifiable();

            // Act
            var currency = new CurrencyDto();
            var response = currencyService.UpdateCurrency(currency);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Currency>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateCurrency_Service_Fail()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Currency>())).Returns(false).Verifiable();

            // Act
            var currency = new CurrencyDto();
            var response = currencyService.UpdateCurrency(currency);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Currency>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteCurrency_Service_Success()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Currency>())).Returns(true).Verifiable();

            // Act
            var currency = new CurrencyDto();
            var response = currencyService.DeleteCurrency(currency);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Currency>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteCurrency_Service_Fail()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Currency>())).Returns(false).Verifiable();

            // Act
            var currency = new CurrencyDto();
            var response = currencyService.DeleteCurrency(currency);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Currency>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteCurrencyById_Service_Success()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Currency>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = currencyService.DeleteCurrency(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Currency>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteCurrencyById_Service_Fail()
        {
            // Arrange
            currencyService = new CurrencyService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Currency>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = currencyService.DeleteCurrency(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Currency>(Guid.Empty), Times.Once);
        }
    }
}