using CalorieCounter.Factories.Contracts;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.CalorieCounterEngineTests.EngineTests
{
    [TestClass]
    public class GetRemainingNutrients_Should
    {
        [TestMethod]
        public void ReturnGoalNotSetMessage_WhenGoalHadNotBeenSet()
        {
            // Assert
            var productFactoryMock = new Mock<IProductFactory>();
            var activityFactoryMock = new Mock<IActivityFactory>();
            var goalFactoryMock = new Mock<IGoalFactory>();
            var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            var expectedMessage = "Goal has not been set!";

            var engine = new Engine
                (productFactoryMock.Object,
                activityFactoryMock.Object,
                goalFactoryMock.Object,
                dailyNutriCalcMock.Object);

            // Act && Assert
            Assert.AreEqual(expectedMessage, engine.GetRemainingNutrients());
        }
    }
}
