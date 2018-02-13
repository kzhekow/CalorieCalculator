using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.Models.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.DailyNutriCalcTests
{
    [TestClass]
    public class CalculateCurrentSugars_Should
    {
        [TestMethod]
        public void ReturnPositiveNumber_WhenParameterIsNotNull()
        {
            // Arrange
            var expectedResult = 11;

            var firstProduct = new Mock<IProduct>();
            var secondProduct = new Mock<IProduct>();

            firstProduct
                .SetupGet(m => m.Sugar)
                .Returns(5);

            secondProduct
                .SetupGet(m => m.Sugar)
                .Returns(6);

            ICollection<IProduct> productConsumed = new List<IProduct> {firstProduct.Object, secondProduct.Object};
            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.CalculateCurrentSugars(productConsumed);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void Return0_WhenInvokedWithNullParameter()
        {
            // Arrange
            var expectedResult = 0;

            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.CalculateCurrentSugars(null);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}