using ApplicationFramework.Caching;
using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using ApplicationFramework.Telemetry;
using Domain.Entities.Core;
using Domain.Entities.Core.Tests;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ORM.EF.Repositories;
using System;
using System.Collections.Generic;

namespace Domain.Services.Core.Tests
{
    [TestClass]
    public class CountryServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private ICountryService countryService;

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
        public void GetAllCountries_Service_Success()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Country>()).Returns(TestHelper.Countries()).Verifiable();

            // Act
            var response = countryService.GetAllCountries();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<CountryDto>>));
            mockRepository.Verify(x => x.All<Country>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllCountries_Service_Fail()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Country>()).Throws(new Exception()).Verifiable();

            // Act
            var response = countryService.GetAllCountries();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<CountryDto>>));
            mockRepository.Verify(x => x.All<Country>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindCountryById_Service_Success()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Country>(It.IsAny<int>())).Returns(new Country()).Verifiable();

            // Act
            var response = countryService.FindCountryById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<CountryDto>));
            mockRepository.Verify(x => x.FindById<Country>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindCountryById_Service_Fail()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Country>(It.IsAny<int>())).Throws(new Exception()).Verifiable();

            // Act
            var response = countryService.FindCountryById(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<CountryDto>));
            mockRepository.Verify(x => x.FindById<Country>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateCountry_Service_Success()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Country>())).Returns(true).Verifiable();

            // Act
            var country = new CountryDto();
            var response = countryService.CreateCountry(country);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Country>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateCountry_Service_Fail()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Country>())).Returns(false).Verifiable();

            // Act
            var country = new CountryDto();
            var response = countryService.CreateCountry(country);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Country>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateCountry_Service_Success()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Country>())).Returns(true).Verifiable();

            // Act
            var country = new CountryDto();
            var response = countryService.UpdateCountry(country);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Country>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateCountry_Service_Fail()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Country>())).Returns(false).Verifiable();

            // Act
            var country = new CountryDto();
            var response = countryService.UpdateCountry(country);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Country>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteCountry_Service_Success()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Country>())).Returns(true).Verifiable();

            // Act
            var country = new CountryDto();
            var response = countryService.DeleteCountry(country);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Country>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteCountry_Service_Fail()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Country>())).Returns(false).Verifiable();

            // Act
            var country = new CountryDto();
            var response = countryService.DeleteCountry(country);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Country>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteCountryById_Service_Success()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Country>(It.IsAny<int>())).Returns(true).Verifiable();

            // Act
            var response = countryService.DeleteCountry(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Country>(It.IsAny<int>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteCountryById_Service_Fail()
        {
            // Arrange
            countryService = new CountryService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Country>(It.IsAny<int>())).Returns(false).Verifiable();

            // Act
            var response = countryService.DeleteCountry(It.IsAny<int>());

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Country>(It.IsAny<int>()), Times.Once);
        }
    }
}