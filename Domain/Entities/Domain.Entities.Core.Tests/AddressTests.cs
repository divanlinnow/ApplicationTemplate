using Domain.Enums.Core;
using Domain.Mappings.Core;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Entities.Core.Tests
{
    [TestClass]
    public class AddressTests
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
        public void Address_Property_Type()
        {
            // Arrange
            var address = new Address();
            var value = AddressType.Other;

            // Act
            address.Type = value;

            // Assert
            Assert.IsNotNull(address.Type);
            Assert.IsInstanceOfType(address.Type, typeof(AddressType));
            Assert.AreEqual(value, address.Type);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_AddressLine1()
        {
            // Arrange
            var address = new Address();
            var value = "Test Address Line 1";

            // Act
            address.AddressLine1 = value;

            // Assert
            Assert.IsNotNull(address.AddressLine1);
            Assert.IsInstanceOfType(address.AddressLine1, typeof(string));
            Assert.AreEqual(value, address.AddressLine1);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_AddressLine2()
        {
            // Arrange
            var address = new Address();
            var value = "Test Address Line 2";

            // Act
            address.AddressLine2 = value;

            // Assert
            Assert.IsNotNull(address.AddressLine2);
            Assert.IsInstanceOfType(address.AddressLine2, typeof(string));
            Assert.AreEqual(value, address.AddressLine2);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_AddressLine3()
        {
            // Arrange
            var address = new Address();
            var value = "Test Address Line 3";

            // Act
            address.AddressLine3 = value;

            // Assert
            Assert.IsNotNull(address.AddressLine3);
            Assert.IsInstanceOfType(address.AddressLine3, typeof(string));
            Assert.AreEqual(value, address.AddressLine3);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_Suburb()
        {
            // Arrange
            var address = new Address();
            var value = "Test Suburb";

            // Act
            address.Suburb = value;

            // Assert
            Assert.IsNotNull(address.Suburb);
            Assert.IsInstanceOfType(address.Suburb, typeof(string));
            Assert.AreEqual(value, address.Suburb);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_City()
        {
            // Arrange
            var address = new Address();
            var value = TestHelper.City();

            // Act
            address.City = value;

            // Assert
            Assert.IsNotNull(address.City);
            Assert.IsInstanceOfType(address.City, typeof(City));
            Assert.AreEqual(value, address.City);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_Province()
        {
            // Arrange
            var address = new Address();
            var value = TestHelper.Province();

            // Act
            address.Province = value;

            // Assert
            Assert.IsNotNull(address.Province);
            Assert.IsInstanceOfType(address.Province, typeof(Province));
            Assert.AreEqual(value, address.Province);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_Country()
        {
            // Arrange
            var address = new Address();
            var value = TestHelper.Country();

            // Act
            address.Country = value;

            // Assert
            Assert.IsNotNull(address.Country);
            Assert.IsInstanceOfType(address.Country, typeof(Country));
            Assert.AreEqual(value, address.Country);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_PostalCode()
        {
            // Arrange
            var address = new Address();
            var value = "ABC123";

            // Act
            address.PostalCode = value;

            // Assert
            Assert.IsNotNull(address.PostalCode);
            Assert.IsInstanceOfType(address.PostalCode, typeof(string));
            Assert.AreEqual(value, address.PostalCode);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_Latitude()
        {
            // Arrange
            var address = new Address();
            var value = 1;

            // Act
            address.Latitude = value;

            // Assert
            Assert.IsNotNull(address.Latitude);
            Assert.IsInstanceOfType(address.Latitude, typeof(decimal));
            Assert.AreEqual(value, address.Latitude);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_Longitude()
        {
            // Arrange
            var address = new Address();
            var value = 1;

            // Act
            address.Longitude = value;

            // Assert
            Assert.IsNotNull(address.Longitude);
            Assert.IsInstanceOfType(address.Longitude, typeof(decimal));
            Assert.AreEqual(value, address.Longitude);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_PriorityOrder()
        {
            // Arrange
            var address = new Address();
            var value = (short)1;

            // Act
            address.PriorityOrder = value;

            // Assert
            Assert.IsNotNull(address.PriorityOrder);
            Assert.IsInstanceOfType(address.PriorityOrder, typeof(short));
            Assert.AreEqual(value, address.PriorityOrder);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_Created()
        {
            // Arrange
            var address = new Address();
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
        public void Address_Property_CreatedBy()
        {
            // Arrange
            var address = new Address();
            var value = TestHelper.User();

            // Act
            address.CreatedBy = value;

            // Assert
            Assert.IsNotNull(address.CreatedBy);
            Assert.IsInstanceOfType(address.CreatedBy, typeof(User));
            Assert.AreEqual(value, address.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_Modified()
        {
            // Arrange
            var address = new Address();
            var value = DateTime.Now;

            // Act
            address.Modified = value;

            // Assert
            Assert.IsNotNull(address.Modified);
            Assert.IsInstanceOfType(address.Modified, typeof(DateTime));
            Assert.AreEqual(value, address.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_ModifiedBy()
        {
            // Arrange
            var address = new Address();
            var value = TestHelper.User(); ;

            // Act
            address.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(address.ModifiedBy);
            Assert.IsInstanceOfType(address.ModifiedBy, typeof(User));
            Assert.AreEqual(value, address.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Address_Property_IsDeleted()
        {
            // Arrange
            var address = new Address();
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
        [TestCategory("Entities - Properties")]
        public void Address_Property_Count()
        {
            var address = new Address();
            Assert.AreEqual(18, address.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Address_Extension_AsDTO_Null()
        {
            // Arrange
            Address address = null;

            // Act
            var result = address.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Address_Extension_AsDTO_NotNull()
        {
            // Arrange
            var address = TestHelper.Address();

            // Act
            var result = address.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(AddressDto));

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
            Assert.IsInstanceOfType(result.City, typeof(CityDto));

            Assert.IsNotNull(result.Province);
            Assert.IsInstanceOfType(result.Province, typeof(ProvinceDto));

            Assert.IsNotNull(result.Country);
            Assert.IsInstanceOfType(result.Country, typeof(CountryDto));

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
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(address.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(address.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}