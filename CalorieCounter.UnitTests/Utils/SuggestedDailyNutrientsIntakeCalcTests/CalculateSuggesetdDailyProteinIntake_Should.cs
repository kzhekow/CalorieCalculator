using System;
using CalorieCounter.Models.Contracts;
using CalorieCounter.UnitTests.Mocks;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.SuggestedDailyNutrientsIntakeCalcTests
{
    [TestClass]
    public class CalculateSuggesetdDailyProteinIntake_Should
    {
        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGoalTypeLoseweightParameter()
        {
            // Arrange
            var expectedResult = 275;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            goalMock
           .SetupGet(m => m.GoalType)
           .Returns(GoalType.loseweight);

            var calc = new SuggestedDailyNutrientsIntakeCalcFake(goalMock.Object, restingEnergyMock.Object);
            calc.SuggestedDailyCalorieIntakeExposed = 2750;

            // Act
            var actualResult = calc.CalculateSuggestedDailyProteinIntake();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGoalTypeMaintainweightParameter()
        {
            // Arrange
            var expectedResult = 206.25;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            goalMock
                .SetupGet(m => m.GoalType)
                .Returns(GoalType.maintainweight);

            var calc = new SuggestedDailyNutrientsIntakeCalcFake(goalMock.Object, restingEnergyMock.Object);
            calc.SuggestedDailyCalorieIntakeExposed = 2750;

            // Act
            var actualResult = calc.CalculateSuggestedDailyProteinIntake();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGoalTypeGainweightParameter()
        {
            // Arrange
            var expectedResult = 206.25;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            goalMock
           .SetupGet(m => m.GoalType)
           .Returns(GoalType.gainweight);

            var calc = new SuggestedDailyNutrientsIntakeCalcFake(goalMock.Object, restingEnergyMock.Object);
            calc.SuggestedDailyCalorieIntakeExposed = 2750;

            // Act
            var actualResult = calc.CalculateSuggestedDailyProteinIntake();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
