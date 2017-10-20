using BookStore.Client.Commands;
using BookStore.Data;
using BookStore.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace BookStore.UnitTests.Commands.OfferCommandTests.Read
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnFormatedString_WhenParametersAreCorrect()
        {
            //Arrange
            var cmdMock = new Mock<ICommand>();
            var title = "Book TITLE";
            var offerMock = new Offer { BookId = 1, Price = 20, Copies = 2 };
            var args = new string[] { "1;" };
        }
    }
}