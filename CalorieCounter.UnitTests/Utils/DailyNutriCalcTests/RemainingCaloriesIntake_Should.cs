using CalorieCounter.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Models.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CalorieCounter.UnitTests.Utils.DailyNutriCalcTests
{
    [TestClass]
    public class RemainingCaloriesIntake_Should
    {
        [TestMethod]
        public void ReturnRemainingCaloriesIntake_WhenInvokedWithAllValidParameters()
        {
            // Arrange
            var suggestedDailyCaloriesIntake = 2500;

            var firstProduct = new Mock<IProduct>();
            var secondProduct = new Mock<IProduct>();
            var activityMock = new Mock<IActivity>();

            firstProduct
                .SetupGet(m => m.Calories)
                .Returns(320);

            secondProduct
               .SetupGet(m => m.Calories)
               .Returns(450);

            activityMock
                .Setup(m => m.CalculateBurnedCalories())
                .Returns(270);

            var expectedResult = 2000; // 2500 - 770  + 270

            ICollection<IProduct> productConsumed = new List<IProduct>() { firstProduct.Object, secondProduct.Object };
            ICollection<IActivity> activities = new List<IActivity>() { activityMock.Object };

            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingCaloriesIntake(suggestedDailyCaloriesIntake, productConsumed, activities);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnRemainingCaloriesIntake_WhenActivityIsNull()
        {
            // Arrange
            var suggestedDailyCaloriesIntake = 2500;

            var firstProduct = new Mock<IProduct>();
            var secondProduct = new Mock<IProduct>();

            firstProduct
                .SetupGet(m => m.Calories)
                .Returns(320);

            secondProduct
               .SetupGet(m => m.Calories)
               .Returns(450);

            var expectedResult = 1730; // 2500 - 770 

            ICollection<IProduct> productConsumed = new List<IProduct>() { firstProduct.Object, secondProduct.Object };

            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingCaloriesIntake(suggestedDailyCaloriesIntake, productConsumed);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnSuggestedCaloriesIntake_WhenActivityAndProductsConsumedAreNull()
        {
            // Arrange
            var suggestedDailyCaloriesIntake = 2500;
            var expectedResult = suggestedDailyCaloriesIntake;

            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingCaloriesIntake(suggestedDailyCaloriesIntake, null);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnRemainingCaloriesIntake_WhenProductsConsumedAreNull()
        {
            // Arrange
            var suggestedDailyCaloriesIntake = 2500;

            var activityMock = new Mock<IActivity>();

            activityMock
                .Setup(m => m.CalculateBurnedCalories())
                .Returns(270);

            var expectedResult = 2770; // 2500 + 270

            ICollection<IActivity> activities = new List<IActivity>() { activityMock.Object };
            var dailyNutriCalcMock = new DailyNutriCalc();

            // Act
            var actualResult = dailyNutriCalcMock.RemainingCaloriesIntake(suggestedDailyCaloriesIntake, null, activities);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
