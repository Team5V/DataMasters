using BookStore.Core.Factories;
using BookStore.Core.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseParameters_Should
    {
        [TestMethod]
        public void ReturnListWithCorrectParameters_WhenFullCommandContainsParameters()
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();

            string fullCommand = "bookcreate:Nai-qkata Kniga;BG;80;Author1,Author2,Author3;Comedy";

            List<string> expectedResult = new List<string>()
            {
                "Nai-qkata Kniga",
                "BG",
                "80",
                "Author1,Author2,Author3", 
                "Comedy"
            };

            var parser = new CommandParser(factoryMock.Object);

            // Act
            var result = parser.ParseParameters(fullCommand).ToList();

            // Assert
            CollectionAssert.AreEquivalent(expectedResult, result);
        }

        [TestMethod]
        public void ReturnEmptyList_WhenFullCommandDoesNotContainParameters()
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();

            string fullCommand = "bookdelete:";

            var parser = new CommandParser(factoryMock.Object);

            // Act
            var result = parser.ParseParameters(fullCommand).ToList();

            // Assert
            Assert.AreEqual(0, result.Count);
        }
    }
}
