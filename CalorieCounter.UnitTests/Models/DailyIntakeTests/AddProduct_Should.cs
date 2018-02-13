using System;
using CalorieCounter.Contracts;
using CalorieCounter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Models.DailyIntakeTests
{
    [TestClass]
    public class AddProduct_Should
    {
        [TestMethod]
        public void AddProduct_WhenArgumentIsNotNull()
        {
            // Arrange
            var product = new Mock<IProduct>();
            var dailyIntake = new DailyIntake();

            // Act
            dailyIntake.AddProduct(product.Object);

            // Assert
            Assert.IsTrue(dailyIntake.ProductsConsumed.Contains(product.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenProductIsNull()
        {
            // Arrange
            IProduct product = null;
            var dailyIntake = new DailyIntake();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dailyIntake.AddProduct(product));
        }
    }
}