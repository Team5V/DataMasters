using BookStore.Core.Factories;
using BookStore.Core.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BookStore.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnSuccess_WhenParametersAreCorrect()
        {
            //Arrange
            var factoryMock = new Mock<ICommandFactory>();

            //Act
            var parser = new CommandParser(factoryMock.Object);

            //Assert
            Assert.IsNotNull(parser);
        }
        [TestMethod]
        public void ThrowException_WhenFactoryIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandParser(null));
        }
    }
}
