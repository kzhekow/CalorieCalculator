using System;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils
{
    [TestClass]
    public class CalculateSuggestedMacrosRation_Should
    {
        [TestMethod]
        public void ReturnCorrectValue_WhenGoalTypeIsSetToLoseweight()
        {
            // Arrange
            var expectedResult = "Carbs:Protein:Fat = 25:40:35";

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            goalMock
                .SetupGet(m => m.Type)
                .Returns(GoalType.loseweight);

            var calc = new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, restingEnergyMock.Object);

            // Act
            var actualResult = calc.CalculateSuggestedMacrosRatio();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
