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
    public class SupplierTests
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
        public void Supplier_Property_Organization()
        {
            // Arrange
            var supplier = new Supplier();
            var value = TestHelper.Organization();

            // Act
            supplier.Organization = value;

            // Assert
            Assert.IsNotNull(supplier.Organization);
            Assert.IsInstanceOfType(supplier.Organization, typeof(Organization));
            Assert.AreEqual(value, supplier.Organization);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Supplier_Property_Name()
        {
            // Arrange
            var supplier = new Supplier();
            var value = "Test Supplier";

            // Act
            supplier.Name = value;

            // Assert
            Assert.IsNotNull(supplier.Name);
            Assert.IsInstanceOfType(supplier.Name, typeof(string));
            Assert.AreEqual(value, supplier.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Supplier_Property_Created()
        {
            // Arrange
            var supplier = new Supplier();
            var value = DateTime.Now;

            // Act
            supplier.Created = value;

            // Assert
            Assert.IsNotNull(supplier.Created);
            Assert.IsInstanceOfType(supplier.Created, typeof(DateTime));
            Assert.AreEqual(value, supplier.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Supplier_Property_CreatedBy()
        {
            // Arrange
            var supplier = new Supplier();
            var value = Core.Tests.TestHelper.User();

            // Act
            supplier.CreatedBy = value;

            // Assert
            Assert.IsNotNull(supplier.CreatedBy);
            Assert.IsInstanceOfType(supplier.CreatedBy, typeof(User));
            Assert.AreEqual(value, supplier.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Supplier_Property_Modified()
        {
            // Arrange
            var supplier = new Supplier();
            var value = DateTime.Now;

            // Act
            supplier.Modified = value;

            // Assert
            Assert.IsNotNull(supplier.Modified);
            Assert.IsInstanceOfType(supplier.Modified, typeof(DateTime));
            Assert.AreEqual(value, supplier.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Supplier_Property_ModifiedBy()
        {
            // Arrange
            var supplier = new Supplier();
            var value = Core.Tests.TestHelper.User();

            // Act
            supplier.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(supplier.ModifiedBy);
            Assert.IsInstanceOfType(supplier.ModifiedBy, typeof(User));
            Assert.AreEqual(value, supplier.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Supplier_Property_IsActive()
        {
            // Arrange
            var supplier = new Supplier();
            var value = true;

            // Act
            supplier.IsActive = value;

            // Assert
            Assert.IsNotNull(supplier.IsActive);
            Assert.IsInstanceOfType(supplier.IsActive, typeof(bool));
            Assert.AreEqual(value, supplier.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Supplier_Property_IsDeleted()
        {
            // Arrange
            var supplier = new Supplier();
            var value = false;

            // Act
            supplier.IsDeleted = value;

            // Assert
            Assert.IsNotNull(supplier.IsDeleted);
            Assert.IsInstanceOfType(supplier.IsDeleted, typeof(bool));
            Assert.AreEqual(value, supplier.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Supplier_Property_Count()
        {
            var supplier = new Supplier();
            Assert.AreEqual(9, supplier.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Supplier_Extension_AsDTO_Null()
        {
            // Arrange
            Supplier supplier = null;

            // Act
            var result = supplier.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Supplier_Extension_AsDTO_NotNull()
        {
            // Arrange
            var supplier = TestHelper.Supplier();

            // Act
            var result = supplier.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(SupplierDto));

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(OrganizationDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(supplier.Name, result.Name);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(supplier.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(supplier.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(supplier.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(supplier.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}