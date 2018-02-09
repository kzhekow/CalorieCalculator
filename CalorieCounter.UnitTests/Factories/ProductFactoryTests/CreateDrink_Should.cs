using CalorieCounter.Contracts;
using CalorieCounter.Factories;
using CalorieCounter.Models.DrinksModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Factories.ProductFactoryTests
{
    [TestClass]
    public class CreateDrink_Should
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var name = "ProteinShake";
            var calories = 109;
            var protein = 25;
            var carbs = 0;
            var fat = 1;
            var sugar = 1;
            var fiber = 0;

            var poductFactory = new ProductFactory();

            // Act
            var drink = poductFactory.CreateDrink(name, calories, protein, carbs, fat, sugar, fiber);

            // Assert
            Assert.IsNotNull(drink);
            Assert.IsInstanceOfType(drink, typeof(IProduct));
        }
    }
}
