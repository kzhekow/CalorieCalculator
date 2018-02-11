using CalorieCounter.Models.Contracts;
using CalorieCounter.Models.GoalModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CalorieCounter.UnitTests.Builders;

namespace CalorieCounter.UnitTests.Models.GoalModel.GoalTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            // Arrange & Act
            var goal = new GoalBuilder().Build();

            // Assert
            Assert.IsNotNull(goal);
            Assert.IsInstanceOfType(goal, typeof(IGoal));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenStartingWeightIsNegative()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new GoalBuilder().WithStartingWeight(-5).Build());
        }

        [TestMethod]
        public void ThrowArgumentException_WhenGoalWeightIsNegative()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new GoalBuilder().WithGoalWeight(-5).Build());
        }

        [TestMethod]
        public void ThrowArgumentException_WhenHeightIsNegative()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new GoalBuilder().WithHeight(-5).Build());
        }

        [TestMethod]
        public void ThrowArgumentException_WhenAgeIsNegative()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new GoalBuilder().WithAge(-5).Build());
        }
    }
}
