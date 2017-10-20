using BookStore.Client.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BookStore.UnitTests.Core.Utils
{
    [TestClass]
    public class ValidateParameters_Should
    {
        [TestMethod]
        public void ThrowArgumentException_WhenListIsEmpty()
        {
            //Arrange
            var parameters = new List<string>();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => ContextExtension.ValidateParameters(parameters));
        }

        [TestMethod]
        [DataRow(2), DataRow(3), DataRow(4), DataRow(5), DataRow(6), DataRow(7)]
        public void ThrowArgumentOutOfRangeException_WhenValuesLessThanCount(int neededArgCount)
        {
            //Arrange
            var args = new List<string> { "aaaaa" };
            //Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ContextExtension.ValidateParameters(args, neededArgCount));
        }

        [TestMethod]
        public void ThrowArgNullException_WhenValueIsNull()
        {
            //Arrange
            var args = new string[] { "1", "2", null, "dad", "444" };

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ContextExtension.ValidateParameters(args, 5));
        }

        [TestMethod]
        public void ThrowArgNullException_WhenValueIsEmpty()
        {
            //Arrange            
            var args = new string[] { "1", "2", "", "dad", "444" };


            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ContextExtension.ValidateParameters(args, 5));
        }

        [TestMethod]
        public void ThrowsArgNullException_WhenValueIsWhiteSpace()
        {
            //Arrange
            var args = new string[] { "1", "2", "afaf", "   ", "444" };

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => ContextExtension.ValidateParameters(args));
        }
    }
}