using Domain.Entities.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class NotificationTemplateDtoTests
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
        public void NotificationTemplateDto_Property_Name()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplateDto();
            var value = "Test Notification Template";

            // Act
            notificationTemplate.Name = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.Name);
            Assert.IsInstanceOfType(notificationTemplate.Name, typeof(string));
            Assert.AreEqual(value, notificationTemplate.Name);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void NotificationTemplateDto_Property_SubjectHeader()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplateDto();
            var value = "Test Subject";

            // Act
            notificationTemplate.SubjectHeader = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.SubjectHeader);
            Assert.IsInstanceOfType(notificationTemplate.SubjectHeader, typeof(string));
            Assert.AreEqual(value, notificationTemplate.SubjectHeader);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void NotificationTemplateDto_Property_Body()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplateDto();
            var value = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras ultricies ligula sed magna dictum porta. Vestibulum ac diam sit amet quam vehicula elementum sed sit amet dui.";

            // Act
            notificationTemplate.Body = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.Body);
            Assert.IsInstanceOfType(notificationTemplate.Body, typeof(string));
            Assert.AreEqual(value, notificationTemplate.Body);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void NotificationTemplateDto_Property_Created()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplateDto();
            var value = DateTime.Now;

            // Act
            notificationTemplate.Created = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.Created);
            Assert.IsInstanceOfType(notificationTemplate.Created, typeof(DateTime));
            Assert.AreEqual(value, notificationTemplate.Created);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void NotificationTemplateDto_Property_CreatedBy()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplateDto();
            var value = TestHelper.UserDto();

            // Act
            notificationTemplate.CreatedBy = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.CreatedBy);
            Assert.IsInstanceOfType(notificationTemplate.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, notificationTemplate.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void NotificationTemplateDto_Property_Modified()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplateDto();
            var value = DateTime.Now;

            // Act
            notificationTemplate.Modified = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.Modified);
            Assert.IsInstanceOfType(notificationTemplate.Modified, typeof(DateTime));
            Assert.AreEqual(value, notificationTemplate.Modified);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void NotificationTemplateDto_Property_ModifiedBy()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplateDto();
            var value = TestHelper.UserDto();

            // Act
            notificationTemplate.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.ModifiedBy);
            Assert.IsInstanceOfType(notificationTemplate.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, notificationTemplate.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void NotificationTemplateDto_Property_IsActive()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplateDto();
            var value = false;

            // Act
            notificationTemplate.IsActive = value;

            // Assert
            Assert.IsNotNull(notificationTemplate.IsActive);
            Assert.IsInstanceOfType(notificationTemplate.IsActive, typeof(bool));
            Assert.AreEqual(value, notificationTemplate.IsActive);
        }

        [TestMethod]
        [TestCategory("Models - Properties")]
        public void NotificationTemplateDto_Property_IsDeleted()
        {
            // Arrange
            var notificationTemplate = new NotificationTemplateDto();
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
        [TestCategory("Models - Properties")]
        public void NotificationTemplateDto_Property_Count()
        {
            var notificationTemplate = new NotificationTemplateDto();
            Assert.AreEqual(10, notificationTemplate.GetType().GetProperties().Count());
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void NotificationTemplateDto_Extension_AsEntity_Null()
        {
            // Arrange
            NotificationTemplateDto notificationTemplate = null;

            // Act
            var result = notificationTemplate.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void NotificationTemplateDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var notificationTemplate = TestHelper.NotificationTemplateDto();

            // Act
            var result = notificationTemplate.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotificationTemplate));

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
            Assert.IsInstanceOfType(result.CreatedBy, typeof(User));

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(notificationTemplate.Modified, result.Modified);

            Assert.IsNotNull(result.ModifiedBy);
            Assert.IsInstanceOfType(result.ModifiedBy, typeof(User));

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