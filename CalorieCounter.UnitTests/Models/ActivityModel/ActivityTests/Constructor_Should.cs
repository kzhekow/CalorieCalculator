using CalorieCounter.Models.ActivityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalorieCounter.UnitTests.Models.ActivityModel.ActivityTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            // Arrange
            var time = 60;
            var activityType = ActivityType.strength;

            // Act
            var activity = new Activity(time, activityType);

            // Assert
            Assert.IsNotNull(activity);
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidTimeParameter()
        {
            // Arrange
            var time = -5;
            var activityType = ActivityType.strength;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => new Activity(time, activityType));
        }

        [TestMethod]
        public void ThrowArgumentException_WhenInvokedWithInvalidActivityTypeParameter()
        {
            // Arrange
            var time = 5;
            var activityType = (ActivityType) 3;

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => new Activity(time, activityType));
        }
    }
}
