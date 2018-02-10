using System;
using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.SuggestedDailyNutrientsIntakeCalcTests
{
    [TestClass]
    public class CalculateSuggestedDailyCalorieIntake_Should
    {
        [TestMethod]
        public void ReturnTheCorrectValue_WhenActivityLevelIsSetToLight()
        {
            // Arrange
            var expectedResult = 2750;
            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            restingEnergyMock
                .Setup(m => m.CalculateRestingEnergy())
                .Returns(2000);

            goalMock
                .SetupGet(m => m.Level)
                .Returns(ActivityLevel.light);

            var calc = new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, restingEnergyMock.Object);

            // Act
            var actualResult = calc.CalculateSuggestedDailyCalorieIntake();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
