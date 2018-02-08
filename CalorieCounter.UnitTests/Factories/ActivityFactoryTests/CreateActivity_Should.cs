using CalorieCounter.Factories;
using CalorieCounter.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Factories.ActivityFactoryTests
{
    [TestClass]
    public class CreateActivity_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            // Arrange
            var time = 60;
            var activityType = ActivityType.strength;

            var activityFactory = new ActivityFactory();

            // Act
            var activity = activityFactory.CreateActivity(time, activityType);

            // Assert
            Assert.IsNotNull(activity);
            Assert.IsInstanceOfType(activity, typeof(IActivity));
        }
    }
}
