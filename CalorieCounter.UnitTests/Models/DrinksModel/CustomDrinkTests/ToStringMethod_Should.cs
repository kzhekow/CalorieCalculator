using CalorieCounter.Models.DrinksModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Models.DrinksModel.CustomDrinkTests
{
    [TestClass]
    public class ToStringMethod_Should
    {
        [TestMethod]
        public void ReturnCorrectValue_WhenInvoked()
        {
            //Arrange
            var food = new CustomDrink("drinkName", 1, 1, 1, 1, 1, 1);
            var expectedResult = "drinkName 1 kcal 100 gr/ml 1 protein 1 carbs 1 fat 1 sugar 1 fiber";

            //Act
            var actualResult = food.ToString();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}