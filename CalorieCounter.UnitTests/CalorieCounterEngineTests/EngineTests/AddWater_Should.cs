using CalorieCounter.Models.Contracts;
using CalorieCounter.UnitTests.Builders;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.CalorieCounterEngineTests.EngineTests
{
    [TestClass]
    public class AddWater_Should
    {
        [TestMethod]
        public void CallsAddWater_WhenInvokedWithCorrectParams()
        {
            var mililiters = 350;

            var jsonSerializerMock = new Mock<IJsonSerializer>();
            var dailyIntakeMock = new Mock<IDailyIntake>();
            jsonSerializerMock.Setup(x => x.GetDailyIntake()).Returns(dailyIntakeMock.Object);

            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object).Build();
            var args = new object[] {mililiters};
            engine.AddWaterCommand.Execute(args);

            dailyIntakeMock.Verify(x => x.AddWater(mililiters), Times.Once);
        }
    }
}