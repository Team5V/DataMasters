using BookStore.Client.Commands;
using BookStore.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BookStore.UnitTests.Commands.OfferCommandTests.Read
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenListIsNull()
        {
            //Arrange
            var commandMock = new Mock<OfferReadCommand>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandMock.Object.Execute(null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenListIsEmpty()
        {
            //Arrange
            var commandMock = new Mock<OfferReadCommand>();

            var parameters = new List<string>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandMock.Object.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenValuesLessThan1()
        {
            //Arrange
            var commandMock = new Mock<OfferReadCommand>();

            var parameters = new string[] { };

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => commandMock.Object.Execute(parameters));
        }

        [TestMethod]
        public void ThrowNullException_WhenValueIsNull()
        {
            //Arrange
            var commandMock = new Mock<OfferReadCommand>();
            var parameters = new string[] { null };

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandMock.Object.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenValueIsEmpty()
        {
            //Arrange
            var contextMock = new Mock<IBookStoreContext>();
            var commandMock = new Mock<OfferReadCommand>(contextMock.Object);
            var parameters = new string[] { "" };

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandMock.Object.Execute(parameters));
        }

        [TestMethod]
        public void ThrowFormatException_WhenValueIsOutFormat()
        {
            //Arrange
            var commandMock = new Mock<OfferReadCommand>();
            var parameters = new string[] { "ggga" };

            // Act & Assert
            Assert.ThrowsException<FormatException>(() => commandMock.Object.Execute(parameters));
        }
    }
}