using System;
using CalorieCounter.Models;
using CalorieCounter.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Models.DailyIntakeTests
{
    [TestClass]
    public class RemoveActivity_Should
    {
        [TestMethod]
        public void RemoveActivity_WhenArgumentIsPresentInCollection()
        {
            // Arrange
            var activity = new Mock<IActivity>();
            var dailyIntake = new DailyIntake();
            dailyIntake.AddActivity(activity.Object);

            // Act
            dailyIntake.RemoveActivity(activity.Object);

            // Assert
            Assert.IsFalse(dailyIntake.ActivitiesPerformed.Contains(activity.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNull()
        {
            // Arrange
            IActivity activity = null;
            var dailyIntake = new DailyIntake();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dailyIntake.RemoveActivity(activity));
        }
    }
}