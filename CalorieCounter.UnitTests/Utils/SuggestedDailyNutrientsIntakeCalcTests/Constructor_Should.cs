using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            // Act
            var calc = new SuggestedDailyNutrientsIntakeCalc();

            // Assert
            Assert.IsNotNull(calc);
            Assert.IsInstanceOfType(calc, typeof(ISuggestedDailyNutrientsIntakeCalc));
        }
    }
}