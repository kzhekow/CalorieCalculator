using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CalorieCounter.UnitTests.Utils.SuggestedDailyNutrientsIntakeCalcTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenInvokedWithValidParameters()
        {
            // Arrange
            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            // Act
            var calc = new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, restingEnergyMock.Object);

            // Assert
            Assert.IsNotNull(calc);
            Assert.IsInstanceOfType(calc, typeof(ISuggestedDailyNutrientsIntakeCalc));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullGoalParameter()
        {
            // Arrange
            //var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SuggestedDailyNutrientsIntakeCalc(null, restingEnergyMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenInvokedWithNullRestingEnergyParameter()
        {
            // Arrange
            var goalMock = new Mock<IGoal>();
            //var restingEnergyMock = new Mock<IRestingEnergy>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SuggestedDailyNutrientsIntakeCalc(goalMock.Object, null));
        }
    }
}
