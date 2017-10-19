using System;
using BookStore.Client.Commands;
using BookStore.Client.Core;
using BookStore.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace BookStore.UnitTests.Commands.ReportGenerateCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void VerifyWhenCalled_WhenContextIsCorrect()
        {
            //Assert 
            var contextMock = new Mock<IBookStoreContext>();
            var exporterMock = new Mock<IPdfExporter>();

            //Act
            exporterMock.Object.ExportToPdf(contextMock.Object);

            //Assert
            exporterMock.Verify(e => e.ExportToPdf(contextMock.Object), Times.Once);
        }
        
    } 
}
