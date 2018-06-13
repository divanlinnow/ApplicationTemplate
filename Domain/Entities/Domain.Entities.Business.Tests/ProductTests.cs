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
    public class ProductTests
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
        public void Product_Property_Name()
        {
            // Arrange
            var product = new Product();
            var value = "Test Product";

            // Act
            product.Name = value;

            // Assert
            Assert.IsNotNull(product.Name);
            Assert.IsInstanceOfType(product.Name, typeof(string));
            Assert.AreEqual(value, product.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_Make()
        {
            // Arrange
            var product = new Product();
            var value = "Test Make";

            // Act
            product.Make = value;

            // Assert
            Assert.IsNotNull(product.Make);
            Assert.IsInstanceOfType(product.Make, typeof(string));
            Assert.AreEqual(value, product.Make);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_Model()
        {
            // Arrange
            var product = new Product();
            var value = "Test Model";

            // Act
            product.Model = value;

            // Assert
            Assert.IsNotNull(product.Model);
            Assert.IsInstanceOfType(product.Model, typeof(string));
            Assert.AreEqual(value, product.Model);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_Year()
        {
            // Arrange
            var product = new Product();
            var value = DateTime.Now.Year;

            // Act
            product.Year = value;

            // Assert
            Assert.IsNotNull(product.Year);
            Assert.IsInstanceOfType(product.Year, typeof(int));
            Assert.AreEqual(value, product.Year);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_Description()
        {
            // Arrange
            var product = new Product();
            var value = "Test Product Description";

            // Act
            product.Description = value;

            // Assert
            Assert.IsNotNull(product.Description);
            Assert.IsInstanceOfType(product.Description, typeof(string));
            Assert.AreEqual(value, product.Description);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_MinimumOrderQuantity()
        {
            // Arrange
            var product = new Product();
            var value = 10;

            // Act
            product.MinimumOrderQuantity = value;

            // Assert
            Assert.IsNotNull(product.MinimumOrderQuantity);
            Assert.IsInstanceOfType(product.MinimumOrderQuantity, typeof(decimal));
            Assert.AreEqual(value, product.MinimumOrderQuantity);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_PriceEXCL()
        {
            // Arrange
            var product = new Product();
            var value = 100;

            // Act
            product.PriceEXCL = value;

            // Assert
            Assert.IsNotNull(product.PriceEXCL);
            Assert.IsInstanceOfType(product.PriceEXCL, typeof(decimal));
            Assert.AreEqual(value, product.PriceEXCL);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_PriceINCL()
        {
            // Arrange
            var product = new Product();
            var value = 200;

            // Act
            product.PriceINCL = value;

            // Assert
            Assert.IsNotNull(product.PriceINCL);
            Assert.IsInstanceOfType(product.PriceINCL, typeof(decimal));
            Assert.AreEqual(value, product.PriceINCL);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_PriceMustChange()
        {
            // Arrange
            var product = new Product();
            var value = false;

            // Act
            product.PriceMustChange = value;

            // Assert
            Assert.IsNotNull(product.PriceMustChange);
            Assert.IsInstanceOfType(product.PriceMustChange, typeof(bool));
            Assert.AreEqual(value, product.PriceMustChange);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_PriceExpiryDate()
        {
            // Arrange
            var product = new Product();
            var value = DateTime.Now;

            // Act
            product.PriceExpiryDate = value;

            // Assert
            Assert.IsNotNull(product.PriceExpiryDate);
            Assert.IsInstanceOfType(product.PriceExpiryDate, typeof(DateTime));
            Assert.AreEqual(value, product.PriceExpiryDate);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_HasExpiryDate()
        {
            // Arrange
            var product = new Product();
            var value = false;

            // Act
            product.HasExpiryDate = value;

            // Assert
            Assert.IsNotNull(product.HasExpiryDate);
            Assert.IsInstanceOfType(product.HasExpiryDate, typeof(bool));
            Assert.AreEqual(value, product.HasExpiryDate);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_ExpiryDate_Null()
        {
            // Arrange
            var product = new Product();
            DateTime? value = null;

            // Act
            product.ExpiryDate = value;

            // Assert
            Assert.AreEqual(value, product.ExpiryDate);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_ExpiryDate_NotNull()
        {
            // Arrange
            var product = new Product();
            var value = DateTime.Now.AddYears(10);

            // Act
            product.ExpiryDate = value;

            // Assert
            Assert.IsNotNull(product.ExpiryDate);
            Assert.IsInstanceOfType(product.ExpiryDate, typeof(DateTime?));
            Assert.AreEqual(value, product.ExpiryDate);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_Supplier()
        {
            // Arrange
            var product = new Product();
            var value = TestHelper.Supplier();

            // Act
            product.Supplier = value;

            // Assert
            Assert.IsNotNull(product.Supplier);
            Assert.IsInstanceOfType(product.Supplier, typeof(Supplier));
            Assert.AreEqual(value, product.Supplier);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_Created()
        {
            // Arrange
            var product = new Product();
            var value = DateTime.Now;

            // Act
            product.Created = value;

            // Assert
            Assert.IsNotNull(product.Created);
            Assert.IsInstanceOfType(product.Created, typeof(DateTime));
            Assert.AreEqual(value, product.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_CreatedBy()
        {
            // Arrange
            var product = new Product();
            var value = Core.Tests.TestHelper.User();

            // Act
            product.CreatedBy = value;

            // Assert
            Assert.IsNotNull(product.CreatedBy);
            Assert.IsInstanceOfType(product.CreatedBy, typeof(User));
            Assert.AreEqual(value, product.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_Modified()
        {
            // Arrange
            var product = new Product();
            var value = DateTime.Now;

            // Act
            product.Modified = value;

            // Assert
            Assert.IsNotNull(product.Modified);
            Assert.IsInstanceOfType(product.Modified, typeof(DateTime));
            Assert.AreEqual(value, product.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_ModifiedBy()
        {
            // Arrange
            var product = new Product();
            var value = Core.Tests.TestHelper.User();

            // Act
            product.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(product.ModifiedBy);
            Assert.IsInstanceOfType(product.ModifiedBy, typeof(User));
            Assert.AreEqual(value, product.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_IsActive()
        {
            // Arrange
            var product = new Product();
            var value = true;

            // Act
            product.IsActive = value;

            // Assert
            Assert.IsNotNull(product.IsActive);
            Assert.IsInstanceOfType(product.IsActive, typeof(bool));
            Assert.AreEqual(value, product.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_IsDeleted()
        {
            // Arrange
            var product = new Product();
            var value = false;

            // Act
            product.IsDeleted = value;

            // Assert
            Assert.IsNotNull(product.IsDeleted);
            Assert.IsInstanceOfType(product.IsDeleted, typeof(bool));
            Assert.AreEqual(value, product.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Product_Property_Count()
        {
            var product = new Product();
            Assert.AreEqual(20, product.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Product_Extension_AsDTO_Null()
        {
            // Arrange
            Product product = null;

            // Act
            var result = product.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Product_Extension_AsDTO_NotNull()
        {
            // Arrange
            var product = TestHelper.Product();

            // Act
            var result = product.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ProductDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(product.Name, result.Name);

            Assert.IsNotNull(result.Make);
            Assert.IsInstanceOfType(result.Make, typeof(string));
            Assert.AreEqual(product.Make, result.Make);

            Assert.IsNotNull(result.Model);
            Assert.IsInstanceOfType(result.Model, typeof(string));
            Assert.AreEqual(product.Model, result.Model);

            Assert.IsNotNull(result.Year);
            Assert.IsInstanceOfType(result.Year, typeof(int));
            Assert.AreEqual(product.Year, result.Year);

            Assert.IsNotNull(result.Description);
            Assert.IsInstanceOfType(result.Description, typeof(string));
            Assert.AreEqual(product.Description, result.Description);

            Assert.IsNotNull(result.MinimumOrderQuantity);
            Assert.IsInstanceOfType(result.MinimumOrderQuantity, typeof(decimal));
            Assert.AreEqual(product.MinimumOrderQuantity, result.MinimumOrderQuantity);

            Assert.IsNotNull(result.PriceEXCL);
            Assert.IsInstanceOfType(result.PriceEXCL, typeof(decimal));
            Assert.AreEqual(product.PriceEXCL, result.PriceEXCL);

            Assert.IsNotNull(result.PriceINCL);
            Assert.IsInstanceOfType(result.PriceINCL, typeof(decimal));
            Assert.AreEqual(product.PriceINCL, result.PriceINCL);

            Assert.IsNotNull(result.PriceMustChange);
            Assert.IsInstanceOfType(result.PriceMustChange, typeof(bool));
            Assert.AreEqual(product.PriceMustChange, result.PriceMustChange);

            Assert.IsNotNull(result.PriceExpiryDate);
            Assert.IsInstanceOfType(result.PriceExpiryDate, typeof(DateTime));
            Assert.AreEqual(product.PriceExpiryDate, result.PriceExpiryDate);

            Assert.IsNotNull(result.HasExpiryDate);
            Assert.IsInstanceOfType(result.HasExpiryDate, typeof(bool));
            Assert.AreEqual(product.HasExpiryDate, result.HasExpiryDate);

            Assert.IsNotNull(result.ExpiryDate);
            Assert.IsInstanceOfType(result.ExpiryDate, typeof(DateTime?));
            Assert.AreEqual(product.ExpiryDate, result.ExpiryDate);

            Assert.IsNotNull(result.Supplier);
            Assert.IsInstanceOfType(result.Supplier, typeof(SupplierDto));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(product.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(product.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(product.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(product.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}