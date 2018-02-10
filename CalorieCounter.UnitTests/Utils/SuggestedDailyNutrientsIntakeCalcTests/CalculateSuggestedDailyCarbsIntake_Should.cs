using CalorieCounter.Models.Contracts;
using CalorieCounter.UnitTests.Mocks;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.SuggestedDailyNutrientsIntakeCalcTests
{
    [TestClass]
    public class CalculateSuggestedDailyCarbsIntake_Should
    {
        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGoalTypeLoseweightParameter()
        {
            // Arrange
            var expectedResult = 171.875;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            goalMock
           .SetupGet(m => m.Type)
           .Returns(GoalType.loseweight);

            var calc = new SuggestedDailyNutrientsIntakeCalcFake(goalMock.Object, restingEnergyMock.Object);
            calc.SuggestedDailyCalorieIntakeExposed = 2750;

            // Act
            var actualResult = calc.CalculateSuggestedDailyCarbsIntake();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGoalTypeMaintainweightParameter()
        {
            // Arrange
            var expectedResult = 275;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            goalMock
                .SetupGet(m => m.Type)
                .Returns(GoalType.maintainweight);

            var calc = new SuggestedDailyNutrientsIntakeCalcFake(goalMock.Object, restingEnergyMock.Object);
            calc.SuggestedDailyCalorieIntakeExposed = 2750;

            // Act
            var actualResult = calc.CalculateSuggestedDailyCarbsIntake();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGoalTypeGainweightParameter()
        {
            // Arrange
            var expectedResult = 343.75;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            goalMock
           .SetupGet(m => m.Type)
           .Returns(GoalType.gainweight);

            var calc = new SuggestedDailyNutrientsIntakeCalcFake(goalMock.Object, restingEnergyMock.Object);
            calc.SuggestedDailyCalorieIntakeExposed = 2750;

            // Act
            var actualResult = calc.CalculateSuggestedDailyCarbsIntake();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
