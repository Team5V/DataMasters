using BookStore.Core.Contracts;
using BookStore.Core.Factories;
using BookStore.Core.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
