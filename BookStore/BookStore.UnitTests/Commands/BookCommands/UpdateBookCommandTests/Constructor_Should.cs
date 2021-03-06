﻿using BookStore.Client.Commands;
using BookStore.Data;
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
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new BookUpdateCommand(null));
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