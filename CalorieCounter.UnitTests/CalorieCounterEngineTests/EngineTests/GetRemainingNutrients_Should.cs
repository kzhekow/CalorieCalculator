using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using CalorieCounter.UnitTests.Builders;
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
            var expectedMessage = "Goal has not been set!";
            var jsonSerializerMock = new Mock<IJsonSerializer>();
            jsonSerializerMock.Setup(x => x.GetProducts()).Returns(new List<IProduct>());

            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object).Build();

            // Act && Assert
            Assert.AreEqual(expectedMessage, engine.GetRemainingNutrients());
        }
    }
}
