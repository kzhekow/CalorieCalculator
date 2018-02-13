using System;
using CalorieCounter.Models.Contracts;
using CalorieCounter.UnitTests.Mocks;
using CalorieCounter.Utils;
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

            restingEnergyMock
                .Setup(m => m.CalculateRestingEnergy(It.IsAny<IGoal>()))
                .Returns(2000);

            var calc = new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, restingEnergyMock.Object);
            

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

            restingEnergyMock
                .Setup(m => m.CalculateRestingEnergy(It.IsAny<IGoal>()))
                .Returns(2000);

            var calc = new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, restingEnergyMock.Object);
            

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

            restingEnergyMock
                .Setup(m => m.CalculateRestingEnergy(It.IsAny<IGoal>()))
                .Returns(2000);

            var calc = new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, restingEnergyMock.Object);
            
            // Act
            var actualResult = calc.CalculateSuggestedDailyProteinIntake();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
