﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalorieCounter.Models.FoodModel;

namespace CalorieCounter.UnitTests.Models.FoodModel.CustomFoodProductTests
{
    [TestClass]
    public class ToStringMethod_Should
    {
        [TestMethod]
        public void ReturnCorrectValue_WhenInvoked()
        {
            //Arrange
            var food = new CustomFoodProduct("productName", 1, 1, 1, 1, 1, 1);
            var expectedResult = "productName 1 kcal 100 gr/ml 1 protein 1 carbs 1 fat 1 sugar 1 fiber";

            //Act
            var actualResult = food.ToString();

            //Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
