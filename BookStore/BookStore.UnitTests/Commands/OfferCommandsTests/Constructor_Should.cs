using BookStore.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BookStore.Client.Commands.Offer.Tests
{
    [TestClass()]
    public class Constructor_Should
    {
        [TestMethod]
        public void Create_ThrowArgNullException_WhenContextIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new OfferCreateCommand(null));
        }

        [TestMethod]
        public void Read_ThrowArgNullException_WhenContextIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new OfferReadCommand(null));
        }

        [TestMethod]
        public void Update_ThrowArgNullException_WhenContextIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new OfferUpdateCommand(null));
        }

        [TestMethod]
        public void Delete_ThrowArgNullException_WhenContextIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new OfferDeleteCommand(null));
        }

        [TestMethod]
        public void ReturnSuccess_WhenParametersAreCorrect()
        {
            //Arrange
            var contextMock = new Mock<IBookStoreContext>();

            //Act
            var offerCreate = new OfferCreateCommand(contextMock.Object);

            //Assert
            Assert.IsNotNull(offerCreate);
        }
    }
}