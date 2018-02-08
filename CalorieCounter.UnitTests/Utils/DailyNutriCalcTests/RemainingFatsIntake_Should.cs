using CalorieCounter.Contracts;
using CalorieCounter.Models.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CalorieCounter.UnitTests.Utils.DailyNutriCalcTests
{
    [TestClass]
    public class RemainingFatsIntake_Should
    {
        [TestMethod]
        public void ReturnRemainingFatsIntake_WhenInvokedWithValidParameters()
        {
            // Arrange
            var suggestedDailyFatsIntake = 70;

            var firstProduct = new Mock<IProduct>();
            var secondProduct = new Mock<IProduct>();

            firstProduct
                .SetupGet(m => m.Fat)
                .Returns(12);

            secondProduct
               .SetupGet(m => m.Fat)
               .Returns(22);

            var expectedResult = 36; // 70 - 34
            ICollection<IProduct> productConsumed = new List<IProduct>() { firstProduct.Object, secondProduct.Object };
            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingFatsIntake(suggestedDailyFatsIntake, productConsumed);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnSuggestedFatsIntake_WhenProductsConsumedAreNull()
        {
            // Arrange
            var suggestedDailyFatsIntake = 220;
            var expectedResult = suggestedDailyFatsIntake;

            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingFatsIntake(suggestedDailyFatsIntake, null);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
