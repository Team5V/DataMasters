using BookStore.Client.Commands;
using BookStore.Data;
using BookStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

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
            //var bookObjectMock = new Mock(??); No factory to mock 

            var bookObjectMock = new Book();
            var bookObjectAuthorMock = new Author();
            bookObjectAuthorMock.FullName = ("Alexander Petrov");

            bookObjectMock.Title = "TestBook";
            bookObjectMock.Id = 1;
            bookObjectMock.Authors.Add(bookObjectAuthorMock);
            bookObjectMock.Language = "RU";
            bookObjectMock.Pages = 100;
            bookObjectMock.Genre = GenreType.Drama;

            databaseMock.Object.Books.Add(bookObjectMock);
            //databaseMock.SetupGet(c => c.Books.Add(bookObjectMock)).Returns(bookObjectMock);
            //databaseMock.SetupSet(c => c.Books.Add(bookObjectMock));
            var bookDeleteCommand = new BookDeleteCommand(databaseMock.Object);

            IList<string> parameters = new List<string>()
            {
                "TestBook",
            };

            string expectedResult = $"Deleted {bookObjectMock.Title} from Library";

            //Act
            var actualResult = bookDeleteCommand.Execute(parameters);

            //Assert

            Assert.AreEqual(expectedResult, actualResult);

        }
    }
}
