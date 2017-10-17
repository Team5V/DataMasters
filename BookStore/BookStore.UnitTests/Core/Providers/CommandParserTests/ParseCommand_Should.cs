using BookStore.Client.Commands;
using BookStore.Client.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookStore.UnitTests.Core.Providers.CommandParserTests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        [DataRow("bookcreate:Nai-qkata Kniga;BG;80;Author1,Author2,Author3;Comedy", "bookcreate")]
        [DataRow("bookread:Dependency Injection", "bookread")]
        [DataRow("bookupdate:Java is also good", "bookupdate")]
        [DataRow("bookdelete:Best Book", "bookdelete")]
        public void ReturnCommand_WhenParameterIsCorrect(string fullCommand, string commandName)
        {
            // Arrange
            var factoryMock = new Mock<ICommandFactory>();
            var commandMock = new Mock<ICommand>();

            factoryMock.Setup(m => m.ResolveCommand(commandName)).Returns(commandMock.Object);

            var parser = new CommandParser(factoryMock.Object);

            // Act
            var result = parser.ParseCommand(fullCommand);

            // Assert
            Assert.AreEqual(commandMock.Object, result);
        }
    }
}
