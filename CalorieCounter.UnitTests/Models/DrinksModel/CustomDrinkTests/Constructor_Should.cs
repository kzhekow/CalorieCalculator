using System;
using CalorieCounter.Contracts;
using CalorieCounter.Models.DrinksModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Models.DrinksModel.CustomDrinkTests
{
    [TestClass]
    public class Constructor_Should
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

            // Act
            var drink = new CustomDrink(name, calories, protein, carbs, fat, sugar, fiber);

            // Assert
            Assert.IsNotNull(drink);
            Assert.IsInstanceOfType(drink, typeof(IProduct));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenNameIsNull()
        {
            // Arrange
            string name = null;
            var calories = 109;
            var protein = 25;
            var carbs = 0;
            var fat = 1;
            var sugar = 1;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new CustomDrink(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenCaloriesAreNegative()
        {
            // Arrange
            var name = "ProteinShake";
            var calories = -5;
            var protein = 25;
            var carbs = 0;
            var fat = 1;
            var sugar = 1;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomDrink(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenProteinIsNegative()
        {
            // Arrange
            var name = "ProteinShake";
            var calories = 109;
            var protein = -5;
            var carbs = 0;
            var fat = 1;
            var sugar = 1;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomDrink(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenCarbsAreNegative()
        {
            // Arrange
            var name = "ProteinShake";
            var calories = 109;
            var protein = 25;
            var carbs = -5;
            var fat = 1;
            var sugar = 1;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomDrink(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenFatIsNegative()
        {
            // Arrange
            var name = "ProteinShake";
            var calories = 109;
            var protein = 25;
            var carbs = 0;
            var fat = -5;
            var sugar = 1;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomDrink(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenSugarIsNegative()
        {
            // Arrange
            var name = "ProteinShake";
            var calories = 109;
            var protein = 25;
            var carbs = 0;
            var fat = 1;
            var sugar = -5;
            var fiber = 0;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomDrink(name, calories, protein, carbs, fat, sugar, fiber));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenFiberIsNegative()
        {
            // Arrange
            var name = "ProteinShake";
            var calories = 109;
            var protein = 25;
            var carbs = 0;
            var fat = 1;
            var sugar = -5;
            var fiber = -5;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() =>
                new CustomDrink(name, calories, protein, carbs, fat, sugar, fiber));
        }
    }
}