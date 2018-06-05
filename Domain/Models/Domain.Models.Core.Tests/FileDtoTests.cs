using Domain.Entities.Core;
using Domain.Mappings.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Domain.Models.Core.Tests
{
    [TestClass]
    public class FileDtoTests
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
        public void FileDto_Property_Name()
        {
            // Arrange
            var file = new FileDto();
            var value = "Test Folder";

            // Act
            file.Name = value;

            // Assert
            Assert.IsNotNull(file.Name);
            Assert.IsInstanceOfType(file.Name, typeof(string));
            Assert.AreEqual(value, file.Name);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FileDto_Property_Extension()
        {
            // Arrange
            var file = new FileDto();
            var value = ".txt";

            // Act
            file.Extension = value;

            // Assert
            Assert.IsNotNull(file.Extension);
            Assert.IsInstanceOfType(file.Extension, typeof(string));
            Assert.AreEqual(value, file.Extension);
        }
        
        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FileDto_Property_FolderID()
        {
            // Arrange
            var file = new FileDto();
            var value = new Guid();

            // Act
            file.FolderID = value;

            // Assert
            Assert.IsNotNull(file.FolderID);
            Assert.IsInstanceOfType(file.FolderID, typeof(Guid));
            Assert.AreEqual(value, file.FolderID);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FileDto_Property_Created()
        {
            // Arrange
            var file = new FileDto();
            var value = DateTime.Now;

            // Act
            file.Created = value;

            // Assert
            Assert.IsNotNull(file.Created);
            Assert.IsInstanceOfType(file.Created, typeof(DateTime));
            Assert.AreEqual(value, file.Created);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FileDto_Property_CreatedBy()
        {
            // Arrange
            var file = new FileDto();
            var value = TestHelper.UserDto();

            // Act
            file.CreatedBy = value;

            // Assert
            Assert.IsNotNull(file.CreatedBy);
            Assert.IsInstanceOfType(file.CreatedBy, typeof(UserDto));
            Assert.AreEqual(value, file.CreatedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FileDto_Property_Modified()
        {
            // Arrange
            var file = new FileDto();
            var value = DateTime.Now;

            // Act
            file.Modified = value;

            // Assert
            Assert.IsNotNull(file.Modified);
            Assert.IsInstanceOfType(file.Modified, typeof(DateTime));
            Assert.AreEqual(value, file.Modified);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FileDto_Property_ModifiedBy()
        {
            // Arrange
            var file = new FileDto();
            var value = TestHelper.UserDto(); ;

            // Act
            file.ModifiedBy = value;

            // Assert
            Assert.IsNotNull(file.ModifiedBy);
            Assert.IsInstanceOfType(file.ModifiedBy, typeof(UserDto));
            Assert.AreEqual(value, file.ModifiedBy);
        }

        [TestMethod]
        [TestCategory("Entities - Properties")]
        public void FileDto_Property_IsDeleted()
        {
            // Arrange
            var file = new FileDto();
            var value = false;

            // Act
            file.IsDeleted = value;

            // Assert
            Assert.IsNotNull(file.IsDeleted);
            Assert.IsInstanceOfType(file.IsDeleted, typeof(bool));
            Assert.AreEqual(value, file.IsDeleted);
        }

        #endregion Properties Tests

        #region Extensions Tests

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void FileDto_Extension_AsEntity_Null()
        {
            // Arrange
            FileDto file = null;

            // Act
            var result = file.AsEntity();

            // Assert
            Assert.IsNull(result);
            Assert.AreEqual(null, result);
        }

        [TestMethod]
        [TestCategory("Entities - Extensions")]
        public void File_Extension_AsEntity_NotNull()
        {
            // Arrange
            var file = TestHelper.FileDto();

            // Act
            var result = file.AsEntity();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(File));

            Assert.IsNotNull(result.Name);
            Assert.IsInstanceOfType(result.Name, typeof(string));
            Assert.AreEqual(file.Name, result.Name);

            Assert.IsNotNull(result.Extension);
            Assert.IsInstanceOfType(result.Extension, typeof(string));
            Assert.AreEqual(file.Extension, result.Extension);

            Assert.IsNotNull(result.FolderID);
            Assert.IsInstanceOfType(result.FolderID, typeof(Guid));
            Assert.AreEqual(file.FolderID, result.FolderID);

            Assert.IsNotNull(result.Created);
            Assert.IsInstanceOfType(result.Created, typeof(DateTime));
            Assert.AreEqual(file.Created, result.Created);

            Assert.IsNotNull(result.Modified);
            Assert.IsInstanceOfType(result.Modified, typeof(DateTime));
            Assert.AreEqual(file.Modified, result.Modified);

            Assert.IsNotNull(result.IsDeleted);
            Assert.IsInstanceOfType(result.IsDeleted, typeof(bool));
            Assert.AreEqual(file.IsDeleted, result.IsDeleted);
        }

        #endregion Extensions Tests
    }
}