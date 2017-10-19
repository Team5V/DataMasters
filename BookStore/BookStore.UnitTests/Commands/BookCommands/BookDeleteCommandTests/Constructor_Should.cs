using BookStore.Client.Commands;
using BookStore.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BookStore.UnitTests.Commands.BookDeleteCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            //Arrange
            var databaseMock = new Mock<IBookStoreContext>();

            // Act
            var command = new BookDeleteCommand(databaseMock.Object);

            // Assert
            Assert.IsNotNull(command);
        }

        [TestMethod]
        public void ThrowException_WhenDatabaseIsNull()
        {
            // Arrange
            var databaseMock = new Mock<IBookStoreContext>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookDeleteCommand(null));
        }
    }
}
