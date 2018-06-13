using Domain.Mappings.Core;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Entities.Core.Tests
{
    [TestClass]
    public class NotificationTemplateTests
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
        public void NotificationTemplate_Property_Name()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplate();
            var value = "Test Notification Template";

            // Act
            notificationTemplate.Name = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.Name);
            Assert.IsInstanceOfType(notificationTemplate.Name, typeof(string));
            Assert.AreEqual(value, notificationTemplate.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void NotificationTemplate_Property_SubjectHeader()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplate();
            var value = "Test Subject";

            // Act
            notificationTemplate.SubjectHeader = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.SubjectHeader);
            Assert.IsInstanceOfType(notificationTemplate.SubjectHeader, typeof(string));
            Assert.AreEqual(value, notificationTemplate.SubjectHeader);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void NotificationTemplate_Property_Body()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplate();
            var value = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ultricies ligula sed magna dictum porta. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.";

            // Act
            notificationTemplate.Body = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.Body);
            Assert.IsInstanceOfType(notificationTemplate.Body, typeof(string));
            Assert.AreEqual(value, notificationTemplate.Body);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void NotificationTemplate_Property_Created()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplate();
            var value = DateTime.Now;

            // Act
            notificationTemplate.Created = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.Created);
            Assert.IsInstanceOfType(notificationTemplate.Created, typeof(DateTime));
            Assert.AreEqual(value, notificationTemplate.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void NotificationTemplate_Property_CreatedBy()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplate();
            var value = TestHelper.User();

            // Act
            notificationTemplate.CreatedBy = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.CreatedBy);
            Assert.IsInstanceOfType(notificationTemplate.CreatedBy, typeof(User));
            Assert.AreEqual(value, notificationTemplate.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void NotificationTemplate_Property_Modified()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplate();
            var value = DateTime.Now;

            // Act
            notificationTemplate.Modified = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.Modified);
            Assert.IsInstanceOfType(notificationTemplate.Modified, typeof(DateTime));
            Assert.AreEqual(value, notificationTemplate.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void NotificationTemplate_Property_ModifiedBy()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplate();
            var value = TestHelper.User();

            // Act
            notificationTemplate.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.ModifiedBy);
            Assert.IsInstanceOfType(notificationTemplate.ModifiedBy, typeof(User));
            Assert.AreEqual(value, notificationTemplate.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void NotificationTemplate_Property_IsActive()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplate();
            var value = false;

            // Act
            notificationTemplate.IsActive = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.IsActive);
            Assert.IsInstanceOfType(notificationTemplate.IsActive, typeof(bool));
            Assert.AreEqual(value, notificationTemplate.IsActive);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void NotificationTemplate_Property_IsDeleted()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplate();
            var value = false;

            // Act
            notificationTemplate.IsDeleted = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.IsDeleted);
            Assert.IsInstanceOfType(notificationTemplate.IsDeleted, typeof(bool));
            Assert.AreEqual(value, notificationTemplate.IsDeleted);
        }

        // Unit test to check if properties have been added or removed from the class.
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void NotificationTemplate_Property_Count()
        {
            var notificationTemplate = new NotificationTemplate();
            Assert.AreEqual(10, notificationTemplate.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void NotificationTemplate_Extension_AsDTO_Null()
        {
            // Arrange
            NotificationTemplate notificationTemplate = null;

            // Act
            var result = notificationTemplate.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void NotificationTemplate_Extension_AsDTO_NotNull()
        {
            // Arrange
            var notificationTemplate = TestHelper.NotificationTemplate();

            // Act
            var result = notificationTemplate.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotificationTemplateDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(notificationTemplate.Name, result.Name);

            Assert.IsNotNull(result.SubjectHeader);
            Assert.IsInstanceOfType(result.SubjectHeader, typeof(string));
            Assert.AreEqual(notificationTemplate.SubjectHeader, result.SubjectHeader);

            Assert.IsNotNull(result.Body);
            Assert.IsInstanceOfType(result.Body, typeof(string));
            Assert.AreEqual(notificationTemplate.Body, result.Body);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(notificationTemplate.Created, result.Created);

            Assert.IsNotNull(result.CreatedBy);
            Assert.IsInstanceOfType(result.CreatedBy, typeof(UserDto));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(notificationTemplate.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(UserDto));

            Assert.IsNotNull(result.IsActive);
            Assert.IsInstanceOfType(result.IsActive, typeof(bool));
            Assert.AreEqual(notificationTemplate.IsActive, result.IsActive);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(notificationTemplate.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}