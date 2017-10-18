using BookStore.Core.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
using System;

namespace BookStore.UnitTests.Core.Factories.CommandFactoryTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowNull_WhenKernelIsNull()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new CommandFactory(null));
        }

        [TestMethod]
        public void ReturnSuccess_WhenParametersAreCorrect()
        {
            //Arrange
            var kernelMock = new Mock<IKernel>();

            //Act
            var commandFactory = new CommandFactory(kernelMock.Object);

            //Assert
            Assert.IsNotNull(commandFactory);
        }
    }
}
