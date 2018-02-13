using System;
using CalorieCounter.Models.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Utils.DailyNutriCalcTests
{
    [TestClass]
    public class RemainingWaterIntake_Should
    {
        [TestMethod]
        public void ReturnRemainingWaterIntake_WhenInvokedWithValidParameters()
        {
            // Assert
            var suggestedWaterIntake = 3700;
            var waterConsumed = 2000;
            var expectedResult = 1700;

            var dailyNutriCal = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCal.RemainingWaterIntake(suggestedWaterIntake, waterConsumed);

            // Arrange
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithNegativeWaterConsumedParameter()
        {
            // Assert
            var suggestedWaterIntake = 3700;
            var waterConsumed = -1000;

            var dailyNutriCal = new DailyNutriCalc();

            // Act
            Assert.ThrowsException<ArgumentException>(() =>
                dailyNutriCal.RemainingWaterIntake(suggestedWaterIntake, waterConsumed));
        }
    }
}