using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.UnitTests.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Models.GoalModel.GoalTests
{
    [TestClass]
    public class Properties_Should
    {
        [TestMethod]
        public void StartingWeightShouldReturnTheSettedValue_WhenParameterIsValid()
        {
            // Arrange & Act
            var rndNum = new Random().Next();
            var goal = new GoalBuilder().WithStartingWeight(rndNum).Build();

            // Assert
            Assert.AreEqual(rndNum, goal.StartingWeight);
        }

        [TestMethod]
        public void GoalWeightShouldReturnTheSettedValue_WhenParameterIsValid()
        {
            // Arrange & Act
            var rndNum = new Random().Next();
            var goal = new GoalBuilder().WithGoalWeight(rndNum).Build();

            // Assert
            Assert.AreEqual(rndNum, goal.GoalWeight);
        }

        [TestMethod]
        public void HeightShouldReturnTheSettedValue_WhenParameterIsValid()
        {
            // Arrange & Act
            var rndNum = new Random().Next();
            var goal = new GoalBuilder().WithHeight(rndNum).Build();

            // Assert
            Assert.AreEqual(rndNum, goal.Height);
        }

        [TestMethod]
        public void AgeShouldReturnTheSettedValue_WhenParameterIsValid()
        {
            // Arrange & Act
            var rndNum = new Random().Next();
            var goal = new GoalBuilder().WithAge(rndNum).Build();

            // Assert
            Assert.AreEqual(rndNum, goal.Age);
        }

        [TestMethod]
        public void GenderTypeShouldReturnTheSettedValue_WhenParameterIsValid()
        {
            // Arrange & Act
            var array = (GenderType[])Enum.GetValues(typeof(GenderType));
            var rndNum = new Random().Next(0, array.Length);
            var goal = new GoalBuilder().WithGenderType(array[rndNum]).Build();

            // Assert
            Assert.AreEqual(array[rndNum], goal.Gender);
        }

        [TestMethod]
        public void GoalTypeShouldReturnTheSettedValue_WhenParameterIsValid()
        {
            // Arrange & Act
            var array = (GoalType[])Enum.GetValues(typeof(GoalType));
            var rndNum = new Random().Next(0, array.Length);
            var goal = new GoalBuilder().WithGoalType(array[rndNum]).Build();

            // Assert
            Assert.AreEqual(array[rndNum], goal.GoalType);
        }

        [TestMethod]
        public void ActivityLevelShouldReturnTheSettedValue_WhenParameterIsValid()
        {
            // Arrange & Act
            var array = (ActivityLevel[])Enum.GetValues(typeof(ActivityLevel));
            var rndNum = new Random().Next(0, array.Length);
            var goal = new GoalBuilder().WithActivityLevel(array[rndNum]).Build();

            // Assert
            Assert.AreEqual(array[rndNum], goal.ActivityLevel);
        }
    }
}
