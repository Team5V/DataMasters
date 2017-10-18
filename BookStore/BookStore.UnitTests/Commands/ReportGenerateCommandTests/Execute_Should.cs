using BookStore.Client.Commands;
using BookStore.Client.Core;
using BookStore.Database;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookStore.UnitTests.Commands.ReportGenerateCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnExecutedString_WhenParametersAreCorrect()
        {
            //Assert 
            var contextMock = new Mock<IBookStoreContext>();
            var exporterMock = new Mock<IPdfExporter>();

            var reportGenerateCommand = new ReportGenerateCommand(contextMock.Object, exporterMock.Object);
            
            //Act
            
        }
    
            
    } 
}
