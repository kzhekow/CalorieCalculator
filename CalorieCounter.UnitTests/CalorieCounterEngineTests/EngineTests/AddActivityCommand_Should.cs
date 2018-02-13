using System;
using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.UnitTests.Builders;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.CalorieCounterEngineTests.EngineTests
{
    [TestClass]
    public class AddActivityCommand_Should
    {
        [TestMethod]
        public void CallCreateActivityWithCorrectArguments_WithCorrectInput()
        {
            var jsonSerializerMock = new Mock<IJsonSerializer>();
            var dailyIntakeMock = new Mock<IDailyIntake>();
            jsonSerializerMock.Setup(x => x.GetDailyIntake()).Returns(dailyIntakeMock.Object);
            var activityFactoryMock = new Mock<IActivityFactory>();

            var activityType = ActivityType.cardio;
            var time = 123;
            var activityMock = new Mock<IActivity>();
            activityFactoryMock.Setup(x => x.CreateActivity(time, activityType)).Returns(activityMock.Object);
            var args = new object[] {activityType.ToString(), time};
            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object)
                .WithActivityFactory(activityFactoryMock.Object).Build();
            engine.AddActivityCommand.Execute(args);
            activityFactoryMock.Verify(x => x.CreateActivity(time, activityType), Times.Once);
        }

        [TestMethod]
        public void CallAddActivityWithCorrectArguments_WithCorrectInput()
        {
            var jsonSerializerMock = new Mock<IJsonSerializer>();
            var dailyIntakeMock = new Mock<IDailyIntake>();
            jsonSerializerMock.Setup(x => x.GetDailyIntake()).Returns(dailyIntakeMock.Object);
            var activityFactoryMock = new Mock<IActivityFactory>();

            var activityType = ActivityType.cardio;
            var time = 123;
            var activityMock = new Mock<IActivity>();
            activityFactoryMock.Setup(x => x.CreateActivity(time, activityType)).Returns(activityMock.Object);
            var args = new object[] {activityType.ToString(), time};
            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object)
                .WithActivityFactory(activityFactoryMock.Object).Build();
            engine.AddActivityCommand.Execute(args);
            dailyIntakeMock.Verify(x => x.AddActivity(activityMock.Object), Times.Once);
        }

        [TestMethod]
        public void CallSave_WithCorrectInput()
        {
            var jsonSerializerMock = new Mock<IJsonSerializer>();
            var dailyIntakeMock = new Mock<IDailyIntake>();
            jsonSerializerMock.Setup(x => x.GetDailyIntake()).Returns(dailyIntakeMock.Object);
            var activityFactoryMock = new Mock<IActivityFactory>();

            var activityType = ActivityType.cardio;
            var time = 123;
            var activityMock = new Mock<IActivity>();
            activityFactoryMock.Setup(x => x.CreateActivity(time, activityType)).Returns(activityMock.Object);
            var args = new object[] {activityType.ToString(), time};
            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object)
                .WithActivityFactory(activityFactoryMock.Object).Build();
            engine.AddActivityCommand.Execute(args);
            jsonSerializerMock.Verify(x => x.SaveDailyIntake(dailyIntakeMock.Object), Times.Once);
        }

        [TestMethod]
        public void ThrowsArgumentOutOfRangeException_WhenTimeIsNegative()
        {
            var jsonSerializerMock = new Mock<IJsonSerializer>();
            var dailyIntakeMock = new Mock<IDailyIntake>();
            jsonSerializerMock.Setup(x => x.GetDailyIntake()).Returns(dailyIntakeMock.Object);
            var activityFactoryMock = new Mock<IActivityFactory>();

            var activityType = ActivityType.cardio;
            var time = -123;
            var activityMock = new Mock<IActivity>();
            activityFactoryMock.Setup(x => x.CreateActivity(time, activityType)).Returns(activityMock.Object);
            var args = new object[] {activityType.ToString(), time};
            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object)
                .WithActivityFactory(activityFactoryMock.Object).Build();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => engine.AddActivityCommand.Execute(args));
        }


        [TestMethod]
        public void ThrowsArgumentException_WhenActivityTypeIsWrong()
        {
            var jsonSerializerMock = new Mock<IJsonSerializer>();
            var dailyIntakeMock = new Mock<IDailyIntake>();
            jsonSerializerMock.Setup(x => x.GetDailyIntake()).Returns(dailyIntakeMock.Object);
            var activityFactoryMock = new Mock<IActivityFactory>();

            var activityType = ActivityType.strength;
            var time = 123;
            var activityMock = new Mock<IActivity>();
            activityFactoryMock.Setup(x => x.CreateActivity(time, activityType)).Returns(activityMock.Object);
            var args = new object[] {"incorrect activity type", time};
            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object)
                .WithActivityFactory(activityFactoryMock.Object).Build();
            Assert.ThrowsException<ArgumentException>(() => engine.AddActivityCommand.Execute(args));
        }
    }
}