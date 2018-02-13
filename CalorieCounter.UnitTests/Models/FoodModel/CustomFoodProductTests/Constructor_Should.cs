using System;
using CalorieCounter.Contracts;
using CalorieCounter.Models.FoodModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Models.FoodModel.CustomFoodProductTests
{
    [TestClass]
    public class Constructor_Should
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

            // Act
            var drink = new CustomFoodProduct(name, calories, protein, carbs, fat, sugar, fiber);

            // Assert
            Assert.IsNotNull(drink);
            Assert.IsInstanceOfType(drink, typeof(IProduct));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenNameIsNull()
        {
            // Arrange
            string name = null;
            var calories = 62;
            var protein = 11;
            var carbs = 4;
            var fat = 0;
            var sugar = 3;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new CustomFoodProduct(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenCaloriesAreNegative()
        {
            // Arrange
            var name = "Skyr";
            var calories = -5;
            var protein = 11;
            var carbs = 4;
            var fat = 0;
            var sugar = 3;
            var fiber = 0;


            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomFoodProduct(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenProteinIsNegative()
        {
            // Arrange
            var name = "Skyr";
            var calories = 62;
            var protein = -5;
            var carbs = 4;
            var fat = 0;
            var sugar = 3;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomFoodProduct(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenCarbsAreNegative()
        {
            // Arrange
            var name = "Skyr";
            var calories = 62;
            var protein = 11;
            var carbs = -5;
            var fat = 0;
            var sugar = 3;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomFoodProduct(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenFatIsNegative()
        {
            // Arrange
            var name = "Skyr";
            var calories = 62;
            var protein = 11;
            var carbs = 4;
            var fat = -5;
            var sugar = 3;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomFoodProduct(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenSugarIsNegative()
        {
            // Arrange
            var name = "Skyr";
            var calories = 62;
            var protein = 11;
            var carbs = 4;
            var fat = 0;
            var sugar = -5;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomFoodProduct(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenFiberIsNegative()
        {
            // Arrange
            var name = "Skyr";
            var calories = 62;
            var protein = 11;
            var carbs = 4;
            var fat = 0;
            var sugar = 3;
            var fiber = -5;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomFoodProduct(name, calories, protein, carbs, fat, sugar, fiber));
        }
    }
}