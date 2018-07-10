﻿using ApplicationFramework.Logging;
using ApplicationFramework.Notifications;
using Domain.Models.Business;
using Domain.Models.Business.Tests;
using Domain.Services.Business.ServiceProvider;
using Domain.Services.Core;
using Domain.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Domain.Actions.Business.Tests
{
    [TestClass]
    public class FindOrderByIdTests
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
        public void FindOrderById_Action_Success()
        {
            // Arrange
            var fakeResponse = new GenericServiceResponse<OrderDto>
            {
                Result = TestHelper.OrderDto()
            };

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.OrderService.FindOrderById(It.IsAny<int>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<OrderDto>();

            var action = new FindOrderById<GenericItemViewModel<OrderDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<OrderDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 0);
            Assert.IsFalse(result.HasErrors);
            Assert.IsNotNull(result.Item);
            Assert.IsInstanceOfType(result.Item, typeof(OrderDto));
        }

        [TestMethod]
        [TestCategory("Actions - Business")]
        public void FindOrderById_Action_Fails()
        {
            // Arrange
            GenericServiceResponse<OrderDto> fakeResponse = null;

            mockClientServicesProvider.Setup(x => x.Logger).Returns(mockLogger.Object).Verifiable();
            mockClientServicesProvider.Setup(x => x.OrderService.FindOrderById(It.IsAny<int>())).Returns(fakeResponse).Verifiable();

            var viewModel = new GenericItemViewModel<OrderDto>();

            var action = new FindOrderById<GenericItemViewModel<OrderDto>>(mockClientServicesProvider.Object)
            {
                OnComplete = model => viewModel = model
            };

            // Act
            var result = action.Invoke(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(GenericItemViewModel<OrderDto>));
            Assert.IsNotNull(result.Notifications);
            Assert.IsInstanceOfType(result.Notifications, typeof(NotificationCollection));
            Assert.IsTrue(result.Notifications.Count() == 1);
            Assert.IsTrue(result.HasErrors);
            Assert.IsNull(result.Item);
        }
    }
}
