using CalorieCounter.Contracts;
using CalorieCounter.Models.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CalorieCounter.UnitTests.Utils.DailyNutriCalcTests
{
    [TestClass]
    public class CurrentDayMacrosRatio_Should
    {
        [TestMethod]
        public void ReturnCurrentDayMacrosRation_WhenInvokedWithValidParameters()
        {
            // Arrange
            var firstProduct = new Mock<IProduct>();
            var secondProduct = new Mock<IProduct>();
            var thirdProduct = new Mock<IProduct>();

            firstProduct
                .SetupGet(m => m.Calories)
                .Returns(189);

            firstProduct
                .SetupGet(m => m.Protein)
                .Returns(20);

            firstProduct
               .SetupGet(m => m.Carbs)
               .Returns(25);

            firstProduct
               .SetupGet(m => m.Fat)
               .Returns(1);

            secondProduct
                .SetupGet(m => m.Calories)
                .Returns(305);

            secondProduct
                .SetupGet(m => m.Protein)
                .Returns(25);

            secondProduct
               .SetupGet(m => m.Carbs)
               .Returns(40);

            secondProduct
               .SetupGet(m => m.Fat)
               .Returns(5);

            thirdProduct
                .SetupGet(m => m.Calories)
                .Returns(410);

            thirdProduct
                .SetupGet(m => m.Protein)
                .Returns(8);

            thirdProduct
               .SetupGet(m => m.Carbs)
               .Returns(70);

            thirdProduct
               .SetupGet(m => m.Fat)
               .Returns(10);

            var dailyNutriCalc = new DailyNutriCalc();
            ICollection<IProduct> productsConsumed = new List<IProduct>() { firstProduct.Object, secondProduct.Object, thirdProduct.Object };

            var carbsCalories = 540;
            var proteinCalories = 212;
            var fatCalories = 144;

            var expectedResult = $"Carbs:Protein:Fat = {60}:{24}:{16}";

            // Act
            var actualResult = dailyNutriCalc.CurrentDayMacrosRatio(productsConsumed);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
