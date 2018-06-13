using Domain.Entities.Core;
using Domain.Enums.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class EmailDtoTests
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
        public void EmailDto_Property_Type()
        {
            // Arrange
            var email = new EmailDto();
            var value = EmailType.Test;

            // Act
            email.Type = value;

            // Assert
            Assert.IsNotNull(email.Type);
            Assert.IsInstanceOfType(email.Type, typeof(EmailType));
            Assert.AreEqual(value, email.Type);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_AccountType()
        {
            // Arrange
            var email = new EmailDto();
            var value = EmailAccountType.IMAP;

            // Act
            email.AccountType = value;

            // Assert
            Assert.IsNotNull(email.AccountType);
            Assert.IsInstanceOfType(email.AccountType, typeof(EmailAccountType));
            Assert.AreEqual(value, email.AccountType);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_EmailAddress()
        {
            // Arrange
            var email = new EmailDto();
            var value = "test@test.com";

            // Act
            email.EmailAddress = value;

            // Assert
            Assert.IsNotNull(email.EmailAddress);
            Assert.IsInstanceOfType(email.EmailAddress, typeof(string));
            Assert.AreEqual(value, email.EmailAddress);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_IncomingMailServer()
        {
            // Arrange
            var email = new EmailDto();
            var value = "imap.test.com";

            // Act
            email.IncomingMailServer = value;

            // Assert
            Assert.IsNotNull(email.IncomingMailServer);
            Assert.IsInstanceOfType(email.IncomingMailServer, typeof(string));
            Assert.AreEqual(value, email.IncomingMailServer);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_OutgoingMailServer()
        {
            // Arrange
            var email = new EmailDto();
            var value = "smtp.test.com";

            // Act
            email.OutgoingMailServer = value;

            // Assert
            Assert.IsNotNull(email.OutgoingMailServer);
            Assert.IsInstanceOfType(email.OutgoingMailServer, typeof(string));
            Assert.AreEqual(value, email.OutgoingMailServer);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_IncomingMailServerPort()
        {
            // Arrange
            var email = new EmailDto();
            var value = 993;

            // Act
            email.IncomingMailServerPort = value;

            // Assert
            Assert.IsNotNull(email.IncomingMailServerPort);
            Assert.IsInstanceOfType(email.IncomingMailServerPort, typeof(int));
            Assert.AreEqual(value, email.IncomingMailServerPort);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_OutgoingMailServerPort()
        {
            // Arrange
            var email = new EmailDto();
            var value = 465;

            // Act
            email.OutgoingMailServerPort = value;

            // Assert
            Assert.IsNotNull(email.OutgoingMailServerPort);
            Assert.IsInstanceOfType(email.OutgoingMailServerPort, typeof(int));
            Assert.AreEqual(value, email.OutgoingMailServerPort);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_IncomingServerUseSSL()
        {
            // Arrange
            var email = new EmailDto();
            var value = true;

            // Act
            email.IncomingServerUseSSL = value;

            // Assert
            Assert.IsNotNull(email.IncomingServerUseSSL);
            Assert.IsInstanceOfType(email.IncomingServerUseSSL, typeof(bool));
            Assert.AreEqual(value, email.IncomingServerUseSSL);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_OutgoingServerUseSSL()
        {
            // Arrange
            var email = new EmailDto();
            var value = true;

            // Act
            email.OutgoingServerUseSSL = value;

            // Assert
            Assert.IsNotNull(email.OutgoingServerUseSSL);
            Assert.IsInstanceOfType(email.OutgoingServerUseSSL, typeof(bool));
            Assert.AreEqual(value, email.OutgoingServerUseSSL);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_PriorityOrder()
        {
            // Arrange
            var email = new EmailDto();
            var value = (short)1;

            // Act
            email.PriorityOrder = value;

            // Assert
            Assert.IsNotNull(email.PriorityOrder);
            Assert.IsInstanceOfType(email.PriorityOrder, typeof(short));
            Assert.AreEqual(value, email.PriorityOrder);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_Created()
        {
            // Arrange
            var email = new EmailDto();
            var value = DateTime.Now;

            // Act
            email.Created = value;

            // Assert
            Assert.IsNotNull(email.Created);
            Assert.IsInstanceOfType(email.Created, typeof(DateTime));
            Assert.AreEqual(value, email.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_CreatedBy()
        {
            // Arrange
            var email = new EmailDto();
            var value = TestHelper.UserDto();

            // Act
            email.CreatedBy = value;

            // Assert
            Assert.IsNotNull(email.CreatedBy);
            Assert.IsInstanceOfType(email.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, email.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_Modified()
        {
            // Arrange
            var email = new EmailDto();
            var value = DateTime.Now;

            // Act
            email.Modified = value;

            // Assert
            Assert.IsNotNull(email.Modified);
            Assert.IsInstanceOfType(email.Modified, typeof(DateTime));
            Assert.AreEqual(value, email.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_ModifiedBy()
        {
            // Arrange
            var email = new EmailDto();
            var value = TestHelper.UserDto();

            // Act
            email.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(email.ModifiedBy);
            Assert.IsInstanceOfType(email.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, email.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_IsDeleted()
        {
            // Arrange
            var email = new EmailDto();
            var value = false;

            // Act
            email.IsDeleted = value;

            // Assert
            Assert.IsNotNull(email.IsDeleted);
            Assert.IsInstanceOfType(email.IsDeleted, typeof(bool));
            Assert.AreEqual(value, email.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Models - Properties")]
        public void EmailDto_Property_Count()
        {
            var email = new EmailDto();
            Assert.AreEqual(16, email.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void EmailDto_Extension_AsEntity_Null()
        {
            // Arrange
            EmailDto email = null;

            // Act
            var result = email.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void EmailDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var email = TestHelper.EmailDto();

            // Act
            var result = email.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Email));

            Assert.IsNotNull(result.Type);
            Assert.IsInstanceOfType(result.Type, typeof(EmailType));
            Assert.AreEqual(email.Type, result.Type);

            Assert.IsNotNull(result.AccountType);
            Assert.IsInstanceOfType(result.AccountType, typeof(EmailAccountType));
            Assert.AreEqual(email.AccountType, result.AccountType);

            Assert.IsNotNull(result.EmailAddress);
            Assert.IsInstanceOfType(result.EmailAddress, typeof(string));
            Assert.AreEqual(email.EmailAddress, result.EmailAddress);

            Assert.IsNotNull(result.IncomingMailServer);
            Assert.IsInstanceOfType(result.IncomingMailServer, typeof(string));
            Assert.AreEqual(email.IncomingMailServer, result.IncomingMailServer);

            Assert.IsNotNull(result.OutgoingMailServer);
            Assert.IsInstanceOfType(result.OutgoingMailServer, typeof(string));
            Assert.AreEqual(email.OutgoingMailServer, result.OutgoingMailServer);

            Assert.IsNotNull(result.IncomingMailServerPort);
            Assert.IsInstanceOfType(result.IncomingMailServerPort, typeof(int));
            Assert.AreEqual(email.IncomingMailServerPort, result.IncomingMailServerPort);

            Assert.IsNotNull(result.OutgoingMailServerPort);
            Assert.IsInstanceOfType(result.OutgoingMailServerPort, typeof(int));
            Assert.AreEqual(email.OutgoingMailServerPort, result.OutgoingMailServerPort);

            Assert.IsNotNull(result.IncomingServerUseSSL);
            Assert.IsInstanceOfType(result.IncomingServerUseSSL, typeof(bool));
            Assert.AreEqual(email.IncomingServerUseSSL, result.IncomingServerUseSSL);

            Assert.IsNotNull(result.OutgoingServerUseSSL);
            Assert.IsInstanceOfType(result.OutgoingServerUseSSL, typeof(bool));
            Assert.AreEqual(email.OutgoingServerUseSSL, result.OutgoingServerUseSSL);

            Assert.IsNotNull(result.PriorityOrder);
            Assert.IsInstanceOfType(result.PriorityOrder, typeof(short));
            Assert.AreEqual(email.PriorityOrder, result.PriorityOrder);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(email.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(email.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(email.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}