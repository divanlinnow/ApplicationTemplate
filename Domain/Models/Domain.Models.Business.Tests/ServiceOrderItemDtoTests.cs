using Domain.Entities.Business;
using Domain.Mappings.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Models.Business.Tests
{
    [TestClass]
    public class ServiceOrderItemDtoTests
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
        [TestCategory("Models - Properties")]
        public void ServiceOrderItemDto_Property_OrderId()
        {
            var serviceOrderItem = new ServiceOrderItemDto();
            var value = Guid.NewGuid();

            serviceOrderItem.OrderId = value;

            Assert.IsNotNull(serviceOrderItem.OrderId);
            Assert.IsInstanceOfType(serviceOrderItem.OrderId, typeof(Guid));
            Assert.AreEqual(value, serviceOrderItem.OrderId);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceOrderItemDto_Property_ServiceId()
        {
            var serviceOrderItem = new ServiceOrderItemDto();
            var value = Guid.NewGuid();

            serviceOrderItem.ServiceId = value;

            Assert.IsNotNull(serviceOrderItem.ServiceId);
            Assert.IsInstanceOfType(serviceOrderItem.ServiceId, typeof(Guid));
            Assert.AreEqual(value, serviceOrderItem.ServiceId);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceOrderItemDto_Property_Quantity()
        {
            var serviceOrderItem = new ServiceOrderItemDto();
            decimal value = 100;

            serviceOrderItem.Quantity = value;

            Assert.IsNotNull(serviceOrderItem.Quantity);
            Assert.IsInstanceOfType(serviceOrderItem.Quantity, typeof(decimal));
            Assert.AreEqual(value, serviceOrderItem.Quantity);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceOrderItemDto_Property_Count()
        {
            var serviceOrderItem = new ServiceOrderItemDto();
            Assert.AreEqual(3, serviceOrderItem.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void ServiceOrderItemDto_Extension_AsEntity_Null()
        {
            ServiceOrderItemDto serviceOrderItem = null;
            var result = serviceOrderItem.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void ServiceOrderItemDto_Extension_AsEntity_NotNull()
        {
            var serviceOrderItem = TestHelper.ServiceOrderItemDto();
            var result = serviceOrderItem.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceOrderItem));

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