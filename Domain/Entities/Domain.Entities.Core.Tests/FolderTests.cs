using Domain.Mappings.Core;
using Domain.Models.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Entities.Core.Tests
{
    [TestClass]
    public class FolderTests
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
        public void Folder_Property_Name()
        {
            // Arrange
            var folder = new Folder();
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
        public void Folder_Property_ParentFolderID()
        {
            // Arrange
            var folder = new Folder();
            var value = new Guid();

            // Act
            folder.ParentFolderID = value;

            // Assert
            Assert.IsNotNull(folder.ParentFolderID);
            Assert.IsInstanceOfType(folder.ParentFolderID, typeof(Guid));
            Assert.AreEqual(value, folder.ParentFolderID);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Folder_Property_Created()
        {
            // Arrange
            var folder = new Folder();
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
        public void Folder_Property_CreatedBy()
        {
            // Arrange
            var folder = new Folder();
            var value = TestHelper.User();

            // Act
            folder.CreatedBy = value;

            // Assert
            Assert.IsNotNull(folder.CreatedBy);
            Assert.IsInstanceOfType(folder.CreatedBy, typeof(User));
            Assert.AreEqual(value, folder.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Folder_Property_Modified()
        {
            // Arrange
            var folder = new Folder();
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
        public void Folder_Property_ModifiedBy()
        {
            // Arrange
            var folder = new Folder();
            var value = TestHelper.User(); ;

            // Act
            folder.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(folder.ModifiedBy);
            Assert.IsInstanceOfType(folder.ModifiedBy, typeof(User));
            Assert.AreEqual(value, folder.ModifiedBy);
        }
        
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void Folder_Property_IsDeleted()
        {
            // Arrange
            var folder = new Folder();
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
        [TestCategory("Entities - Extensions")]
        public void Folder_Extension_AsDTO_Null()
        {
            // Arrange
            Folder folder = null;

            // Act
            var result = folder.AsDto();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void Folder_Extension_AsDTO_NotNull()
        {
            // Arrange
            var folder = TestHelper.Folder();

            // Act
            var result = folder.AsDto();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FolderDto));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(folder.Name, result.Name);

            Assert.IsNotNull(result.ParentFolderID);
            Assert.IsInstanceOfType(result.ParentFolderID, typeof(Guid));
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