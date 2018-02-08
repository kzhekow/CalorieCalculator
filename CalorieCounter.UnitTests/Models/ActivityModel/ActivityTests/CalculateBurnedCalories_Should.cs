using CalorieCounter.Models.ActivityModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Models.ActivityModel.ActivityTests
{
    [TestClass]
    public class CalculateBurnedCalories_Should
    {
        [TestMethod]
        public void ReturnCorrectResult_WhenParametersAreCorrect()
        {
            // Arrange
            var time = 90;
            var type = 606;
            var expectedResult = 909;

            var activity = new Activity(time, ActivityType.cardio);

            // Act
            var actualResult = activity.CalculateBurnedCalories();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
