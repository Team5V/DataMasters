using BookStore.Client.Commands;
using BookStore.Client.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BookStore.UnitTests.Commands.OfferCommandTests.Create
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void Called_ValidateParametersMethod()
        {
            //Arrange
            var cmd = new Mock<ICommand>();
            var args = new string[] { "id", "whatEver", "alf", "Pesho   ", "444" };

            //Act 
            cmd.Object.Execute(args);

            //Assert
            cmd.Verify(x => x.Execute(args), Times.AtLeastOnce);
            //ADJBA need Help want to check does it call validate method
        }
    }
}