using System;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.SuggestedDailyNutrientsIntakeCalcTests
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
            var restingEnergyMock = new Mock<IRestingEnergy>();

            goalMock
                .SetupGet(m => m.Type)
                .Returns(GoalType.loseweight);

            var calc = new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, restingEnergyMock.Object);

            // Act
            var actualResult = calc.CalculateSuggestedMacrosRatio();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenGoalTypeIsSetToMaintainWeight()
        {
            // Arrange
            var expectedResult = "Carbs:Protein:Fat = 40:30:30";

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            goalMock
                .SetupGet(m => m.Type)
                .Returns(GoalType.maintainweight);

            var calc = new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, restingEnergyMock.Object);

            // Act
            var actualResult = calc.CalculateSuggestedMacrosRatio();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenGoalTypeIsSetToGainweight()
        {
            // Arrange
            var expectedResult = "Carbs:Protein:Fat = 50:30:20";

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            goalMock
                .SetupGet(m => m.Type)
                .Returns(GoalType.gainweight);

            var calc = new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, restingEnergyMock.Object);

            // Act
            var actualResult = calc.CalculateSuggestedMacrosRatio();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
