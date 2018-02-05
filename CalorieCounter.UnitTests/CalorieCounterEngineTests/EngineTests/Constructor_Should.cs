using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CalorieCounter.UnitTests.CalorieCounterEngineTests.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var productFactoryMock = new Mock<IProductFactory>();
            var activityFactoryMock = new Mock<IActivityFactory>();
            var goalFactoryMock = new Mock<IGoalFactory>();
            var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();

            // Act
            var engine = new Engine
                (productFactoryMock.Object,
                activityFactoryMock.Object,
                goalFactoryMock.Object,
                dailyNutriCalcMock.Object);

            // Assert
            Assert.IsInstanceOfType(engine, typeof(IEngine));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenProductFactoryIsNull()
        {
            // Arrange
            //var productFactoryMock = new Mock<IProductFactory>();
            var activityFactoryMock = new Mock<IActivityFactory>();
            var goalFactoryMock = new Mock<IGoalFactory>();
            var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine
                (null,
                activityFactoryMock.Object,
                goalFactoryMock.Object,
                dailyNutriCalcMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenActivityFactoryIsNull()
        {
            // Arrange
            var productFactoryMock = new Mock<IProductFactory>();
           //var activityFactoryMock = new Mock<IActivityFactory>();
            var goalFactoryMock = new Mock<IGoalFactory>();
            var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine
                (productFactoryMock.Object,
                null,
                goalFactoryMock.Object,
                dailyNutriCalcMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenGoalFactoryIsNull()
        {
            // Arrange
            var productFactoryMock = new Mock<IProductFactory>();
            var activityFactoryMock = new Mock<IActivityFactory>();
            //var goalFactoryMock = new Mock<IGoalFactory>();
            var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine
                (productFactoryMock.Object,
                activityFactoryMock.Object,
                null,
                dailyNutriCalcMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenDailyNutriCalcIsNull()
        {
            // Arrange
            var productFactoryMock = new Mock<IProductFactory>();
            var activityFactoryMock = new Mock<IActivityFactory>();
            var goalFactoryMock = new Mock<IGoalFactory>();
            //var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine
                (productFactoryMock.Object,
                activityFactoryMock.Object,
                goalFactoryMock.Object,
                null));
        }
    }
}
