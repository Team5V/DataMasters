﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookStore.Client.Commands;
using System.Collections.Generic;
using Moq;
using BookStore.Data;

namespace BookStore.UnitTests.Commands.OfferCommandTests.Create
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenListIsNull()
        {
            //Arrange
            var commandMock = new Mock<OfferCreateCommand>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandMock.Object.Execute(null));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenListIsEmpty()
        {
            //Arrange
            var commandMock = new Mock<OfferCreateCommand>();

            var parameters = new List<string>();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandMock.Object.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentOutOfRangeException_WhenValuesLessThan3()
        {
            //Arrange
            var commandMock = new Mock<OfferCreateCommand>();

            var parameters = new string[] { "1", "2" };

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => commandMock.Object.Execute(parameters));
        }

        [TestMethod]
        public void ThrowNullException_WhenValueIsNull()
        {
            //Arrange
            var commandMock = new Mock<OfferCreateCommand>();
            var parameters = new string[] { "1", "2", null };

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandMock.Object.Execute(parameters));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenValueIsEmpty()
        {
            //Arrange
            var commandMock = new Mock<OfferCreateCommand>();
            var parameters = new string[] { "1", "2", "" };

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => commandMock.Object.Execute(parameters));
        }

        [TestMethod]
        public void ThrowFormatException_WhenValueIsOutFormat()
        {
            //Arrange
            var commandMock = new Mock<OfferCreateCommand>();
            var parameters = new string[] { "1", "fg", "2" };

            // Act & Assert
            Assert.ThrowsException<FormatException>(() => commandMock.Object.Execute(parameters));
        }
    }
}