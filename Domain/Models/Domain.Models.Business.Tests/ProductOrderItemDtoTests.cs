using Domain.Entities.Business;
using Domain.Mappings.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Models.Business.Tests
{
    [TestClass]
    public class ProductOrderItemDtoTests
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
        public void ProductOrderItemDto_Property_OrderId()
        {
            var productOrderItem = new ProductOrderItemDto();
            var value = Guid.NewGuid();

            productOrderItem.OrderId = value;

            Assert.IsNotNull(productOrderItem.OrderId);
            Assert.IsInstanceOfType(productOrderItem.OrderId, typeof(Guid));
            Assert.AreEqual(value, productOrderItem.OrderId);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductOrderItemDto_Property_ProductId()
        {
            var productOrderItem = new ProductOrderItemDto();
            var value = Guid.NewGuid();

            productOrderItem.ProductId = value;

            Assert.IsNotNull(productOrderItem.ProductId);
            Assert.IsInstanceOfType(productOrderItem.ProductId, typeof(Guid));
            Assert.AreEqual(value, productOrderItem.ProductId);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductOrderItemDto_Property_Quantity()
        {
            var productOrderItem = new ProductOrderItemDto();
            decimal value = 100;

            productOrderItem.Quantity = value;

            Assert.IsNotNull(productOrderItem.Quantity);
            Assert.IsInstanceOfType(productOrderItem.Quantity, typeof(decimal));
            Assert.AreEqual(value, productOrderItem.Quantity);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductOrderItemDto_Property_Count()
        {
            var productOrderItem = new ProductOrderItemDto();
            Assert.AreEqual(3, productOrderItem.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void ProductOrderItemDto_Extension_AsEntity_Null()
        {
            ProductOrderItemDto productOrderItem = null;
            var result = productOrderItem.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void ProductOrderItemDto_Extension_AsEntity_NotNull()
        {
            var productOrderItem = TestHelper.ProductOrderItemDto();
            var result = productOrderItem.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ProductOrderItem));

            Assert.IsNotNull(result.OrderId);
            Assert.IsInstanceOfType(result.OrderId, typeof(Guid));
            Assert.AreEqual(productOrderItem.OrderId, result.OrderId);

            Assert.IsNotNull(result.ProductId);
            Assert.IsInstanceOfType(result.ProductId, typeof(Guid));
            Assert.AreEqual(productOrderItem.ProductId, result.ProductId);

            Assert.IsNotNull(result.Quantity);
            Assert.IsInstanceOfType(result.Quantity, typeof(decimal));
            Assert.AreEqual(productOrderItem.Quantity, result.Quantity);
        }

        #endregion Extensions Tests
    }
}