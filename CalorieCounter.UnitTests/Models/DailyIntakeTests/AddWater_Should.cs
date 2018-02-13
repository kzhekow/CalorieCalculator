using System;
using CalorieCounter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Models.DailyIntakeTests
{
    [TestClass]
    public class AddWater_Should
    {
        [TestMethod]
        public void ThrowArgumentException_WhenPassedArgumentIsNegative()
        {
            // Arrange
            var dailyIntake = new DailyIntake();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                dailyIntake.AddWater(-1));
        }

        [TestMethod]
        public void AddQuantity_WhenArgumentIsPositive()
        {
            // Arrange
            var dailyIntake = new DailyIntake();
            var waterToBeAdded = 500;

            // Act 
            dailyIntake.AddWater(waterToBeAdded);

            // Assert
            Assert.AreEqual(dailyIntake.Water, waterToBeAdded);
        }

        [TestMethod]
        public void ThrowStackOverflowException_WhenQuantityIsOverflowing()
        {
            // Arrange
            var dailyIntake = new DailyIntake();
            dailyIntake.AddWater(int.MaxValue);

            // Act & Assert
            Assert.ThrowsException<OverflowException>(() => dailyIntake.AddWater(int.MaxValue));
        }
    }
}