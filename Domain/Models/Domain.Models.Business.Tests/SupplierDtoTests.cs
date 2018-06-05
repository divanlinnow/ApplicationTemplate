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
    public class SupplierDtoTests
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
        public void SupplierDto_Property_Organization()
        {
            var supplier = new SupplierDto();
            var value = TestHelper.OrganizationDto();

            supplier.Organization = value;

            Assert.IsNotNull(supplier.Organization);
            Assert.IsInstanceOfType(supplier.Organization, typeof(OrganizationDto));
            Assert.AreEqual(value, supplier.Organization);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void SupplierDto_Property_Name()
        {
            var supplier = new SupplierDto();
            var value = "Test Supplier";

            supplier.Name = value;

            Assert.IsNotNull(supplier.Name);
            Assert.IsInstanceOfType(supplier.Name, typeof(string));
            Assert.AreEqual(value, supplier.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void SupplierDto_Property_Created()
        {
            var supplier = new SupplierDto();
            var value = DateTime.Now;

            supplier.Created = value;

            Assert.IsNotNull(supplier.Created);
            Assert.IsInstanceOfType(supplier.Created, typeof(DateTime));
            Assert.AreEqual(value, supplier.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void SupplierDto_Property_CreatedBy()
        {
            var supplier = new SupplierDto();
            var value = Core.Tests.TestHelper.UserDto();

            supplier.CreatedBy = value;

            Assert.IsNotNull(supplier.CreatedBy);
            Assert.IsInstanceOfType(supplier.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, supplier.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void SupplierDto_Property_Modified()
        {
            var supplier = new SupplierDto();
            var value = DateTime.Now;

            supplier.Modified = value;

            Assert.IsNotNull(supplier.Modified);
            Assert.IsInstanceOfType(supplier.Modified, typeof(DateTime));
            Assert.AreEqual(value, supplier.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void SupplierDto_Property_ModifiedBy()
        {
            var supplier = new SupplierDto();
            var value = Core.Tests.TestHelper.UserDto();

            supplier.ModifiedBy = value;

            Assert.IsNotNull(supplier.ModifiedBy);
            Assert.IsInstanceOfType(supplier.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, supplier.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void SupplierDto_Property_IsActive()
        {
            var supplier = new SupplierDto();
            var value = true;

            supplier.IsActive = value;

            Assert.IsNotNull(supplier.IsActive);
            Assert.IsInstanceOfType(supplier.IsActive, typeof(bool));
            Assert.AreEqual(value, supplier.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void SupplierDto_Property_IsDeleted()
        {
            var supplier = new SupplierDto();
            var value = false;

            supplier.IsDeleted = value;

            Assert.IsNotNull(supplier.IsDeleted);
            Assert.IsInstanceOfType(supplier.IsDeleted, typeof(bool));
            Assert.AreEqual(value, supplier.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void SupplierDto_Property_Count()
        {
            var supplier = new SupplierDto();
            Assert.AreEqual(9, supplier.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void SupplierDto_Extension_AsEntity_Null()
        {
            SupplierDto supplier = null;
            var result = supplier.AsEntity();

            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void SupplierDto_Extension_AsEntity_NotNull()
        {
            var supplier = TestHelper.SupplierDto();
            var result = supplier.AsEntity();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Supplier));

            Assert.IsNotNull(result.Organization);
            Assert.IsInstanceOfType(result.Organization, typeof(Organization));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(supplier.Name, result.Name);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(supplier.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(supplier.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

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