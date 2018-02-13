using CalorieCounter.Contracts;
using CalorieCounter.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Factories.ProductFactoryTests
{
    [TestClass]
    public class CreateFoodProduct_Should
    {
        [TestMethod]
        public void CreateInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var name = "Skyr";
            var calories = 62;
            var protein = 11;
            var carbs = 4;
            var fat = 0;
            var sugar = 3;
            var fiber = 0;

            var productFactory = new ProductFactory();

            // Act
            var foodProduct = productFactory.CreateFoodProduct(name, calories, protein, carbs, fat, sugar, fiber);

            // Assert
            Assert.IsNotNull(foodProduct);
            Assert.IsInstanceOfType(foodProduct, typeof(IProduct));
        }
    }
}