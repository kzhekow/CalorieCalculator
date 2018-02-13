using System;
using CalorieCounter.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Models.DailyIntakeTests
{
    [TestClass]
    public class RemoveWater_Should
    {
        [TestMethod]
        public void ReduceQuantity_WhenParameterIsPositiveAndWithinRange()
        {
            // Arrange
            var dailyIntake = new DailyIntake();
            var waterAdded = 1000;
            var waterRemoved = 500;
            dailyIntake.AddWater(waterAdded);

            // Act 
            dailyIntake.RemoveWater(waterRemoved);

            // Assert
            Assert.AreEqual(dailyIntake.Water, waterAdded - waterRemoved);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenPassedArgumentIsNegative()
        {
            // Arrange
            var dailyIntake = new DailyIntake();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                dailyIntake.RemoveWater(-1));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenArgumentIsBiggerThanCurrentQuantity()
        {
            // Arrange
            var dailyIntake = new DailyIntake();

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
                dailyIntake.RemoveWater(100));
        }
    }
}