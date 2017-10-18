using BookStore.Client.Commands;
using BookStore.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BookStore.UnitTests.Commands.CreateBookCommandTest
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowException_WhenContextIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookCreateCommand(null));
        }
        
        [TestMethod]
        public void ReturnSuccess_WhenParametersAreCorrect()
        {
            //Arrange
            var contextMock = new Mock<IBookStoreContext>();

            //Act
            var createBook = new BookCreateCommand(contextMock.Object);

            //Assert
            Assert.IsNotNull(createBook);
        }
    }
}
