using BookStore.Client.Commands;
using BookStore.Client.Core;
using BookStore.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BookStore.UnitTests.Commands.ReportGenerateCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowException_WhenContextIsNull()
        {
            // Arrange 
            var contextMock = new Mock<IBookStoreContext>();
            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ReportGenerateCommand(contextMock.Object,null));
        }
        [TestMethod]
        public void ReturnSuccess_WhenParametersAreCorrect()
        {
            //Arrange
            var contextMock = new Mock<IBookStoreContext>();
            var pdfExporterMock = new Mock<IPdfExporter>();

            //Act
            var updateBook = new ReportGenerateCommand(contextMock.Object,pdfExporterMock.Object);

            //Assert
            Assert.IsNotNull(updateBook);
        }
    }
}
