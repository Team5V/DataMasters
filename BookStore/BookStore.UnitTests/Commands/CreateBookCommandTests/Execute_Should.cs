using BookStore.Core.Contracts;
using BookStore.Database;
using BookStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BookStore.UnitTests.Commands.CreateBookCommandTest
{
    [TestClass]
    public class Execute_Should
    {
        public void ReturnExecutionString_WhenParametersAreCorrect()
        {
            // Arrange 
            var contextMock = new Mock<IBookStoreContext>();
            var factoryMock = new Mock<IBookStoreFactory>();
            var bookMock = new Mock<Book>();
            

            List<string> parameters = new List<string>()
            {
                "Nai - qkata Kniga",
                "BG",
                "80",
                "Author1,Author2,Author3",
                "Comedy"
            };

            //factoryMock.Setup(f => f.CreateBook()).Returns(bookMock);

            //var command = new BookCreateCommand(contextMock.Object, factoryMock.Object);
            //// Act
            //var result = command.Execute(parameters);
            //// Assert
            //Assert.AreEqual(1,)
        }
    }
}
