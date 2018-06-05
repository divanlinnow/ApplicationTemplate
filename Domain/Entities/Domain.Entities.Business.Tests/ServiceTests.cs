using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Entities.Business.Tests
{
    [TestClass]
    public class ServiceTests
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
        public void Service_Property_Name()
        {
            // Arrange
            var service = new Service();
            var value = "Test Product";

            // Act
            service.Name = value;

            // Assert
            Assert.IsNotNull(service.Name);
            Assert.IsInstanceOfType(service.Name, typeof(string));
            Assert.AreEqual(value, service.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_Description()
        {
            // Arrange
            var service = new Service();
            var value = "Test Product Description";

            // Act
            service.Description = value;

            // Assert
            Assert.IsNotNull(service.Description);
            Assert.IsInstanceOfType(service.Description, typeof(string));
            Assert.AreEqual(value, service.Description);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_MinimumOrderQuantity()
        {
            // Arrange
            var service = new Service();
            var value = 10;

            // Act
            service.MinimumOrderQuantity = value;

            // Assert
            Assert.IsNotNull(service.MinimumOrderQuantity);
            Assert.IsInstanceOfType(service.MinimumOrderQuantity, typeof(decimal));
            Assert.AreEqual(value, service.MinimumOrderQuantity);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_PriceEXCL()
        {
            // Arrange
            var service = new Service();
            var value = 100;

            // Act
            service.PriceEXCL = value;

            // Assert
            Assert.IsNotNull(service.PriceEXCL);
            Assert.IsInstanceOfType(service.PriceEXCL, typeof(decimal));
            Assert.AreEqual(value, service.PriceEXCL);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_PriceINCL()
        {
            // Arrange
            var service = new Service();
            var value = 200;

            // Act
            service.PriceINCL = value;

            // Assert
            Assert.IsNotNull(service.PriceINCL);
            Assert.IsInstanceOfType(service.PriceINCL, typeof(decimal));
            Assert.AreEqual(value, service.PriceINCL);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_PriceMustChange()
        {
            // Arrange
            var service = new Service();
            var value = false;

            // Act
            service.PriceMustChange = value;

            // Assert
            Assert.IsNotNull(service.PriceMustChange);
            Assert.IsInstanceOfType(service.PriceMustChange, typeof(bool));
            Assert.AreEqual(value, service.PriceMustChange);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_PriceExpiryDate()
        {
            // Arrange
            var service = new Service();
            var value = DateTime.Now;

            // Act
            service.PriceExpiryDate = value;

            // Assert
            Assert.IsNotNull(service.PriceExpiryDate);
            Assert.IsInstanceOfType(service.PriceExpiryDate, typeof(DateTime));
            Assert.AreEqual(value, service.PriceExpiryDate);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_HasExpiryDate()
        {
            // Arrange
            var service = new Service();
            var value = false;

            // Act
            service.HasExpiryDate = value;

            // Assert
            Assert.IsNotNull(service.HasExpiryDate);
            Assert.IsInstanceOfType(service.HasExpiryDate, typeof(bool));
            Assert.AreEqual(value, service.HasExpiryDate);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_ExpiryDate_Null()
        {
            // Arrange
            var service = new Service();
            DateTime? value = null;

            // Act
            service.ExpiryDate = value;

            // Assert
            Assert.AreEqual(value, service.ExpiryDate);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_ExpiryDate_NotNull()
        {
            // Arrange
            var service = new Service();
            var value = DateTime.Now.AddYears(10);

            // Act
            service.ExpiryDate = value;

            // Assert
            Assert.IsNotNull(service.ExpiryDate);
            Assert.IsInstanceOfType(service.ExpiryDate, typeof(DateTime?));
            Assert.AreEqual(value, service.ExpiryDate);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_Supplier()
        {
            // Arrange
            var service = new Service();
            var value = TestHelper.Supplier();

            // Act
            service.Supplier = value;

            // Assert
            Assert.IsNotNull(service.Supplier);
            Assert.IsInstanceOfType(service.Supplier, typeof(Supplier));
            Assert.AreEqual(value, service.Supplier);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_Created()
        {
            // Arrange
            var service = new Service();
            var value = DateTime.Now;

            // Act
            service.Created = value;

            // Assert
            Assert.IsNotNull(service.Created);
            Assert.IsInstanceOfType(service.Created, typeof(DateTime));
            Assert.AreEqual(value, service.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_CreatedBy()
        {
            // Arrange
            var service = new Service();
            var value = Core.Tests.TestHelper.User();

            // Act
            service.CreatedBy = value;

            // Assert
            Assert.IsNotNull(service.CreatedBy);
            Assert.IsInstanceOfType(service.CreatedBy, typeof(User));
            Assert.AreEqual(value, service.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_Modified()
        {
            // Arrange
            var service = new Service();
            var value = DateTime.Now;

            // Act
            service.Modified = value;

            // Assert
            Assert.IsNotNull(service.Modified);
            Assert.IsInstanceOfType(service.Modified, typeof(DateTime));
            Assert.AreEqual(value, service.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_ModifiedBy()
        {
            // Arrange
            var service = new Service();
            var value = Core.Tests.TestHelper.User();

            // Act
            service.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(service.ModifiedBy);
            Assert.IsInstanceOfType(service.ModifiedBy, typeof(User));
            Assert.AreEqual(value, service.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_IsActive()
        {
            // Arrange
            var service = new Service();
            var value = true;

            // Act
            service.IsActive = value;

            // Assert
            Assert.IsNotNull(service.IsActive);
            Assert.IsInstanceOfType(service.IsActive, typeof(bool));
            Assert.AreEqual(value, service.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_IsDeleted()
        {
            // Arrange
            var service = new Service();
            var value = false;

            // Act
            service.IsDeleted = value;

            // Assert
            Assert.IsNotNull(service.IsDeleted);
            Assert.IsInstanceOfType(service.IsDeleted, typeof(bool));
            Assert.AreEqual(value, service.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Service_Property_Count()
        {
            var service = new Service();
            Assert.AreEqual(17, service.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Service_Extension_AsDTO_Null()
        {
            // Arrange
            Service service = null;

            // Act
            var result = service.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Service_Extension_AsDTO_NotNull()
        {
            // Arrange
            var service = TestHelper.Service();

            // Act
            var result = service.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ServiceDto));

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
            Assert.IsInstanceOfType(result.Supplier, typeof(SupplierDto));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(service.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(service.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

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