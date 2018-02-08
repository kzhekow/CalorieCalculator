using CalorieCounter.Models.Contracts;
using CalorieCounter.Models.GoalModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalorieCounter.UnitTests.Models.GoalModel.GoalTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            // Arrange
            var startingWeight = 82;
            var goalWeight = 78;
            var height = 177;
            var age = 25;
            var gender = GenderType.male;
            var goalType = GoalType.loseweight;
            var activityLevel = ActivityLevel.heavy;

            // Act
            var goal = new Goal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel);

            // Assert
            Assert.IsNotNull(goal);
            Assert.IsInstanceOfType(goal, typeof(IGoal));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenStartingWeightIsNegative()
        {
            // Arrange
            var startingWeight = -5;
            var goalWeight = 78;
            var height = 177;
            var age = 25;
            var gender = GenderType.male;
            var goalType = GoalType.loseweight;
            var activityLevel = ActivityLevel.heavy;

            // Act
            Assert.ThrowsException<ArgumentException>(() => new Goal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenGoalWeightIsNegative()
        {
            // Arrange
            var startingWeight = 82;
            var goalWeight = -5;
            var height = 177;
            var age = 25;
            var gender = GenderType.male;
            var goalType = GoalType.loseweight;
            var activityLevel = ActivityLevel.heavy;

            // Act
            Assert.ThrowsException<ArgumentException>(() => new Goal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenHeightIsNegative()
        {
            // Arrange
            var startingWeight = 82;
            var goalWeight = 78;
            var height = -5;
            var age = 25;
            var gender = GenderType.male;
            var goalType = GoalType.loseweight;
            var activityLevel = ActivityLevel.heavy;

            // Act
            Assert.ThrowsException<ArgumentException>(() => new Goal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenAgeIsNegative()
        {
            // Arrange
            var startingWeight = 82;
            var goalWeight = 78;
            var height = 177;
            var age = -5;
            var gender = GenderType.male;
            var goalType = GoalType.loseweight;
            var activityLevel = ActivityLevel.heavy;

            // Act
            Assert.ThrowsException<ArgumentException>(() => new Goal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel));
        }
    }
}
