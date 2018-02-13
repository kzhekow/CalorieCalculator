using System;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Models.DrinksModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Models.DrinksModel.WaterTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParameterIsCorrect()
        {
            // Arrange
            var weightInMl = 1000;

            // Act
            var water = new Water(weightInMl);

            // Assert
            Assert.IsNotNull(water);
            Assert.IsInstanceOfType(water, typeof(IWater));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenParameterIsNegative()
        {
            // Arrange
            var weightInMl = -5;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => new Water(weightInMl));
        }
    }
}