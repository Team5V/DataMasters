using BookStore.Client.Commands;
using BookStore.Data;
using BookStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Data.Entity;

namespace BookStore.UnitTests.Commands.BookDeleteCommandTests
{
    [TestClass]
    public class ExecuteShould
    {
        [TestMethod]
        public void DeleteBookFromDatabase_WhenParametersAreCorrect()
        {
            //Arrange
            var databaseMock = new Mock<IBookStoreContext>();
            var bookSetMock = new Mock<IDbSet<Book>>();
            var bookObjectMock = new Book();
            var bookObjectAuthorMock = new Author();
            bookObjectAuthorMock.FullName = ("Alexander Petrov");

            bookObjectMock.Title = "TestBook";
            bookObjectMock.Id = 1;
            bookObjectMock.Authors.Add(bookObjectAuthorMock);
            bookObjectMock.Language = "RU";
            bookObjectMock.Pages = 100;
            bookObjectMock.Genre = GenreType.Drama;

            bookSetMock.Object.Remove(bookObjectMock);
            databaseMock.Setup(d => d.Books).Returns(bookSetMock.Object);
            databaseMock.Object.SaveChanges();
            //var bookDeleteCommand = new BookDeleteCommand(databaseMock.Object);

            //IList<string> parameters = new List<string>()
            //{
            //    "TestBook",
            //};

            //string expectedResult = $"Deleted {bookObjectMock.Title} from Library";

            //Act && Assert

            bookSetMock.Verify(b => b.Remove(It.IsAny<Book>()), Times.Once);
            databaseMock.Verify(d => d.SaveChanges(), Times.Once);

        }
    }
}
