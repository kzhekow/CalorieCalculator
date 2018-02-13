using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.Models.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.DailyNutriCalcTests
{
    [TestClass]
    public class RemainingProteinIntake_Should
    {
        [TestMethod]
        public void ReturnRemainingProteinIntake_WhenInvokedWithValidParameters()
        {
            // Arrange
            var suggestedDailyProteinIntake = 99;

            var firstProduct = new Mock<IProduct>();
            var secondProduct = new Mock<IProduct>();

            firstProduct
                .SetupGet(m => m.Protein)
                .Returns(20);

            secondProduct
                .SetupGet(m => m.Protein)
                .Returns(25);

            var expectedResult = 54; // 99 - 45
            ICollection<IProduct> productConsumed = new List<IProduct> {firstProduct.Object, secondProduct.Object};
            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingProteinIntake(suggestedDailyProteinIntake, productConsumed);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnSuggestedProteinIntake_WhenProductsConsumedAreNull()
        {
            // Arrange
            var suggestedDailyProteinIntake = 99;
            var expectedResult = suggestedDailyProteinIntake;

            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingProteinIntake(suggestedDailyProteinIntake, null);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}