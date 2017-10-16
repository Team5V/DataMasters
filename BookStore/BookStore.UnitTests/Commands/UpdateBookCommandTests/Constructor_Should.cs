using BookStore.Commands;
using BookStore.Core.Contracts;
using BookStore.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BookStore.UnitTests.Commands.UpdateBookCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowException_WhenContextIsNull()
        {
            // Arrange
            var factoryMock = new Mock<IBookStoreFactory>();
            // Act & Assert
            Assert
                .ThrowsException<ArgumentNullException>
                (() => new BookUpdateCommand(null));
        }
        [TestMethod]
        public void ReturnSuccess_WhenParametersAreCorrect()
        {
            //Arrange
            var contextMock = new Mock<IBookStoreContext>();

            //Act
            var updateBook = new BookUpdateCommand(contextMock.Object);

            //Assert
            Assert.IsNotNull(updateBook);
        }
    }
}