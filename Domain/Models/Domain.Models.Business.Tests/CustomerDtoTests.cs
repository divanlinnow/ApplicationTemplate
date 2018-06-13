using Domain.Entities.Business;
using Domain.Entities.Core;
using Domain.Mappings.Business;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models.Business.Tests
{
    [TestClass]
    public class CustomerDtoTests
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
        public void CustomerDto_Property_User()
        {
            // Arrange
            var customer = new CustomerDto();
            var value = Core.Tests.TestHelper.UserDto();

            // Act
            customer.User = value;

            // Assert
            Assert.IsNotNull(customer.User);
            Assert.IsInstanceOfType(customer.User, typeof(UserDto));
            Assert.AreEqual(value, customer.User);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CustomerDto_Property_Orders()
        {
            // Arrange
            var customer = new CustomerDto();
            var value = TestHelper.Orders();

            // Act
            customer.Orders = value;

            // Assert
            Assert.IsNotNull(customer.Orders);
            Assert.IsInstanceOfType(customer.Orders, typeof(List<OrderDto>));
            Assert.AreEqual(value, customer.Orders);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CustomerDto_Property_CreditBlocked()
        {
            // Arrange
            var customer = new CustomerDto();
            var value = false;

            // Act
            customer.CreditBlocked = value;

            // Assert
            Assert.IsNotNull(customer.CreditBlocked);
            Assert.IsInstanceOfType(customer.CreditBlocked, typeof(bool));
            Assert.AreEqual(value, customer.CreditBlocked);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CustomerDto_Property_CreditLimit()
        {
            // Arrange
            var customer = new CustomerDto();
            var value = 100;

            // Act
            customer.CreditLimit = value;

            // Assert
            Assert.IsNotNull(customer.CreditLimit);
            Assert.IsInstanceOfType(customer.CreditLimit, typeof(decimal));
            Assert.AreEqual(value, customer.CreditLimit);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CustomerDto_Property_AllowancePeriod_Days()
        {
            // Arrange
            var customer = new CustomerDto();
            var value = (short)10;

            // Act
            customer.AllowancePeriod_Days = value;

            // Assert
            Assert.IsNotNull(customer.AllowancePeriod_Days);
            Assert.IsInstanceOfType(customer.AllowancePeriod_Days, typeof(short));
            Assert.AreEqual(value, customer.AllowancePeriod_Days);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CustomerDto_Property_AllowancePeriod_Months()
        {
            // Arrange
            var customer = new CustomerDto();
            var value = (short)10;

            // Act
            customer.AllowancePeriod_Months = value;

            // Assert
            Assert.IsNotNull(customer.AllowancePeriod_Months);
            Assert.IsInstanceOfType(customer.AllowancePeriod_Months, typeof(short));
            Assert.AreEqual(value, customer.AllowancePeriod_Months);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CustomerDto_Property_IsPreferredCustomer()
        {
            // Arrange
            var customer = new CustomerDto();
            var value = true;

            // Act
            customer.IsPreferredCustomer = value;

            // Assert
            Assert.IsNotNull(customer.IsPreferredCustomer);
            Assert.IsInstanceOfType(customer.IsPreferredCustomer, typeof(bool));
            Assert.AreEqual(value, customer.IsPreferredCustomer);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void CustomerDto_Property_Count()
        {
            var customer = new CustomerDto();
            Assert.AreEqual(8, customer.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void CustomerDto_Extension_AsEntity_Null()
        {
            // Arrange
            CustomerDto customer = null;

            // Act
            var result = customer.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void CustomerDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var customer = TestHelper.CustomerDto();

            // Act
            var result = customer.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Customer));

            Assert.IsNotNull(result.User);
            Assert.IsInstanceOfType(result.User, typeof(User));

            Assert.IsNotNull(result.Orders);
            Assert.IsInstanceOfType(result.Orders, typeof(List<Order>));

            Assert.IsNotNull(result.CreditBlocked);
            Assert.IsInstanceOfType(result.CreditBlocked, typeof(bool));
            Assert.AreEqual(customer.CreditBlocked, result.CreditBlocked);

            Assert.IsNotNull(result.CreditLimit);
            Assert.IsInstanceOfType(result.CreditLimit, typeof(decimal));
            Assert.AreEqual(customer.CreditLimit, result.CreditLimit);

            Assert.IsNotNull(result.AllowancePeriod_Days);
            Assert.IsInstanceOfType(result.AllowancePeriod_Days, typeof(short));
            Assert.AreEqual(customer.AllowancePeriod_Days, result.AllowancePeriod_Days);

            Assert.IsNotNull(result.AllowancePeriod_Months);
            Assert.IsInstanceOfType(result.AllowancePeriod_Months, typeof(short));
            Assert.AreEqual(customer.AllowancePeriod_Months, result.AllowancePeriod_Months);

            Assert.IsNotNull(result.IsPreferredCustomer);
            Assert.IsInstanceOfType(result.IsPreferredCustomer, typeof(bool));
            Assert.AreEqual(customer.IsPreferredCustomer, result.IsPreferredCustomer);
        }

        #endregion Extensions Tests
    }
}