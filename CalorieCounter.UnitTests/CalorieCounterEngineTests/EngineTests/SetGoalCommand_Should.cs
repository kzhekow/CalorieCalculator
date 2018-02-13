using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.UnitTests.Builders;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.CalorieCounterEngineTests.EngineTests
{
    [TestClass]
    public class SetGoalCommand_Should
    {
        [TestMethod]
        public void CallCreateGoal_WhenInputIsCorrect()
        {
            var jsonSerializerMock = new Mock<IJsonSerializer>();
            var dailyIntakeMock = new Mock<IDailyIntake>();
            jsonSerializerMock.Setup(x => x.GetDailyIntake()).Returns(dailyIntakeMock.Object);
            var goalFactoryMock = new Mock<IGoalFactory>();
            var startingWeight = (double)68;
            var goalWeight = (double)80;
            var height = (double)178;
            var age = (int)21;
            var gender = GenderType.male;
            var goalType = GoalType.gainweight;
            var activityLevel = ActivityLevel.moderate;

            var goalmockMock = new Mock<IGoal>();
            goalFactoryMock.Setup(x => x.CreateGoal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel)).Returns(goalmockMock.Object);
            var args = new object[] {startingWeight, goalWeight, height, age, gender, goalType, activityLevel};
            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object)
                .WithGoalFactory(goalFactoryMock.Object).Build();
            engine.SetGoalCommand.Execute(args);
            goalFactoryMock.Verify(x => x.CreateGoal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel), Times.Once);
        }

        [TestMethod]
        public void CallDailyIntakeGoalSetterWithCorrectArgument_WhenInputIsCorrect()
        {
            var jsonSerializerMock = new Mock<IJsonSerializer>();
            var dailyIntakeMock = new Mock<IDailyIntake>();
            jsonSerializerMock.Setup(x => x.GetDailyIntake()).Returns(dailyIntakeMock.Object);
            var goalFactoryMock = new Mock<IGoalFactory>();
            var startingWeight = (double)68;
            var goalWeight = (double)80;
            var height = (double)178;
            var age = (int)21;
            var gender = GenderType.male;
            var goalType = GoalType.gainweight;
            var activityLevel = ActivityLevel.moderate;

            var goalMock = new Mock<IGoal>();
            goalFactoryMock.Setup(x => x.CreateGoal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel)).Returns(goalMock.Object);
            var args = new object[] { startingWeight, goalWeight, height, age, gender, goalType, activityLevel };
            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object)
                .WithGoalFactory(goalFactoryMock.Object).Build();
            dailyIntakeMock.SetupSet(x => x.Goal = goalMock.Object).Verifiable();
            engine.SetGoalCommand.Execute(args);
            dailyIntakeMock.VerifySet(x => x.Goal = goalMock.Object);
        }

        [TestMethod]
        public void CallSaveDailyIntake_WhenInputIsCorrect()
        {
            var jsonSerializerMock = new Mock<IJsonSerializer>();
            var dailyIntakeMock = new Mock<IDailyIntake>();
            jsonSerializerMock.Setup(x => x.GetDailyIntake()).Returns(dailyIntakeMock.Object);
            var goalFactoryMock = new Mock<IGoalFactory>();
            var startingWeight = (double)68;
            var goalWeight = (double)80;
            var height = (double)178;
            var age = (int)21;
            var gender = GenderType.male;
            var goalType = GoalType.gainweight;
            var activityLevel = ActivityLevel.moderate;

            var goalMock = new Mock<IGoal>();
            goalFactoryMock.Setup(x => x.CreateGoal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel)).Returns(goalMock.Object);
            var args = new object[] { startingWeight, goalWeight, height, age, gender, goalType, activityLevel };
            var engine = new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object)
                .WithGoalFactory(goalFactoryMock.Object).Build();
            engine.SetGoalCommand.Execute(args);
            jsonSerializerMock.Verify(x => x.SaveDailyIntake(dailyIntakeMock.Object), Times.Once);
        }
    }
}
