using System;
using CalorieCounter.Contracts;
using CalorieCounter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Models.DailyIntakeTests
{
    [TestClass]
    public class RemoveProduct
    {
        [TestMethod]
        public void RemoveProduct_WhenArgumentIsPresentInTheContainer()
        {
            // Arrange
            var product = new Mock<IProduct>();
            var dailyIntake = new DailyIntake();
            dailyIntake.AddProduct(product.Object);

            // Act
            dailyIntake.RemoveProduct(product.Object);

            // Assert
            Assert.IsFalse(dailyIntake.ProductsConsumed.Contains(product.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNull()
        {
            // Arrange
            IProduct product = null;
            var dailyIntake = new DailyIntake();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dailyIntake.RemoveProduct(product));
        }
    }
}