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
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookUpdateCommand(null, factoryMock.Object, writerMock.Object, readerMock.Object));
        }
        [TestMethod]
        public void ThrowException_WhenFactoryIsNull()
        {
            // Arrange
            var contextMock = new Mock<IBookStoreContext>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookUpdateCommand(contextMock.Object, null, writerMock.Object, readerMock.Object));
        }
        [TestMethod]
        public void ThrowException_WhenWriterIsNull()
        {
            // Arrange
            var contextMock = new Mock<IBookStoreContext>();
            var factoryMock = new Mock<IBookStoreFactory>();
            var readerMock = new Mock<IReader>();
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookUpdateCommand(contextMock.Object, factoryMock.Object, null, readerMock.Object));
        }
        [TestMethod]
        public void ThrowException_WhenReaderIsNull()
        {
            // Arrange
            var contextMock = new Mock<IBookStoreContext>();
            var factoryMock = new Mock<IBookStoreFactory>();
            var writerMock = new Mock<IWriter>();
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookUpdateCommand(contextMock.Object, factoryMock.Object, writerMock.Object, null));
        }
        [TestMethod]
        public void ReturnSuccess_WhenParametersAreCorrect()
        {
            //Arrange
            var contextMock = new Mock<IBookStoreContext>();
            var factoryMock = new Mock<IBookStoreFactory>();
            var readerMock = new Mock<IReader>();
            var writerMock = new Mock<IWriter>();
            //Act

            var updateBook = new BookUpdateCommand(contextMock.Object, factoryMock.Object, writerMock.Object, readerMock.Object);

            //Assert

            Assert.IsNotNull(updateBook);
        }
    }
}