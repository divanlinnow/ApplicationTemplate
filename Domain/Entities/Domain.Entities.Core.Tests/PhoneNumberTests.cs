using Domain.Enums.Core;
using Domain.Mappings.Core;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Entities.Core.Tests
{
    [TestClass]
    public class PhoneNumberTests
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
        public void PhoneNumber_Property_Type()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            var value = PhoneType.Other;

            // Act
            phoneNumber.Type = value;

            // Assert
            Assert.IsNotNull(phoneNumber.Type);
            Assert.IsInstanceOfType(phoneNumber.Type, typeof(PhoneType));
            Assert.AreEqual(value, phoneNumber.Type);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void PhoneNumber_Property_Number()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            var value = "1234567890";

            // Act
            phoneNumber.Number = value;

            // Assert
            Assert.IsNotNull(phoneNumber.Number);
            Assert.IsInstanceOfType(phoneNumber.Number, typeof(string));
            Assert.AreEqual(value, phoneNumber.Number);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void PhoneNumber_Property_PriorityOrder()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            var value = (short)1;

            // Act
            phoneNumber.PriorityOrder = value;

            // Assert
            Assert.IsNotNull(phoneNumber.PriorityOrder);
            Assert.IsInstanceOfType(phoneNumber.PriorityOrder, typeof(short));
            Assert.AreEqual(value, phoneNumber.PriorityOrder);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void PhoneNumber_Property_Created()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            var value = DateTime.Now;

            // Act
            phoneNumber.Created = value;

            // Assert
            Assert.IsNotNull(phoneNumber.Created);
            Assert.IsInstanceOfType(phoneNumber.Created, typeof(DateTime));
            Assert.AreEqual(value, phoneNumber.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void PhoneNumber_Property_CreatedBy()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            var value = TestHelper.User();

            // Act
            phoneNumber.CreatedBy = value;

            // Assert
            Assert.IsNotNull(phoneNumber.CreatedBy);
            Assert.IsInstanceOfType(phoneNumber.CreatedBy, typeof(User));
            Assert.AreEqual(value, phoneNumber.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void PhoneNumber_Property_Modified()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            var value = DateTime.Now;

            // Act
            phoneNumber.Modified = value;

            // Assert
            Assert.IsNotNull(phoneNumber.Modified);
            Assert.IsInstanceOfType(phoneNumber.Modified, typeof(DateTime));
            Assert.AreEqual(value, phoneNumber.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void PhoneNumber_Property_ModifiedBy()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            var value = TestHelper.User();

            // Act
            phoneNumber.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(phoneNumber.ModifiedBy);
            Assert.IsInstanceOfType(phoneNumber.ModifiedBy, typeof(User));
            Assert.AreEqual(value, phoneNumber.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void PhoneNumber_Property_IsActive()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            var value = false;

            // Act
            phoneNumber.IsActive = value;

            // Assert
            Assert.IsNotNull(phoneNumber.IsActive);
            Assert.IsInstanceOfType(phoneNumber.IsActive, typeof(bool));
            Assert.AreEqual(value, phoneNumber.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void PhoneNumber_Property_IsDeleted()
        {
            // Arrange
            var phoneNumber = new PhoneNumber();
            var value = false;

            // Act
            phoneNumber.IsDeleted = value;

            // Assert
            Assert.IsNotNull(phoneNumber.IsDeleted);
            Assert.IsInstanceOfType(phoneNumber.IsDeleted, typeof(bool));
            Assert.AreEqual(value, phoneNumber.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void PhoneNumber_Property_Count()
        {
            var phoneNumber = new PhoneNumber();
            Assert.AreEqual(10, phoneNumber.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void PhoneNumber_Extension_AsDTO_Null()
        {
            // Arrange
            PhoneNumber phoneNumber = null;

            // Act
            var result = phoneNumber.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void PhoneNumber_Extension_AsDTO_NotNull()
        {
            // Arrange
            var phoneNumber = TestHelper.PhoneNumber();

            // Act
            var result = phoneNumber.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(PhoneNumberDto));

            Assert.IsNotNull(result.Type);
            Assert.IsInstanceOfType(result.Type, typeof(PhoneType));
            Assert.AreEqual(phoneNumber.Type, result.Type);

            Assert.IsNotNull(result.Number);
            Assert.IsInstanceOfType(result.Number, typeof(string));
            Assert.AreEqual(phoneNumber.Number, result.Number);

            Assert.IsNotNull(result.PriorityOrder);
            Assert.IsInstanceOfType(result.PriorityOrder, typeof(short));
            Assert.AreEqual(phoneNumber.PriorityOrder, result.PriorityOrder);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(phoneNumber.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(phoneNumber.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(phoneNumber.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(phoneNumber.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}