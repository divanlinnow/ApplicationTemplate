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
    public class LanguageServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private ILanguageService languageService;

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
        public void GetAllLanguages_Service_Success()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Language>()).Returns(TestHelper.Languages()).Verifiable();

            // Act
            var response = languageService.GetAllLanguages();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<LanguageDto>>));
            mockRepository.Verify(x => x.All<Language>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllLanguages_Service_Fail()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Language>()).Throws(new Exception()).Verifiable();

            // Act
            var response = languageService.GetAllLanguages();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<LanguageDto>>));
            mockRepository.Verify(x => x.All<Language>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindLanguageById_Service_Success()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Language>(Guid.Empty)).Returns(new Language()).Verifiable();

            // Act
            var response = languageService.FindLanguageById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<LanguageDto>));
            mockRepository.Verify(x => x.FindById<Language>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindLanguageById_Service_Fail()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Language>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = languageService.FindLanguageById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<LanguageDto>));
            mockRepository.Verify(x => x.FindById<Language>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateLanguage_Service_Success()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Language>())).Returns(true).Verifiable();

            // Act
            var language = new LanguageDto();
            var response = languageService.CreateLanguage(language);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Language>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateLanguage_Service_Fail()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Language>())).Returns(false).Verifiable();

            // Act
            var language = new LanguageDto();
            var response = languageService.CreateLanguage(language);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Language>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateLanguage_Service_Success()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Language>())).Returns(true).Verifiable();

            // Act
            var language = new LanguageDto();
            var response = languageService.UpdateLanguage(language);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Language>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateLanguage_Service_Fail()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Language>())).Returns(false).Verifiable();

            // Act
            var language = new LanguageDto();
            var response = languageService.UpdateLanguage(language);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Language>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteLanguage_Service_Success()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Language>())).Returns(true).Verifiable();

            // Act
            var language = new LanguageDto();
            var response = languageService.DeleteLanguage(language);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Language>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteLanguage_Service_Fail()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Language>())).Returns(false).Verifiable();

            // Act
            var language = new LanguageDto();
            var response = languageService.DeleteLanguage(language);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Language>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteLanguageById_Service_Success()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Language>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = languageService.DeleteLanguage(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Language>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteLanguageById_Service_Fail()
        {
            // Arrange
            languageService = new LanguageService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Language>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = languageService.DeleteLanguage(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Language>(Guid.Empty), Times.Once);
        }
    }
}