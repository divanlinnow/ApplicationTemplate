using Domain.Entities.Core;
using Domain.Enums.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class PhoneNumberDtoTests
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
        public void PhoneNumberDto_Property_Type()
        {
            // Arrange
            var phoneNumber = new PhoneNumberDto();
            var value = PhoneType.Other;

            // Act
            phoneNumber.Type = value;

            // Assert
            Assert.IsNotNull(phoneNumber.Type);
            Assert.IsInstanceOfType(phoneNumber.Type, typeof(PhoneType));
            Assert.AreEqual(value, phoneNumber.Type);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void PhoneNumberDto_Property_Number()
        {
            // Arrange
            var phoneNumber = new PhoneNumberDto();
            var value = "1234567890";

            // Act
            phoneNumber.Number = value;

            // Assert
            Assert.IsNotNull(phoneNumber.Number);
            Assert.IsInstanceOfType(phoneNumber.Number, typeof(string));
            Assert.AreEqual(value, phoneNumber.Number);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void PhoneNumberDto_Property_PriorityOrder()
        {
            // Arrange
            var phoneNumber = new PhoneNumberDto();
            var value = (short)1;

            // Act
            phoneNumber.PriorityOrder = value;

            // Assert
            Assert.IsNotNull(phoneNumber.PriorityOrder);
            Assert.IsInstanceOfType(phoneNumber.PriorityOrder, typeof(short));
            Assert.AreEqual(value, phoneNumber.PriorityOrder);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void PhoneNumberDto_Property_Created()
        {
            // Arrange
            var phoneNumber = new PhoneNumberDto();
            var value = DateTime.Now;

            // Act
            phoneNumber.Created = value;

            // Assert
            Assert.IsNotNull(phoneNumber.Created);
            Assert.IsInstanceOfType(phoneNumber.Created, typeof(DateTime));
            Assert.AreEqual(value, phoneNumber.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void PhoneNumberDto_Property_CreatedBy()
        {
            // Arrange
            var phoneNumber = new PhoneNumberDto();
            var value = TestHelper.UserDto();

            // Act
            phoneNumber.CreatedBy = value;

            // Assert
            Assert.IsNotNull(phoneNumber.CreatedBy);
            Assert.IsInstanceOfType(phoneNumber.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, phoneNumber.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void PhoneNumberDto_Property_Modified()
        {
            // Arrange
            var phoneNumber = new PhoneNumberDto();
            var value = DateTime.Now;

            // Act
            phoneNumber.Modified = value;

            // Assert
            Assert.IsNotNull(phoneNumber.Modified);
            Assert.IsInstanceOfType(phoneNumber.Modified, typeof(DateTime));
            Assert.AreEqual(value, phoneNumber.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void PhoneNumberDto_Property_ModifiedBy()
        {
            // Arrange
            var phoneNumber = new PhoneNumberDto();
            var value = TestHelper.UserDto();

            // Act
            phoneNumber.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(phoneNumber.ModifiedBy);
            Assert.IsInstanceOfType(phoneNumber.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, phoneNumber.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void PhoneNumberDto_Property_IsActive()
        {
            // Arrange
            var phoneNumber = new PhoneNumberDto();
            var value = false;

            // Act
            phoneNumber.IsActive = value;

            // Assert
            Assert.IsNotNull(phoneNumber.IsActive);
            Assert.IsInstanceOfType(phoneNumber.IsActive, typeof(bool));
            Assert.AreEqual(value, phoneNumber.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void PhoneNumberDto_Property_IsDeleted()
        {
            // Arrange
            var phoneNumber = new PhoneNumberDto();
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
        [TestCategory("Models - Properties")]
        public void PhoneNumberDto_Property_Count()
        {
            var phoneNumber = new PhoneNumberDto();
            Assert.AreEqual(10, phoneNumber.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void PhoneNumberDto_Extension_AsEntity_Null()
        {
            // Arrange
            PhoneNumberDto phoneNumber = null;

            // Act
            var result = phoneNumber.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void PhoneNumberDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var phoneNumber = TestHelper.PhoneNumberDto();

            // Act
            var result = phoneNumber.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(PhoneNumber));

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
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(phoneNumber.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

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