using Domain.Mappings.Business;
using Domain.Models.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Entities.Business.Tests
{
    [TestClass]
    public class ServiceOrderItemTests
    {
        #region Properties Tests

        /*
         * Why are we unit testing properties?
         * What is an auto-property today may end up having a backing field put against it tomorrow, and not necessarily by you.
         * What you're doing when you test an auto-property is, from the perspective of the caller, testing the public "interface" of your class.
         * The caller has no idea if this is an auto property with a framework-generated backing store, or if there is a million lines of complex code in the getter/setter.
         * Therefore the caller is testing the contract implied by the property - that if you put X into the box, you can get X back later on.
         * Therefore it behooves us to include a test since we are testing the behavior of our own code and not the behavior of the compiler.
         */

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void ServiceOrderItem_Property_OrderId()
        {
            // Arrange
            var serviceOrderItem = new ServiceOrderItem();
            var value = Guid.NewGuid();

            // Act
            serviceOrderItem.OrderId = value;

            // Assert
            Assert.IsNotNull(serviceOrderItem.OrderId);
            Assert.IsInstanceOfType(serviceOrderItem.OrderId, typeof(Guid));
            Assert.AreEqual(value, serviceOrderItem.OrderId);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void ServiceOrderItem_Property_ServiceId()
        {
            // Arrange
            var serviceOrderItem = new ServiceOrderItem();
            var value = Guid.NewGuid();

            // Act
            serviceOrderItem.ServiceId = value;

            // Assert
            Assert.IsNotNull(serviceOrderItem.ServiceId);
            Assert.IsInstanceOfType(serviceOrderItem.ServiceId, typeof(Guid));
            Assert.AreEqual(value, serviceOrderItem.ServiceId);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void ServiceOrderItem_Property_Quantity()
        {
            // Arrange
            var serviceOrderItem = new ServiceOrderItem();
            decimal value = 100;

            // Act
            serviceOrderItem.Quantity = value;

            // Assert
            Assert.IsNotNull(serviceOrderItem.Quantity);
            Assert.IsInstanceOfType(serviceOrderItem.Quantity, typeof(decimal));
            Assert.AreEqual(value, serviceOrderItem.Quantity);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void ServiceOrderItem_Property_Count()
        {
            var serviceOrderItem = new ServiceOrderItem();
            Assert.AreEqual(3, serviceOrderItem.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void ServiceOrderItem_Extension_AsDTO_Null()
        {
            // Arrange
            ServiceOrderItem serviceOrderItem = null;

            // Act
            var result = serviceOrderItem.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void ServiceOrderItem_Extension_AsDTO_NotNull()
        {
            // Arrange
            var serviceOrderItem = TestHelper.ServiceOrderItem();

            // Act
            var result = serviceOrderItem.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceOrderItemDto));

            Assert.IsNotNull(result.OrderId);
            Assert.IsInstanceOfType(result.OrderId, typeof(Guid));
            Assert.AreEqual(serviceOrderItem.OrderId, result.OrderId);

            Assert.IsNotNull(result.ServiceId);
            Assert.IsInstanceOfType(result.ServiceId, typeof(Guid));
            Assert.AreEqual(serviceOrderItem.ServiceId, result.ServiceId);

            Assert.IsNotNull(result.Quantity);
            Assert.IsInstanceOfType(result.Quantity, typeof(decimal));
            Assert.AreEqual(serviceOrderItem.Quantity, result.Quantity);
        }

        #endregion Extensions Tests
    }
}