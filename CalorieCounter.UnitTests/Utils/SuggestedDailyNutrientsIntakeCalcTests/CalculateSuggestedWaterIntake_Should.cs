using CalorieCounter.Models.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.SuggestedDailyNutrientsIntakeCalcTests
{
    [TestClass]
    public class CalculateSuggestedWaterIntake_Should
    {
        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGenderTypeMaleParameter()
        {
            // Arrange
            var expectedResult = 3700;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            goalMock
                .SetupGet(m => m.Gender)
                .Returns(GenderType.male);

            var calc = new SuggestedDailyNutrientsIntakeCalc();

            // Act
            var actualResult = calc.CalculateSuggestedWaterIntake(goalMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCorrectValue_WhenInvokedWithGenderTypeFemaleParameter()
        {
            // Arrange
            var expectedResult = 2600;

            var goalMock = new Mock<IGoal>();
            var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            goalMock
                .SetupGet(m => m.Gender)
                .Returns(GenderType.female);

            var calc = new SuggestedDailyNutrientsIntakeCalc();

            // Act
            var actualResult = calc.CalculateSuggestedWaterIntake(goalMock.Object);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
