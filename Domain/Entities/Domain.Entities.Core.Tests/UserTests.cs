using Domain.Enums.Core;
using Domain.Mappings.Core;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Entities.Core.Tests
{
    [TestClass]
    public class UserTests
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
        public void User_Property_Prefix()
        {
            // Arrange
            var user = new User();
            var value = Prefix.Mr;

            // Act
            user.Prefix = value;

            // Assert
            Assert.IsNotNull(user.Prefix);
            Assert.IsInstanceOfType(user.Prefix, typeof(Prefix));
            Assert.AreEqual(value, user.Prefix);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_FirstName()
        {
            // Arrange
            var user = new User();
            var value = "Tester";

            // Act
            user.FirstName = value;

            // Assert
            Assert.IsNotNull(user.FirstName);
            Assert.IsInstanceOfType(user.FirstName, typeof(string));
            Assert.AreEqual(value, user.FirstName);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_LastName()
        {
            // Arrange
            var user = new User();
            var value = "McTester";

            // Act
            user.LastName = value;

            // Assert
            Assert.IsNotNull(user.LastName);
            Assert.IsInstanceOfType(user.LastName, typeof(string));
            Assert.AreEqual(value, user.LastName);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Suffix()
        {
            // Arrange
            var user = new User();
            var value = Suffix.Jr;

            // Act
            user.Suffix = value;

            // Assert
            Assert.IsNotNull(user.Suffix);
            Assert.IsInstanceOfType(user.Suffix, typeof(Suffix));
            Assert.AreEqual(value, user.Suffix);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_UserName()
        {
            // Arrange
            var user = new User();
            var value = "Tester";

            // Act
            user.UserName = value;

            // Assert
            Assert.IsNotNull(user.UserName);
            Assert.IsInstanceOfType(user.UserName, typeof(string));
            Assert.AreEqual(value, user.UserName);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Password()
        {
            // Arrange
            var user = new User();
            var value = "P@ssw0rd123";

            // Act
            user.Password = value;

            // Assert
            Assert.IsNotNull(user.Password);
            Assert.IsInstanceOfType(user.Password, typeof(string));
            Assert.AreEqual(value, user.Password);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Salt()
        {
            // Arrange
            var user = new User();
            var value = "P@ssw0rdS@lt123";

            // Act
            user.Salt = value;

            // Assert
            Assert.IsNotNull(user.Salt);
            Assert.IsInstanceOfType(user.Salt, typeof(string));
            Assert.AreEqual(value, user.Salt);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Type()
        {
            // Arrange
            var user = new User();
            var value = UserType.System_Administrator;

            // Act
            user.Type = value;

            // Assert
            Assert.IsNotNull(user.Type);
            Assert.IsInstanceOfType(user.Type, typeof(UserType));
            Assert.AreEqual(value, user.Type);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Status()
        {
            // Arrange
            var user = new User();
            var value = UserStatus.Online;

            // Act
            user.Status = value;

            // Assert
            Assert.IsNotNull(user.Status);
            Assert.IsInstanceOfType(user.Status, typeof(UserStatus));
            Assert.AreEqual(value, user.Status);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Gender()
        {
            // Arrange
            var user = new User();
            var value = GenderType.Male;

            // Act
            user.Gender = value;

            // Assert
            Assert.IsNotNull(user.Gender);
            Assert.IsInstanceOfType(user.Gender, typeof(GenderType));
            Assert.AreEqual(value, user.Gender);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Language()
        {
            // Arrange
            var user = new User();
            var value = TestHelper.Language();

            // Act
            user.Language = value;

            // Assert
            Assert.IsNotNull(user.Language);
            Assert.IsInstanceOfType(user.Language, typeof(Language));
            Assert.AreEqual(value, user.Language);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Roles()
        {
            // Arrange
            var user = new User();
            var value = TestHelper.Roles();

            // Act
            user.Roles = value;

            // Assert
            Assert.IsNotNull(user.Roles);
            Assert.IsInstanceOfType(user.Roles, typeof(List<Role>));
            Assert.AreEqual(value, user.Roles);
            Assert.AreEqual(2, user.Roles.Count);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Emails()
        {
            // Arrange
            var user = new User();
            var value = TestHelper.Emails();

            // Act
            user.Emails = value;

            // Assert
            Assert.IsNotNull(user.Emails);
            Assert.IsInstanceOfType(user.Emails, typeof(List<Email>));
            Assert.AreEqual(value, user.Emails);
            Assert.AreEqual(2, user.Emails.Count);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_PhoneNumbers()
        {
            // Arrange
            var user = new User();
            var value = TestHelper.PhoneNumbers();

            // Act
            user.PhoneNumbers = value;

            // Assert
            Assert.IsNotNull(user.PhoneNumbers);
            Assert.IsInstanceOfType(user.PhoneNumbers, typeof(List<PhoneNumber>));
            Assert.AreEqual(value, user.PhoneNumbers);
            Assert.AreEqual(2, user.PhoneNumbers.Count);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Addresses()
        {
            // Arrange
            var user = new User();
            var value = TestHelper.Addresses();

            // Act
            user.Addresses = value;

            // Assert
            Assert.IsNotNull(user.Addresses);
            Assert.IsInstanceOfType(user.Addresses, typeof(List<Address>));
            Assert.AreEqual(value, user.Addresses);
            Assert.AreEqual(2, user.Addresses.Count);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_BloodType()
        {
            // Arrange
            var user = new User();
            var value = BloodType.O_Positive;

            // Act
            user.BloodType = value;

            // Assert
            Assert.IsNotNull(user.BloodType);
            Assert.IsInstanceOfType(user.BloodType, typeof(BloodType));
            Assert.AreEqual(value, user.BloodType);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_FoodPreferenceType()
        {
            // Arrange
            var user = new User();
            var value = FoodPreferenceType.Dairy_Free;

            // Act
            user.FoodPreferenceType = value;

            // Assert
            Assert.IsNotNull(user.FoodPreferenceType);
            Assert.IsInstanceOfType(user.FoodPreferenceType, typeof(FoodPreferenceType));
            Assert.AreEqual(value, user.FoodPreferenceType);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_DateOfBirth()
        {
            // Arrange
            var user = new User();
            var value = DateTime.Now;

            // Act
            user.DateOfBirth = value;

            // Assert
            Assert.IsNotNull(user.DateOfBirth);
            Assert.IsInstanceOfType(user.DateOfBirth, typeof(DateTime));
            Assert.AreEqual(value, user.DateOfBirth);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Created()
        {
            // Arrange
            var user = new User();
            var value = DateTime.Now;

            // Act
            user.Created = value;

            // Assert
            Assert.IsNotNull(user.Created);
            Assert.IsInstanceOfType(user.Created, typeof(DateTime));
            Assert.AreEqual(value, user.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_CreatedBy()
        {
            // Arrange
            var user = new User();
            var value = TestHelper.User();

            // Act
            user.CreatedBy = value;

            // Assert
            Assert.IsNotNull(user.CreatedBy);
            Assert.IsInstanceOfType(user.CreatedBy, typeof(User));
            Assert.AreEqual(value, user.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Modified()
        {
            // Arrange
            var user = new User();
            var value = DateTime.Now;

            // Act
            user.Modified = value;

            // Assert
            Assert.IsNotNull(user.Modified);
            Assert.IsInstanceOfType(user.Modified, typeof(DateTime));
            Assert.AreEqual(value, user.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_ModifiedBy()
        {
            // Arrange
            var user = new User();
            var value = TestHelper.User(); ;

            // Act
            user.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(user.ModifiedBy);
            Assert.IsInstanceOfType(user.ModifiedBy, typeof(User));
            Assert.AreEqual(value, user.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_IsConfirmed()
        {
            // Arrange
            var user = new User();
            var value = true;

            // Act
            user.IsConfirmed = value;

            // Assert
            Assert.IsNotNull(user.IsConfirmed);
            Assert.IsInstanceOfType(user.IsConfirmed, typeof(bool));
            Assert.AreEqual(value, user.IsConfirmed);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_IsDeleted()
        {
            // Arrange
            var user = new User();
            var value = false;

            // Act
            user.IsDeleted = value;

            // Assert
            Assert.IsNotNull(user.IsDeleted);
            Assert.IsInstanceOfType(user.IsDeleted, typeof(bool));
            Assert.AreEqual(value, user.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void User_Property_Count()
        {
            var user = new User();
            Assert.AreEqual(25, user.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void User_Extension_AsDTO_Null()
        {
            // Arrange
            User user = null;

            // Act
            var result = user.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void User_Extension_AsDTO_NotNull()
        {
            // Arrange
            var user = TestHelper.User();

            // Act
            var result = user.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(UserDto));

            Assert.IsNotNull(result.Prefix);
            Assert.IsInstanceOfType(result.Prefix, typeof(Prefix));
            Assert.AreEqual(user.Prefix, result.Prefix);

            Assert.IsNotNull(result.FirstName);
            Assert.IsInstanceOfType(result.FirstName, typeof(string));
            Assert.AreEqual(user.FirstName, result.FirstName);

            Assert.IsNotNull(result.LastName);
            Assert.IsInstanceOfType(result.LastName, typeof(string));
            Assert.AreEqual(user.LastName, result.LastName);

            Assert.IsNotNull(result.Suffix);
            Assert.IsInstanceOfType(result.Suffix, typeof(Suffix));
            Assert.AreEqual(user.Suffix, result.Suffix);

            Assert.IsNotNull(result.UserName);
            Assert.IsInstanceOfType(result.UserName, typeof(string));
            Assert.AreEqual(user.UserName, result.UserName);

            Assert.IsNotNull(result.Password);
            Assert.IsInstanceOfType(result.Password, typeof(string));
            Assert.AreEqual(user.Password, result.Password);

            Assert.IsNotNull(result.Salt);
            Assert.IsInstanceOfType(result.Salt, typeof(string));
            Assert.AreEqual(user.Salt, result.Salt);

            Assert.IsNotNull(result.Type);
            Assert.IsInstanceOfType(result.Type, typeof(UserType));
            Assert.AreEqual(user.Type, result.Type);

            Assert.IsNotNull(result.Status);
            Assert.IsInstanceOfType(result.Status, typeof(UserStatus));
            Assert.AreEqual(user.Status, result.Status);

            Assert.IsNotNull(result.Gender);
            Assert.IsInstanceOfType(result.Gender, typeof(GenderType));
            Assert.AreEqual(user.Gender, result.Gender);

            Assert.IsNotNull(result.Language);
            Assert.IsInstanceOfType(result.Language, typeof(LanguageDto));

            Assert.IsNotNull(result.Roles);
            Assert.IsInstanceOfType(result.Roles, typeof(List<RoleDto>));

            Assert.IsNotNull(result.Emails);
            Assert.IsInstanceOfType(result.Emails, typeof(List<EmailDto>));

            Assert.IsNotNull(result.PhoneNumbers);
            Assert.IsInstanceOfType(result.PhoneNumbers, typeof(List<PhoneNumberDto>));

            Assert.IsNotNull(result.Addresses);
            Assert.IsInstanceOfType(result.Addresses, typeof(List<AddressDto>));

            Assert.IsNotNull(result.BloodType);
            Assert.IsInstanceOfType(result.BloodType, typeof(BloodType));
            Assert.AreEqual(user.BloodType, result.BloodType);

            Assert.IsNotNull(result.FoodPreferenceType);
            Assert.IsInstanceOfType(result.FoodPreferenceType, typeof(FoodPreferenceType));
            Assert.AreEqual(user.FoodPreferenceType, result.FoodPreferenceType);

            Assert.IsNotNull(result.DateOfBirth);
            Assert.IsInstanceOfType(result.DateOfBirth, typeof(DateTime));
            Assert.AreEqual(user.DateOfBirth, result.DateOfBirth);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(user.Created, result.Created);

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(user.Modified, result.Modified);

            Assert.IsNotNull(result.IsConfirmed);
            Assert.IsInstanceOfType(result.IsConfirmed, typeof(bool));
            Assert.AreEqual(user.IsConfirmed, result.IsConfirmed);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(user.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}