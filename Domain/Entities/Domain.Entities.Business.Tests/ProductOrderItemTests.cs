using Domain.Mappings.Business;
using Domain.Models.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Entities.Business.Tests
{
    [TestClass]
    public class ProductOrderItemTests
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
        public void ProductOrderItem_Property_OrderId()
        {
            // Arrange
            var productOrderItem = new ProductOrderItem();
            var value = Guid.NewGuid();

            // Act
            productOrderItem.OrderId = value;

            // Assert
            Assert.IsNotNull(productOrderItem.OrderId);
            Assert.IsInstanceOfType(productOrderItem.OrderId, typeof(Guid));
            Assert.AreEqual(value, productOrderItem.OrderId);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void ProductOrderItem_Property_ProductId()
        {
            // Arrange
            var productOrderItem = new ProductOrderItem();
            var value = Guid.NewGuid();

            // Act
            productOrderItem.ProductId = value;

            // Assert
            Assert.IsNotNull(productOrderItem.ProductId);
            Assert.IsInstanceOfType(productOrderItem.ProductId, typeof(Guid));
            Assert.AreEqual(value, productOrderItem.ProductId);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void ProductOrderItem_Property_Quantity()
        {
            // Arrange
            var productOrderItem = new ProductOrderItem();
            decimal value = 100;

            // Act
            productOrderItem.Quantity = value;

            // Assert
            Assert.IsNotNull(productOrderItem.Quantity);
            Assert.IsInstanceOfType(productOrderItem.Quantity, typeof(decimal));
            Assert.AreEqual(value, productOrderItem.Quantity);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void ProductOrderItem_Property_Count()
        {
            var productOrderItem = new ProductOrderItem();
            Assert.AreEqual(3, productOrderItem.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void ProductOrderItem_Extension_AsDTO_Null()
        {
            // Arrange
            ProductOrderItem productOrderItem = null;

            // Act
            var result = productOrderItem.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void ProductOrderItem_Extension_AsDTO_NotNull()
        {
            // Arrange
            var productOrderItem = TestHelper.ProductOrderItem();

            // Act
            var result = productOrderItem.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ProductOrderItemDto));

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