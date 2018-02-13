using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.Models.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.DailyNutriCalcTests
{
    [TestClass]
    public class RemainingCarbsIntake_Should
    {
        [TestMethod]
        public void ReturnRemainingCarbsIntake_WhenInvokedWithValidParameters()
        {
            // Arrange
            var suggestedDailyCarbsIntake = 220;

            var firstProduct = new Mock<IProduct>();
            var secondProduct = new Mock<IProduct>();

            firstProduct
                .SetupGet(m => m.Carbs)
                .Returns(60);

            secondProduct
                .SetupGet(m => m.Carbs)
                .Returns(55);

            var expectedResult = 105; // 220 - 115
            ICollection<IProduct> productConsumed = new List<IProduct> {firstProduct.Object, secondProduct.Object};
            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingCarbsIntake(suggestedDailyCarbsIntake, productConsumed);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnSuggestedCarbsIntake_WhenProductsConsumedAreNull()
        {
            // Arrange
            var suggestedDailyCarbsIntake = 220;
            var expectedResult = suggestedDailyCarbsIntake;

            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingCarbsIntake(suggestedDailyCarbsIntake, null);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}