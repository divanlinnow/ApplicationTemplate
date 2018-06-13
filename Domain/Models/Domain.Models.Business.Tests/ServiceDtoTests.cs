using Domain.Entities.Business;
using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Models.Business.Tests
{
    [TestClass]
    public class ServiceDtoTests
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
        public void ServiceDto_Property_Name()
        {
            var service = new ServiceDto();
            var value = "Test Product";

            service.Name = value;

            Assert.IsNotNull(service.Name);
            Assert.IsInstanceOfType(service.Name, typeof(string));
            Assert.AreEqual(value, service.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_Description()
        {
            var service = new ServiceDto();
            var value = "Test Product Description";

            service.Description = value;

            Assert.IsNotNull(service.Description);
            Assert.IsInstanceOfType(service.Description, typeof(string));
            Assert.AreEqual(value, service.Description);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_MinimumOrderQuantity()
        {
            var service = new ServiceDto();
            var value = 10;

            service.MinimumOrderQuantity = value;

            Assert.IsNotNull(service.MinimumOrderQuantity);
            Assert.IsInstanceOfType(service.MinimumOrderQuantity, typeof(decimal));
            Assert.AreEqual(value, service.MinimumOrderQuantity);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_PriceEXCL()
        {
            var service = new ServiceDto();
            var value = 100;

            service.PriceEXCL = value;

            Assert.IsNotNull(service.PriceEXCL);
            Assert.IsInstanceOfType(service.PriceEXCL, typeof(decimal));
            Assert.AreEqual(value, service.PriceEXCL);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_PriceINCL()
        {
            var service = new ServiceDto();
            var value = 200;

            service.PriceINCL = value;

            Assert.IsNotNull(service.PriceINCL);
            Assert.IsInstanceOfType(service.PriceINCL, typeof(decimal));
            Assert.AreEqual(value, service.PriceINCL);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_PriceMustChange()
        {
            var service = new ServiceDto();
            var value = false;

            service.PriceMustChange = value;

            Assert.IsNotNull(service.PriceMustChange);
            Assert.IsInstanceOfType(service.PriceMustChange, typeof(bool));
            Assert.AreEqual(value, service.PriceMustChange);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_PriceExpiryDate()
        {
            var service = new ServiceDto();
            var value = DateTime.Now;

            service.PriceExpiryDate = value;

            Assert.IsNotNull(service.PriceExpiryDate);
            Assert.IsInstanceOfType(service.PriceExpiryDate, typeof(DateTime));
            Assert.AreEqual(value, service.PriceExpiryDate);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_HasExpiryDate()
        {
            var service = new ServiceDto();
            var value = false;

            service.HasExpiryDate = value;

            Assert.IsNotNull(service.HasExpiryDate);
            Assert.IsInstanceOfType(service.HasExpiryDate, typeof(bool));
            Assert.AreEqual(value, service.HasExpiryDate);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_ExpiryDate_Null()
        {
            var service = new ServiceDto();
            DateTime? value = null;

            service.ExpiryDate = value;

            Assert.AreEqual(value, service.ExpiryDate);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_ExpiryDate_NotNull()
        {
            var service = new ServiceDto();
            var value = DateTime.Now.AddYears(10);

            service.ExpiryDate = value;

            Assert.IsNotNull(service.ExpiryDate);
            Assert.IsInstanceOfType(service.ExpiryDate, typeof(DateTime?));
            Assert.AreEqual(value, service.ExpiryDate);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_Supplier()
        {
            var service = new ServiceDto();
            var value = TestHelper.SupplierDto();

            service.Supplier = value;

            Assert.IsNotNull(service.Supplier);
            Assert.IsInstanceOfType(service.Supplier, typeof(SupplierDto));
            Assert.AreEqual(value, service.Supplier);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_Created()
        {
            var service = new ServiceDto();
            var value = DateTime.Now;

            service.Created = value;

            Assert.IsNotNull(service.Created);
            Assert.IsInstanceOfType(service.Created, typeof(DateTime));
            Assert.AreEqual(value, service.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_CreatedBy()
        {
            var service = new ServiceDto();
            var value = Core.Tests.TestHelper.UserDto();

            service.CreatedBy = value;

            Assert.IsNotNull(service.CreatedBy);
            Assert.IsInstanceOfType(service.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, service.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_Modified()
        {
            var service = new ServiceDto();
            var value = DateTime.Now;

            service.Modified = value;

            Assert.IsNotNull(service.Modified);
            Assert.IsInstanceOfType(service.Modified, typeof(DateTime));
            Assert.AreEqual(value, service.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_ModifiedBy()
        {
            var service = new ServiceDto();
            var value = Core.Tests.TestHelper.UserDto();

            service.ModifiedBy = value;

            Assert.IsNotNull(service.ModifiedBy);
            Assert.IsInstanceOfType(service.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, service.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_IsActive()
        {
            var service = new ServiceDto();
            var value = true;

            service.IsActive = value;

            Assert.IsNotNull(service.IsActive);
            Assert.IsInstanceOfType(service.IsActive, typeof(bool));
            Assert.AreEqual(value, service.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_IsDeleted()
        {
            var service = new ServiceDto();
            var value = false;

            service.IsDeleted = value;

            Assert.IsNotNull(service.IsDeleted);
            Assert.IsInstanceOfType(service.IsDeleted, typeof(bool));
            Assert.AreEqual(value, service.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ServiceDto_Property_Count()
        {
            var service = new ServiceDto();
            Assert.AreEqual(17, service.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void ServiceDto_Extension_AsEntity_Null()
        {
            ServiceDto service = null;
            var result = service.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void ServiceDto_Extension_AsEntity_NotNull()
        {
            var service = TestHelper.ServiceDto();
            var result = service.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Service));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(service.Name, result.Name);

            Assert.IsNotNull(result.Description);
            Assert.IsInstanceOfType(result.Description, typeof(string));
            Assert.AreEqual(service.Description, result.Description);

            Assert.IsNotNull(result.MinimumOrderQuantity);
            Assert.IsInstanceOfType(result.MinimumOrderQuantity, typeof(decimal));
            Assert.AreEqual(service.MinimumOrderQuantity, result.MinimumOrderQuantity);

            Assert.IsNotNull(result.PriceEXCL);
            Assert.IsInstanceOfType(result.PriceEXCL, typeof(decimal));
            Assert.AreEqual(service.PriceEXCL, result.PriceEXCL);

            Assert.IsNotNull(result.PriceINCL);
            Assert.IsInstanceOfType(result.PriceINCL, typeof(decimal));
            Assert.AreEqual(service.PriceINCL, result.PriceINCL);

            Assert.IsNotNull(result.PriceMustChange);
            Assert.IsInstanceOfType(result.PriceMustChange, typeof(bool));
            Assert.AreEqual(service.PriceMustChange, result.PriceMustChange);

            Assert.IsNotNull(result.PriceExpiryDate);
            Assert.IsInstanceOfType(result.PriceExpiryDate, typeof(DateTime));
            Assert.AreEqual(service.PriceExpiryDate, result.PriceExpiryDate);

            Assert.IsNotNull(result.HasExpiryDate);
            Assert.IsInstanceOfType(result.HasExpiryDate, typeof(bool));
            Assert.AreEqual(service.HasExpiryDate, result.HasExpiryDate);

            Assert.IsNotNull(result.ExpiryDate);
            Assert.IsInstanceOfType(result.ExpiryDate, typeof(DateTime?));
            Assert.AreEqual(service.ExpiryDate, result.ExpiryDate);

            Assert.IsNotNull(result.Supplier);
            Assert.IsInstanceOfType(result.Supplier, typeof(Supplier));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(service.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(service.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(service.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(service.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}