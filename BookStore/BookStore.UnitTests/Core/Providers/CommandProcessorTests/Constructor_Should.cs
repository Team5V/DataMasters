using BookStore.Client.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BookStore.UnitTests.Core.Providers.CommandProcessorTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnSuccess_WhenParametersAreCorrect()
        {
            //Arrange
            var parserMock = new Mock<ICommandParser>();

            //Act
            var processor = new CommandProcessor(parserMock.Object);

            //Assert
            Assert.IsNotNull(processor);
        }
        [TestMethod]
        public void ThrowException_WhenFactoryIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandProcessor(null));
        }
    }
    
}
