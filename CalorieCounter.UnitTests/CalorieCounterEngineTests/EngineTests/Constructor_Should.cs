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
            var restingEnergyMock = new Mock<IRestingEnergy>();

            // Act
            var engine = new Engine
                (productFactoryMock.Object,
                activityFactoryMock.Object,
                goalFactoryMock.Object,
                dailyNutriCalcMock.Object,
                restingEnergyMock.Object
                );

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
            var restingEnergyMock = new Mock<IRestingEnergy>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine
                (null,
                activityFactoryMock.Object,
                goalFactoryMock.Object,
                dailyNutriCalcMock.Object,
                restingEnergyMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenActivityFactoryIsNull()
        {
            // Arrange
            var productFactoryMock = new Mock<IProductFactory>();
           //var activityFactoryMock = new Mock<IActivityFactory>();
            var goalFactoryMock = new Mock<IGoalFactory>();
            var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine
                (productFactoryMock.Object,
                null,
                goalFactoryMock.Object,
                dailyNutriCalcMock.Object,
                restingEnergyMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenGoalFactoryIsNull()
        {
            // Arrange
            var productFactoryMock = new Mock<IProductFactory>();
            var activityFactoryMock = new Mock<IActivityFactory>();
            //var goalFactoryMock = new Mock<IGoalFactory>();
            var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine
                (productFactoryMock.Object,
                activityFactoryMock.Object,
                null,
                dailyNutriCalcMock.Object,
                restingEnergyMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenDailyNutriCalcIsNull()
        {
            // Arrange
            var productFactoryMock = new Mock<IProductFactory>();
            var activityFactoryMock = new Mock<IActivityFactory>();
            var goalFactoryMock = new Mock<IGoalFactory>();
            //var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            var restingEnergyMock = new Mock<IRestingEnergy>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine
                (productFactoryMock.Object,
                activityFactoryMock.Object,
                goalFactoryMock.Object,
                null,
                restingEnergyMock.Object));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenRestingEnergyIsNull()
        {
            // Arrange
            var productFactoryMock = new Mock<IProductFactory>();
            var activityFactoryMock = new Mock<IActivityFactory>();
            var goalFactoryMock = new Mock<IGoalFactory>();
            var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            //var restingEnergyMock = new Mock<IRestingEnergy>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new Engine
                (productFactoryMock.Object,
                activityFactoryMock.Object,
                goalFactoryMock.Object,
                dailyNutriCalcMock.Object,
                null));
        }
    }
}
