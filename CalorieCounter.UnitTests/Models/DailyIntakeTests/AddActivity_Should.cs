using System;
using CalorieCounter.Models;
using CalorieCounter.Models.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Models.DailyIntakeTests
{
    [TestClass]
    public class AddActivity_Should
    {
        [TestMethod]
        public void AddActivity_WhenArgumentIsNotNull()
        {
            // Arrange
            var activity = new Mock<IActivity>();
            var dailyIntake = new DailyIntake();

            // Act
            dailyIntake.AddActivity(activity.Object);

            // Assert
            Assert.IsTrue(dailyIntake.ActivitiesPerformed.Contains(activity.Object));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenArgumentIsNull()
        {
            // Arrange
            IActivity activity = null;
            var dailyIntake = new DailyIntake();

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => dailyIntake.AddActivity(activity));
        }
    }
}