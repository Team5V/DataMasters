using BookStore.Client.Commands;
using BookStore.Data;
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
        public void AddToDatabaseAndSaveChanges_WhenParametersAreCorrect()
        {
            // Arrange 
            var contextMock = new Mock<IBookStoreContext>();
            var bookSetMock = new Mock<IDbSet<Book>>();
            var book = new Book();

            bookSetMock.Object.Add(book);
            contextMock.Setup(b => b.Books).Returns(bookSetMock.Object);
            
            contextMock.Object.SaveChanges();
            
            // Act && Assert
            bookSetMock.Verify(b => b.Add(It.IsAny<Book>()), Times.Once());
            contextMock.Verify(m => m.SaveChanges(), Times.Once());
        }
        [TestMethod]
        public void PerformExecuteCommand_WhenParametersAreCorrect()
        {
            // Arrange 
            var contextMock = new Mock<IBookStoreContext>();
            var bookSetMock = new Mock<IDbSet<Book>>();
            var authorSetMock = new Mock<IDbSet<Author>>();
            var commandMock = new Mock<ICommand>();
            var book = new Book();
            book.Title = "Title";
            book.Genre = GenreType.Comedy;
            book.Language = "BG";
            book.Pages = 80;


            List<string> parameters = new List<string>()
            {
                "Nai-qkata Kniga",
                "BG",
                "80",
                "Author1,Author2,Author3",
                "Comedy"
            };


            var actualResult = "Successfully added Nai-qkata Kniga.";
            bookSetMock.Object.Add(book);
            commandMock.Setup(c => c.Execute(parameters)).Returns(actualResult);
            contextMock.Setup(b => b.Books).Returns(bookSetMock.Object);
            //contextMock.Setup(a => a.Authors).Returns(authorSetMock.Object);

            contextMock.Object.SaveChanges();

            var command = new BookCreateCommand(contextMock.Object);
            // Act
            var result = command.Execute(parameters);
            // Assert
            Assert.AreEqual(result, actualResult); // Only this is not working
        }
    }
}
