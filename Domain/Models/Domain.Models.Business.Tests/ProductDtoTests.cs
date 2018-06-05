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
    public class ProductDtoTests
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
        public void ProductDto_Property_Name()
        {
            var product = new ProductDto();
            var value = "Test Product";

            product.Name = value;

            Assert.IsNotNull(product.Name);
            Assert.IsInstanceOfType(product.Name, typeof(string));
            Assert.AreEqual(value, product.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_Make()
        {
            var product = new ProductDto();
            var value = "Test Make";

            product.Make = value;

            Assert.IsNotNull(product.Make);
            Assert.IsInstanceOfType(product.Make, typeof(string));
            Assert.AreEqual(value, product.Make);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_Model()
        {
            var product = new ProductDto();
            var value = "Test Model";

            product.Model = value;

            Assert.IsNotNull(product.Model);
            Assert.IsInstanceOfType(product.Model, typeof(string));
            Assert.AreEqual(value, product.Model);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_Year()
        {
            var product = new ProductDto();
            var value = DateTime.Now.Year;

            product.Year = value;

            Assert.IsNotNull(product.Year);
            Assert.IsInstanceOfType(product.Year, typeof(int));
            Assert.AreEqual(value, product.Year);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_Description()
        {
            var product = new ProductDto();
            var value = "Test Product Description";

            product.Description = value;

            Assert.IsNotNull(product.Description);
            Assert.IsInstanceOfType(product.Description, typeof(string));
            Assert.AreEqual(value, product.Description);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_MinimumOrderQuantity()
        {
            var product = new ProductDto();
            var value = 10;

            product.MinimumOrderQuantity = value;

            Assert.IsNotNull(product.MinimumOrderQuantity);
            Assert.IsInstanceOfType(product.MinimumOrderQuantity, typeof(decimal));
            Assert.AreEqual(value, product.MinimumOrderQuantity);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_PriceEXCL()
        {
            var product = new ProductDto();
            var value = 100;

            product.PriceEXCL = value;

            Assert.IsNotNull(product.PriceEXCL);
            Assert.IsInstanceOfType(product.PriceEXCL, typeof(decimal));
            Assert.AreEqual(value, product.PriceEXCL);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_PriceINCL()
        {
            var product = new ProductDto();
            var value = 200;

            product.PriceINCL = value;

            Assert.IsNotNull(product.PriceINCL);
            Assert.IsInstanceOfType(product.PriceINCL, typeof(decimal));
            Assert.AreEqual(value, product.PriceINCL);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_PriceMustChange()
        {
            var product = new ProductDto();
            var value = false;

            product.PriceMustChange = value;

            Assert.IsNotNull(product.PriceMustChange);
            Assert.IsInstanceOfType(product.PriceMustChange, typeof(bool));
            Assert.AreEqual(value, product.PriceMustChange);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_PriceExpiryDate()
        {
            var product = new ProductDto();
            var value = DateTime.Now;

            product.PriceExpiryDate = value;

            Assert.IsNotNull(product.PriceExpiryDate);
            Assert.IsInstanceOfType(product.PriceExpiryDate, typeof(DateTime));
            Assert.AreEqual(value, product.PriceExpiryDate);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_HasExpiryDate()
        {
            var product = new ProductDto();
            var value = false;

            product.HasExpiryDate = value;

            Assert.IsNotNull(product.HasExpiryDate);
            Assert.IsInstanceOfType(product.HasExpiryDate, typeof(bool));
            Assert.AreEqual(value, product.HasExpiryDate);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_ExpiryDate_Null()
        {
            var product = new ProductDto();
            DateTime? value = null;

            product.ExpiryDate = value;

            Assert.AreEqual(value, product.ExpiryDate);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_ExpiryDate_NotNull()
        {
            var product = new ProductDto();
            var value = DateTime.Now.AddYears(10);

            product.ExpiryDate = value;

            Assert.IsNotNull(product.ExpiryDate);
            Assert.IsInstanceOfType(product.ExpiryDate, typeof(DateTime?));
            Assert.AreEqual(value, product.ExpiryDate);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_Supplier()
        {
            var product = new ProductDto();
            var value = TestHelper.SupplierDto();

            product.Supplier = value;

            Assert.IsNotNull(product.Supplier);
            Assert.IsInstanceOfType(product.Supplier, typeof(SupplierDto));
            Assert.AreEqual(value, product.Supplier);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_Created()
        {
            var product = new ProductDto();
            var value = DateTime.Now;

            product.Created = value;

            Assert.IsNotNull(product.Created);
            Assert.IsInstanceOfType(product.Created, typeof(DateTime));
            Assert.AreEqual(value, product.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_CreatedBy()
        {
            var product = new ProductDto();
            var value = Core.Tests.TestHelper.UserDto();

            product.CreatedBy = value;

            Assert.IsNotNull(product.CreatedBy);
            Assert.IsInstanceOfType(product.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, product.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_Modified()
        {
            var product = new ProductDto();
            var value = DateTime.Now;

            product.Modified = value;

            Assert.IsNotNull(product.Modified);
            Assert.IsInstanceOfType(product.Modified, typeof(DateTime));
            Assert.AreEqual(value, product.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_ModifiedBy()
        {
            var product = new ProductDto();
            var value = Core.Tests.TestHelper.UserDto();

            product.ModifiedBy = value;

            Assert.IsNotNull(product.ModifiedBy);
            Assert.IsInstanceOfType(product.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, product.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_IsActive()
        {
            var product = new ProductDto();
            var value = true;

            product.IsActive = value;

            Assert.IsNotNull(product.IsActive);
            Assert.IsInstanceOfType(product.IsActive, typeof(bool));
            Assert.AreEqual(value, product.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_IsDeleted()
        {
            var product = new ProductDto();
            var value = false;

            product.IsDeleted = value;

            Assert.IsNotNull(product.IsDeleted);
            Assert.IsInstanceOfType(product.IsDeleted, typeof(bool));
            Assert.AreEqual(value, product.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void ProductDto_Property_Count()
        {
            var product = new ProductDto();
            Assert.AreEqual(20, product.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void ProductDto_Extension_AsEntity_Null()
        {
            ProductDto product = null;
            var result = product.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void ProductDto_Extension_AsEntity_NotNull()
        {
            var product = TestHelper.ProductDto();
            var result = product.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Product));

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
            Assert.IsInstanceOfType(result.Supplier, typeof(Supplier));

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(product.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(product.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

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