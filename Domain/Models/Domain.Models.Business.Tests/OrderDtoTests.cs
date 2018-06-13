using Domain.Entities.Business;
using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.Business.Tests
{
    [TestClass]
    public class OrderDtoTests
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
        public void OrderDto_Property_Customer()
        {
            var order = new OrderDto();
            var value = TestHelper.CustomerDto();

            order.Customer = value;

            Assert.IsNotNull(order.Customer);
            Assert.IsInstanceOfType(order.Customer, typeof(CustomerDto));
            Assert.AreEqual(value, order.Customer);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_PlacementDate()
        {
            var order = new OrderDto();
            var value = DateTime.Now;

            order.PlacementDate = value;

            Assert.IsNotNull(order.PlacementDate);
            Assert.IsInstanceOfType(order.PlacementDate, typeof(DateTime));
            Assert.AreEqual(value, order.PlacementDate);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_Products()
        {
            var order = new OrderDto();
            var value = TestHelper.ProductOrderItemDtos();

            order.Products = value;

            Assert.IsNotNull(order.Products);
            Assert.IsInstanceOfType(order.Products, typeof(List<ProductOrderItemDto>));
            Assert.AreEqual(value, order.Products);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_Services()
        {
            var order = new OrderDto();
            var value = TestHelper.ServiceOrderItems();

            order.Services = value;

            Assert.IsNotNull(order.Services);
            Assert.IsInstanceOfType(order.Services, typeof(List<ServiceOrderItemDto>));
            Assert.AreEqual(value, order.Services);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_TrackingNumber()
        {
            var order = new OrderDto();
            var value = "Test Tracking Number ABC 123";

            order.TrackingNumber = value;

            Assert.IsNotNull(order.TrackingNumber);
            Assert.IsInstanceOfType(order.TrackingNumber, typeof(string));
            Assert.AreEqual(value, order.TrackingNumber);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_DeliveryAddress()
        {
            var order = new OrderDto();
            var value = Core.Tests.TestHelper.AddressDto();

            order.DeliveryAddress = value;

            Assert.IsNotNull(order.DeliveryAddress);
            Assert.IsInstanceOfType(order.DeliveryAddress, typeof(AddressDto));
            Assert.AreEqual(value, order.DeliveryAddress);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_CollectionAddress()
        {
            var order = new OrderDto();
            var value = Core.Tests.TestHelper.AddressDto();

            order.CollectionAddress = value;

            Assert.IsNotNull(order.CollectionAddress);
            Assert.IsInstanceOfType(order.CollectionAddress, typeof(AddressDto));
            Assert.AreEqual(value, order.CollectionAddress);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_Created()
        {
            var order = new OrderDto();
            var value = DateTime.Now;

            order.Created = value;

            Assert.IsNotNull(order.Created);
            Assert.IsInstanceOfType(order.Created, typeof(DateTime));
            Assert.AreEqual(value, order.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_CreatedBy()
        {
            var order = new OrderDto();
            var value = Core.Tests.TestHelper.UserDto();

            order.CreatedBy = value;

            Assert.IsNotNull(order.CreatedBy);
            Assert.IsInstanceOfType(order.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, order.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_Modified()
        {
            var order = new OrderDto();
            var value = DateTime.Now;

            order.Modified = value;

            Assert.IsNotNull(order.Modified);
            Assert.IsInstanceOfType(order.Modified, typeof(DateTime));
            Assert.AreEqual(value, order.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_ModifiedBy()
        {
            var order = new OrderDto();
            var value = Core.Tests.TestHelper.UserDto();

            order.ModifiedBy = value;

            Assert.IsNotNull(order.ModifiedBy);
            Assert.IsInstanceOfType(order.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, order.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_IsForCollection()
        {
            var order = new OrderDto();
            var value = true;

            order.IsForCollection = value;

            Assert.IsNotNull(order.IsForCollection);
            Assert.IsInstanceOfType(order.IsForCollection, typeof(bool));
            Assert.AreEqual(value, order.IsForCollection);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_IsForDelivery()
        {
            var order = new OrderDto();
            var value = true;

            order.IsForDelivery = value;

            Assert.IsNotNull(order.IsForDelivery);
            Assert.IsInstanceOfType(order.IsForDelivery, typeof(bool));
            Assert.AreEqual(value, order.IsForDelivery);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_IsQuote()
        {
            var order = new OrderDto();
            var value = true;

            order.IsQuote = value;

            Assert.IsNotNull(order.IsQuote);
            Assert.IsInstanceOfType(order.IsQuote, typeof(bool));
            Assert.AreEqual(value, order.IsQuote);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_IsCancelled()
        {
            var order = new OrderDto();
            var value = true;

            order.IsCancelled = value;

            Assert.IsNotNull(order.IsCancelled);
            Assert.IsInstanceOfType(order.IsCancelled, typeof(bool));
            Assert.AreEqual(value, order.IsCancelled);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_IsActive()
        {
            var order = new OrderDto();
            var value = true;

            order.IsActive = value;

            Assert.IsNotNull(order.IsActive);
            Assert.IsInstanceOfType(order.IsActive, typeof(bool));
            Assert.AreEqual(value, order.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_IsDeleted()
        {
            var order = new OrderDto();
            var value = false;

            order.IsDeleted = value;

            Assert.IsNotNull(order.IsDeleted);
            Assert.IsInstanceOfType(order.IsDeleted, typeof(bool));
            Assert.AreEqual(value, order.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void OrderDto_Property_Count()
        {
            var order = new OrderDto();
            Assert.AreEqual(18, order.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void OrderDto_Extension_AsEntity_Null()
        {
            OrderDto order = null;
            var result = order.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void OrderDto_Extension_AsEntity_NotNull()
        {
            var order = TestHelper.OrderDto();
            var result = order.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Order));

            Assert.IsNotNull(result.Customer);
            Assert.IsInstanceOfType(result.Customer, typeof(Customer));

            Assert.IsNotNull(result.PlacementDate);
            Assert.IsInstanceOfType(result.PlacementDate, typeof(DateTime));
            Assert.AreEqual(order.PlacementDate, result.PlacementDate);

            Assert.IsNotNull(result.Products);
            Assert.IsInstanceOfType(result.Products, typeof(List<ProductOrderItem>));

            Assert.IsNotNull(result.Services);
            Assert.IsInstanceOfType(result.Services, typeof(List<ServiceOrderItem>));

            Assert.IsNotNull(result.TrackingNumber);
            Assert.IsInstanceOfType(result.TrackingNumber, typeof(string));
            Assert.AreEqual(order.TrackingNumber, result.TrackingNumber);

            Assert.IsNotNull(result.DeliveryAddress);
            Assert.IsInstanceOfType(result.DeliveryAddress, typeof(Address));

            Assert.IsNotNull(result.CollectionAddress);
            Assert.IsInstanceOfType(result.CollectionAddress, typeof(Address));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(order.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(order.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

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