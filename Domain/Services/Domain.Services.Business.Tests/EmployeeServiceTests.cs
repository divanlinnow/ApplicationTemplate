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
    public class EmployeeServiceTests
    {
        private Mock<IRepository> mockRepository;
        private Mock<ILogger> mockLogger;
        private Mock<ICache> mockCache;
        private Mock<ITelemetry> mockTelemetry;
        private IEmployeeService employeeService;

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
        public void GetAllEmployees_Service_Success()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Employee>()).Returns(TestHelper.Employees()).Verifiable();

            // Act
            var response = employeeService.GetAllEmployees();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<EmployeeDto>>));
            mockRepository.Verify(x => x.All<Employee>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void GetAllEmployees_Service_Fail()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.All<Employee>()).Throws(new Exception()).Verifiable();

            // Act
            var response = employeeService.GetAllEmployees();

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<IEnumerable<EmployeeDto>>));
            mockRepository.Verify(x => x.All<Employee>(), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindEmployeeById_Service_Success()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Employee>(Guid.Empty)).Returns(new Employee()).Verifiable();

            // Act
            var response = employeeService.FindEmployeeById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Result);
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<EmployeeDto>));
            mockRepository.Verify(x => x.FindById<Employee>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void FindEmployeeById_Service_Fail()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.FindById<Employee>(Guid.Empty)).Throws(new Exception()).Verifiable();

            // Act
            var response = employeeService.FindEmployeeById(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsNull(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<EmployeeDto>));
            mockRepository.Verify(x => x.FindById<Employee>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateEmployee_Service_Success()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Employee>())).Returns(true).Verifiable();

            // Act
            var employee = new EmployeeDto();
            var response = employeeService.CreateEmployee(employee);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Employee>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void CreateEmployee_Service_Fail()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Insert(It.IsAny<Employee>())).Returns(false).Verifiable();

            // Act
            var employee = new EmployeeDto();
            var response = employeeService.CreateEmployee(employee);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Insert(It.IsAny<Employee>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateEmployee_Service_Success()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Employee>())).Returns(true).Verifiable();

            // Act
            var employee = new EmployeeDto();
            var response = employeeService.UpdateEmployee(employee);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Employee>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void UpdateEmployee_Service_Fail()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Update(It.IsAny<Employee>())).Returns(false).Verifiable();

            // Act
            var employee = new EmployeeDto();
            var response = employeeService.UpdateEmployee(employee);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Update(It.IsAny<Employee>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteEmployee_Service_Success()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Employee>())).Returns(true).Verifiable();

            // Act
            var employee = new EmployeeDto();
            var response = employeeService.DeleteEmployee(employee);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Employee>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteEmployee_Service_Fail()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete(It.IsAny<Employee>())).Returns(false).Verifiable();

            // Act
            var employee = new EmployeeDto();
            var response = employeeService.DeleteEmployee(employee);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete(It.IsAny<Employee>()), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteEmployeeById_Service_Success()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Employee>(Guid.Empty)).Returns(true).Verifiable();

            // Act
            var response = employeeService.DeleteEmployee(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Result);
            Assert.IsFalse(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Employee>(Guid.Empty), Times.Once);
        }

        [TestMethod]
        [TestCategory("Services - Core")]
        public void DeleteEmployeeById_Service_Fail()
        {
            // Arrange
            employeeService = new EmployeeService(mockRepository.Object, mockLogger.Object, mockCache.Object, mockTelemetry.Object);
            mockRepository.Setup(x => x.Delete<Employee>(Guid.Empty)).Returns(false).Verifiable();

            // Act
            var response = employeeService.DeleteEmployee(Guid.Empty);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.Result);
            Assert.IsTrue(response.Notifications.HasErrors());
            Assert.IsInstanceOfType(response, typeof(GenericServiceResponse<bool>));
            mockRepository.Verify(x => x.Delete<Employee>(Guid.Empty), Times.Once);
        }
    }
}