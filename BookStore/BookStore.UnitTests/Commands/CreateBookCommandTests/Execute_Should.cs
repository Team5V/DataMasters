using BookStore.Client.Commands;
using BookStore.Database;
using BookStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookStore.UnitTests.Commands.CreateBookCommandTest
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnExecutionString_WhenParametersAreCorrect()
        {
            // Arrange 
            var contextMock = new Mock<IBookStoreContext>();
            var bookSetMock = new Mock<IDbSet<Book>>();
            var commandMock = new Mock<ICommand>();

            List<string> parameters = new List<string>()
            {
                "Nai - qkata Kniga",
                "BG",
                "80",
                "Author1,Author2,Author3",
                "Comedy"
            };


            var actualResult = "Successfully added Nai-qkata Kniga.";

            commandMock.Setup(c => c.Execute(parameters)).Returns(actualResult);
            contextMock.Setup(b => b.Books).Returns(bookSetMock.Object);
             
            var command = new BookCreateCommand(contextMock.Object);
            // Act
            var result = command.Execute(parameters);
            // Assert
            Assert.AreEqual(result, actualResult);
            bookSetMock.Verify(b => b.Add(It.IsAny<Book>()), Times.Once());
            contextMock.Verify(m => m.SaveChanges(), Times.Once());
        }
    }
}
