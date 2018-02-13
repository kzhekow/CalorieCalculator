using System;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.SuggestedDailyNutrientsIntakeCalcTests
{
    [TestClass]
    public class CalculateSuggestedDailyFatIntake_Should
    {
        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGoalTypeLoseweightParameter()
        {
            // Arrange
            var expectedResult = 106;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            goalMock
           .SetupGet(m => m.GoalType)
           .Returns(GoalType.loseweight);

            restingEnergyMock
                .Setup(m => m.CalculateRestingEnergy(It.IsAny<IGoal>()))
                .Returns(2000);

            var calc = new SuggestedDailyNutrientsIntakeCalc();
            

            // Act
            var actualResult = calc.CalculateSuggestedDailyFatIntake(goalMock.Object, restingEnergyMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGoalTypeMaintainweightParameter()
        {
            // Arrange
            var expectedResult = 91;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            goalMock
                .SetupGet(m => m.GoalType)
                .Returns(GoalType.maintainweight);

            restingEnergyMock
                .Setup(m => m.CalculateRestingEnergy(It.IsAny<IGoal>()))
                .Returns(2000);

            var calc = new SuggestedDailyNutrientsIntakeCalc();
          
            // Act
            var actualResult = calc.CalculateSuggestedDailyFatIntake(goalMock.Object, restingEnergyMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, (int)actualResult);
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGoalTypeGainweightParameter()
        {
            // Arrange
            var expectedResult = 61;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            goalMock
           .SetupGet(m => m.GoalType)
           .Returns(GoalType.gainweight);

            restingEnergyMock
                .Setup(m => m.CalculateRestingEnergy(It.IsAny<IGoal>()))
                .Returns(2000);

            var calc = new SuggestedDailyNutrientsIntakeCalc();
            

            // Act
            var actualResult = calc.CalculateSuggestedDailyFatIntake(goalMock.Object, restingEnergyMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, (int)actualResult);
        }
    }
}
