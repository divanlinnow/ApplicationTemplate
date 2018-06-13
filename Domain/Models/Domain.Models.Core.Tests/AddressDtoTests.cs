using Domain.Entities.Core;
using Domain.Enums.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class AddressDtoTests
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
        public void AddressDto_Property_Type()
        {
            // Arrange
            var address = new AddressDto();
            var value = AddressType.Other;

            // Act
            address.Type = value;

            // Assert
            Assert.IsNotNull(address.Type);
            Assert.IsInstanceOfType(address.Type, typeof(AddressType));
            Assert.AreEqual(value, address.Type);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_AddressLine1()
        {
            // Arrange
            var address = new AddressDto();
            var value = "Test Address Line 1";

            // Act
            address.AddressLine1 = value;

            // Assert
            Assert.IsNotNull(address.AddressLine1);
            Assert.IsInstanceOfType(address.AddressLine1, typeof(string));
            Assert.AreEqual(value, address.AddressLine1);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_AddressLine2()
        {
            // Arrange
            var address = new AddressDto();
            var value = "Test Address Line 2";

            // Act
            address.AddressLine2 = value;

            // Assert
            Assert.IsNotNull(address.AddressLine2);
            Assert.IsInstanceOfType(address.AddressLine2, typeof(string));
            Assert.AreEqual(value, address.AddressLine2);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_AddressLine3()
        {
            // Arrange
            var address = new AddressDto();
            var value = "Test Address Line 3";

            // Act
            address.AddressLine3 = value;

            // Assert
            Assert.IsNotNull(address.AddressLine3);
            Assert.IsInstanceOfType(address.AddressLine3, typeof(string));
            Assert.AreEqual(value, address.AddressLine3);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_Suburb()
        {
            // Arrange
            var address = new AddressDto();
            var value = "Test Suburb";

            // Act
            address.Suburb = value;

            // Assert
            Assert.IsNotNull(address.Suburb);
            Assert.IsInstanceOfType(address.Suburb, typeof(string));
            Assert.AreEqual(value, address.Suburb);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_City()
        {
            // Arrange
            var address = new AddressDto();
            var value = TestHelper.CityDto();

            // Act
            address.City = value;

            // Assert
            Assert.IsNotNull(address.City);
            Assert.IsInstanceOfType(address.City, typeof(CityDto));
            Assert.AreEqual(value, address.City);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_Province()
        {
            // Arrange
            var address = new AddressDto();
            var value = TestHelper.ProvinceDto();

            // Act
            address.Province = value;

            // Assert
            Assert.IsNotNull(address.Province);
            Assert.IsInstanceOfType(address.Province, typeof(ProvinceDto));
            Assert.AreEqual(value, address.Province);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_Country()
        {
            // Arrange
            var address = new AddressDto();
            var value = TestHelper.CountryDto();

            // Act
            address.Country = value;

            // Assert
            Assert.IsNotNull(address.Country);
            Assert.IsInstanceOfType(address.Country, typeof(CountryDto));
            Assert.AreEqual(value, address.Country);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_PostalCode()
        {
            // Arrange
            var address = new AddressDto();
            var value = "ABC123";

            // Act
            address.PostalCode = value;

            // Assert
            Assert.IsNotNull(address.PostalCode);
            Assert.IsInstanceOfType(address.PostalCode, typeof(string));
            Assert.AreEqual(value, address.PostalCode);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_Latitude()
        {
            // Arrange
            var address = new AddressDto();
            var value = 1;

            // Act
            address.Latitude = value;

            // Assert
            Assert.IsNotNull(address.Latitude);
            Assert.IsInstanceOfType(address.Latitude, typeof(decimal));
            Assert.AreEqual(value, address.Latitude);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_Longitude()
        {
            // Arrange
            var address = new AddressDto();
            var value = 1;

            // Act
            address.Longitude = value;

            // Assert
            Assert.IsNotNull(address.Longitude);
            Assert.IsInstanceOfType(address.Longitude, typeof(decimal));
            Assert.AreEqual(value, address.Longitude);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_PriorityOrder()
        {
            // Arrange
            var address = new AddressDto();
            var value = (short)1;

            // Act
            address.PriorityOrder = value;

            // Assert
            Assert.IsNotNull(address.PriorityOrder);
            Assert.IsInstanceOfType(address.PriorityOrder, typeof(short));
            Assert.AreEqual(value, address.PriorityOrder);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_Created()
        {
            // Arrange
            var address = new AddressDto();
            var value = DateTime.Now;

            // Act
            address.Created = value;

            // Assert
            Assert.IsNotNull(address.Created);
            Assert.IsInstanceOfType(address.Created, typeof(DateTime));
            Assert.AreEqual(value, address.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void AddressDto_Property_CreatedBy()
        {
            // Arrange
            var address = new AddressDto();
            var value = TestHelper.UserDto();

            // Act
            address.CreatedBy = value;

            // Assert
            Assert.IsNotNull(address.CreatedBy);
            Assert.IsInstanceOfType(address.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, address.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_Modified()
        {
            // Arrange
            var address = new AddressDto();
            var value = DateTime.Now;

            // Act
            address.Modified = value;

            // Assert
            Assert.IsNotNull(address.Modified);
            Assert.IsInstanceOfType(address.Modified, typeof(DateTime));
            Assert.AreEqual(value, address.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_ModifiedBy()
        {
            // Arrange
            var address = new AddressDto();
            var value = TestHelper.UserDto();

            // Act
            address.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(address.ModifiedBy);
            Assert.IsInstanceOfType(address.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, address.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_IsDeleted()
        {
            // Arrange
            var address = new AddressDto();
            var value = false;

            // Act
            address.IsDeleted = value;

            // Assert
            Assert.IsNotNull(address.IsDeleted);
            Assert.IsInstanceOfType(address.IsDeleted, typeof(bool));
            Assert.AreEqual(value, address.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void AddressDto_Property_Count()
        {
            var address = new AddressDto();
            Assert.AreEqual(18, address.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void AddressDto_Extension_AsEntity_Null()
        {
            // Arrange
            AddressDto address = null;

            // Act
            var result = address.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void AddressDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var address = TestHelper.AddressDto();

            // Act
            var result = address.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Address));

            Assert.IsNotNull(result.Type);
            Assert.IsInstanceOfType(result.Type, typeof(AddressType));
            Assert.AreEqual(address.Type, result.Type);

            Assert.IsNotNull(result.AddressLine1);
            Assert.IsInstanceOfType(result.AddressLine1, typeof(string));
            Assert.AreEqual(address.AddressLine1, result.AddressLine1);

            Assert.IsNotNull(result.AddressLine2);
            Assert.IsInstanceOfType(result.AddressLine2, typeof(string));
            Assert.AreEqual(address.AddressLine2, result.AddressLine2);

            Assert.IsNotNull(result.AddressLine3);
            Assert.IsInstanceOfType(result.AddressLine3, typeof(string));
            Assert.AreEqual(address.AddressLine3, result.AddressLine3);

            Assert.IsNotNull(result.Suburb);
            Assert.IsInstanceOfType(result.Suburb, typeof(string));
            Assert.AreEqual(address.Suburb, result.Suburb);

            Assert.IsNotNull(result.City);
            Assert.IsInstanceOfType(result.City, typeof(City));

            Assert.IsNotNull(result.Province);
            Assert.IsInstanceOfType(result.Province, typeof(Province));

            Assert.IsNotNull(result.Country);
            Assert.IsInstanceOfType(result.Country, typeof(Country));

            Assert.IsNotNull(result.PostalCode);
            Assert.IsInstanceOfType(result.PostalCode, typeof(string));
            Assert.AreEqual(address.PostalCode, result.PostalCode);

            Assert.IsNotNull(result.Latitude);
            Assert.IsInstanceOfType(result.Latitude, typeof(decimal));
            Assert.AreEqual(address.Latitude, result.Latitude);

            Assert.IsNotNull(result.Longitude);
            Assert.IsInstanceOfType(result.Longitude, typeof(decimal));
            Assert.AreEqual(address.Longitude, result.Longitude);

            Assert.IsNotNull(result.PriorityOrder);
            Assert.IsInstanceOfType(result.PriorityOrder, typeof(short));
            Assert.AreEqual(address.PriorityOrder, result.PriorityOrder);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(address.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(address.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(address.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}