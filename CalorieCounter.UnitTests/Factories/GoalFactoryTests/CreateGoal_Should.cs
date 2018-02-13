using CalorieCounter.Factories;
using CalorieCounter.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Factories.GoalFactoryTests
{
    [TestClass]
    public class CreateGoal_Should
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

            var goalFactory = new GoalFactory();
            // Act
            var goal = goalFactory.CreateGoal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel);

            // Assert
            Assert.IsNotNull(goal);
            Assert.IsInstanceOfType(goal, typeof(IGoal));
        }
    }
}