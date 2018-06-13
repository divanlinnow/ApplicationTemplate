using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.Business.Tests
{
    [TestClass]
    public class OrderTests
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
        public void Order_Property_Customer()
        {
            // Arrange
            var order = new Order();
            var value = TestHelper.Customer();

            // Act
            order.Customer = value;

            // Assert
            Assert.IsNotNull(order.Customer);
            Assert.IsInstanceOfType(order.Customer, typeof(Customer));
            Assert.AreEqual(value, order.Customer);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_PlacementDate()
        {
            // Arrange
            var order = new Order();
            var value = DateTime.Now;

            // Act
            order.PlacementDate = value;

            // Assert
            Assert.IsNotNull(order.PlacementDate);
            Assert.IsInstanceOfType(order.PlacementDate, typeof(DateTime));
            Assert.AreEqual(value, order.PlacementDate);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_Products()
        {
            // Arrange
            var order = new Order();
            var value = TestHelper.ProductOrderItems();

            // Act
            order.Products = value;

            // Assert
            Assert.IsNotNull(order.Products);
            Assert.IsInstanceOfType(order.Products, typeof(List<ProductOrderItem>));
            Assert.AreEqual(value, order.Products);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_Services()
        {
            // Arrange
            var order = new Order();
            var value = TestHelper.ServiceOrderItems();

            // Act
            order.Services = value;

            // Assert
            Assert.IsNotNull(order.Services);
            Assert.IsInstanceOfType(order.Services, typeof(List<ServiceOrderItem>));
            Assert.AreEqual(value, order.Services);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_TrackingNumber()
        {
            // Arrange
            var order = new Order();
            var value = "Test Tracking Number ABC 123";

            // Act
            order.TrackingNumber = value;

            // Assert
            Assert.IsNotNull(order.TrackingNumber);
            Assert.IsInstanceOfType(order.TrackingNumber, typeof(string));
            Assert.AreEqual(value, order.TrackingNumber);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_DeliveryAddress()
        {
            // Arrange
            var order = new Order();
            var value = Core.Tests.TestHelper.Address();

            // Act
            order.DeliveryAddress = value;

            // Assert
            Assert.IsNotNull(order.DeliveryAddress);
            Assert.IsInstanceOfType(order.DeliveryAddress, typeof(Address));
            Assert.AreEqual(value, order.DeliveryAddress);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_CollectionAddress()
        {
            // Arrange
            var order = new Order();
            var value = Core.Tests.TestHelper.Address();

            // Act
            order.CollectionAddress = value;

            // Assert
            Assert.IsNotNull(order.CollectionAddress);
            Assert.IsInstanceOfType(order.CollectionAddress, typeof(Address));
            Assert.AreEqual(value, order.CollectionAddress);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_Created()
        {
            // Arrange
            var order = new Order();
            var value = DateTime.Now;

            // Act
            order.Created = value;

            // Assert
            Assert.IsNotNull(order.Created);
            Assert.IsInstanceOfType(order.Created, typeof(DateTime));
            Assert.AreEqual(value, order.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_CreatedBy()
        {
            // Arrange
            var order = new Order();
            var value = Core.Tests.TestHelper.User();

            // Act
            order.CreatedBy = value;

            // Assert
            Assert.IsNotNull(order.CreatedBy);
            Assert.IsInstanceOfType(order.CreatedBy, typeof(User));
            Assert.AreEqual(value, order.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_Modified()
        {
            // Arrange
            var order = new Order();
            var value = DateTime.Now;

            // Act
            order.Modified = value;

            // Assert
            Assert.IsNotNull(order.Modified);
            Assert.IsInstanceOfType(order.Modified, typeof(DateTime));
            Assert.AreEqual(value, order.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_ModifiedBy()
        {
            // Arrange
            var order = new Order();
            var value = Core.Tests.TestHelper.User();

            // Act
            order.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(order.ModifiedBy);
            Assert.IsInstanceOfType(order.ModifiedBy, typeof(User));
            Assert.AreEqual(value, order.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_IsForCollection()
        {
            // Arrange
            var order = new Order();
            var value = true;

            // Act
            order.IsForCollection = value;

            // Assert
            Assert.IsNotNull(order.IsForCollection);
            Assert.IsInstanceOfType(order.IsForCollection, typeof(bool));
            Assert.AreEqual(value, order.IsForCollection);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_IsForDelivery()
        {
            // Arrange
            var order = new Order();
            var value = true;

            // Act
            order.IsForDelivery = value;

            // Assert
            Assert.IsNotNull(order.IsForDelivery);
            Assert.IsInstanceOfType(order.IsForDelivery, typeof(bool));
            Assert.AreEqual(value, order.IsForDelivery);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_IsQuote()
        {
            // Arrange
            var order = new Order();
            var value = true;

            // Act
            order.IsQuote = value;

            // Assert
            Assert.IsNotNull(order.IsQuote);
            Assert.IsInstanceOfType(order.IsQuote, typeof(bool));
            Assert.AreEqual(value, order.IsQuote);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_IsCancelled()
        {
            // Arrange
            var order = new Order();
            var value = true;

            // Act
            order.IsCancelled = value;

            // Assert
            Assert.IsNotNull(order.IsCancelled);
            Assert.IsInstanceOfType(order.IsCancelled, typeof(bool));
            Assert.AreEqual(value, order.IsCancelled);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_IsActive()
        {
            // Arrange
            var order = new Order();
            var value = true;

            // Act
            order.IsActive = value;

            // Assert
            Assert.IsNotNull(order.IsActive);
            Assert.IsInstanceOfType(order.IsActive, typeof(bool));
            Assert.AreEqual(value, order.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_IsDeleted()
        {
            // Arrange
            var order = new Order();
            var value = false;

            // Act
            order.IsDeleted = value;

            // Assert
            Assert.IsNotNull(order.IsDeleted);
            Assert.IsInstanceOfType(order.IsDeleted, typeof(bool));
            Assert.AreEqual(value, order.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Order_Property_Count()
        {
            var order = new Order();
            Assert.AreEqual(18, order.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Order_Extension_AsDTO_Null()
        {
            // Arrange
            Order order = null;

            // Act
            var result = order.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Order_Extension_AsDTO_NotNull()
        {
            // Arrange
            var order = TestHelper.Order();

            // Act
            var result = order.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OrderDto));

            Assert.IsNotNull(result.Customer);
            Assert.IsInstanceOfType(result.Customer, typeof(CustomerDto));

            Assert.IsNotNull(result.PlacementDate);
            Assert.IsInstanceOfType(result.PlacementDate, typeof(DateTime));
            Assert.AreEqual(order.PlacementDate, result.PlacementDate);

            Assert.IsNotNull(result.Products);
            Assert.IsInstanceOfType(result.Products, typeof(List<ProductOrderItemDto>));

            Assert.IsNotNull(result.Services);
            Assert.IsInstanceOfType(result.Services, typeof(List<ServiceOrderItemDto>));

            Assert.IsNotNull(result.TrackingNumber);
            Assert.IsInstanceOfType(result.TrackingNumber, typeof(string));
            Assert.AreEqual(order.TrackingNumber, result.TrackingNumber);

            Assert.IsNotNull(result.DeliveryAddress);
            Assert.IsInstanceOfType(result.DeliveryAddress, typeof(AddressDto));

            Assert.IsNotNull(result.CollectionAddress);
            Assert.IsInstanceOfType(result.CollectionAddress, typeof(AddressDto));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(order.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(order.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsForCollection);
            Assert.IsInstanceOfType(result.IsForCollection, typeof(bool));
            Assert.AreEqual(order.IsForCollection, result.IsForCollection);

            Assert.IsNotNull(result.IsForDelivery);
            Assert.IsInstanceOfType(result.IsForDelivery, typeof(bool));
            Assert.AreEqual(order.IsForDelivery, result.IsForDelivery);

            Assert.IsNotNull(result.IsQuote);
            Assert.IsInstanceOfType(result.IsQuote, typeof(bool));
            Assert.AreEqual(order.IsQuote, result.IsQuote);

            Assert.IsNotNull(result.IsCancelled);
            Assert.IsInstanceOfType(result.IsCancelled, typeof(bool));
            Assert.AreEqual(order.IsCancelled, result.IsCancelled);

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(order.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(order.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}