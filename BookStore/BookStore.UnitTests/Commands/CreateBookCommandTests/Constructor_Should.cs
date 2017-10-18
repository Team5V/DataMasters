using BookStore.Commands;
using BookStore.Core.Contracts;
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
            // Arrange
            var factoryMock = new Mock<IBookStoreFactory>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookCreateCommand(null, factoryMock.Object));
        }
        [TestMethod]
        public void ThrowException_WhenFactoryIsNull()
        {
            // Arrange
            var contextMock = new Mock<IBookStoreContext>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookCreateCommand(contextMock.Object, null));
        }
        [TestMethod]
        public void ReturnSuccess_WhenParametersAreCorrect()
        {
            //Arrange
            var contextMock = new Mock<IBookStoreContext>();
            var factoryMock = new Mock<IBookStoreFactory>();

            //Act
            var createBook = new BookCreateCommand(contextMock.Object, factoryMock.Object);

            //Assert
            Assert.IsNotNull(createBook);
        }
    }
}
