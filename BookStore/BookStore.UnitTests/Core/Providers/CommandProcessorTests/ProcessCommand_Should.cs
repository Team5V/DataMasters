using BookStore.Commands;
using BookStore.Core.Contracts;
using BookStore.Core.Providers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BookStore.UnitTests.Core.Providers.CommandProcessorTests
{
    [TestClass]
    public class ProcessCommand_Should
    {
        [TestMethod]
        public void ReturnExecutedString_WhenParametersAreCorrect()
        {
            // Arrange 
            var parserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();

            List<string> parameters = new List<string>()
            {
                "Nai-qkata Kniga",
                "BG",
                "80",
                "Author1,Author2,Author3", // TODO: Fix - This should be a List(ICollection)
                "Comedy"
            };

            var commandAsString = "bookcreate:Nai-qkata Kniga;BG;80;Author1,Author2,Author3;Comedy";

            var actualResult = "Successfully added Nai-qkata Kniga.";
            var commandProcessor = new CommandProcessor(parserMock.Object);
            parserMock.Setup(p => p.ParseParameters(commandAsString)).Returns(parameters);
            commandMock.Setup(c => c.Execute(parameters)).Returns(actualResult);

            
            // Act
            var expectedResult = commandProcessor.ProcessCommand(commandAsString);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);

        }

    }
}
