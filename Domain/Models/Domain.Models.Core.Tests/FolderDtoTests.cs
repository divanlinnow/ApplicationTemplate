using Domain.Entities.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class FolderDtoTests
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
        public void FolderDto_Property_Name()
        {
            // Arrange
            var folder = new FolderDto();
            var value = "Test Folder";

            // Act
            folder.Name = value;

            // Assert
            Assert.IsNotNull(folder.Name);
            Assert.IsInstanceOfType(folder.Name, typeof(string));
            Assert.AreEqual(value, folder.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FolderDto_Property_ParentFolderID()
        {
            // Arrange
            var folder = new FolderDto();
            var value = 99;

            // Act
            folder.ParentFolderID = value;

            // Assert
            Assert.IsNotNull(folder.ParentFolderID);
            Assert.IsInstanceOfType(folder.ParentFolderID, typeof(int));
            Assert.AreEqual(value, folder.ParentFolderID);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FolderDto_Property_Created()
        {
            // Arrange
            var folder = new FolderDto();
            var value = DateTime.Now;

            // Act
            folder.Created = value;

            // Assert
            Assert.IsNotNull(folder.Created);
            Assert.IsInstanceOfType(folder.Created, typeof(DateTime));
            Assert.AreEqual(value, folder.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FolderDto_Property_CreatedBy()
        {
            // Arrange
            var folder = new FolderDto();
            var value = TestHelper.UserDto();

            // Act
            folder.CreatedBy = value;

            // Assert
            Assert.IsNotNull(folder.CreatedBy);
            Assert.IsInstanceOfType(folder.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, folder.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FolderDto_Property_Modified()
        {
            // Arrange
            var folder = new FolderDto();
            var value = DateTime.Now;

            // Act
            folder.Modified = value;

            // Assert
            Assert.IsNotNull(folder.Modified);
            Assert.IsInstanceOfType(folder.Modified, typeof(DateTime));
            Assert.AreEqual(value, folder.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FolderDto_Property_ModifiedBy()
        {
            // Arrange
            var folder = new FolderDto();
            var value = TestHelper.UserDto(); ;

            // Act
            folder.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(folder.ModifiedBy);
            Assert.IsInstanceOfType(folder.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, folder.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FolderDto_Property_IsDeleted()
        {
            // Arrange
            var folder = new FolderDto();
            var value = false;

            // Act
            folder.IsDeleted = value;

            // Assert
            Assert.IsNotNull(folder.IsDeleted);
            Assert.IsInstanceOfType(folder.IsDeleted, typeof(bool));
            Assert.AreEqual(value, folder.IsDeleted);
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void FolderDto_Extension_AsEntity_Null()
        {
            // Arrange
            FolderDto folder = null;

            // Act
            var result = folder.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Models - Extensions")]
        public void FolderDto_Extension_AsEntity_NotNull()
        {
            // Arrange
            var folder = TestHelper.FolderDto();

            // Act
            var result = folder.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Folder));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(folder.Name, result.Name);

            Assert.IsNotNull(result.ParentFolderID);
            Assert.IsInstanceOfType(result.ParentFolderID, typeof(int));
            Assert.AreEqual(folder.ParentFolderID, result.ParentFolderID);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(folder.Created, result.Created);

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(folder.Modified, result.Modified);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(folder.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}