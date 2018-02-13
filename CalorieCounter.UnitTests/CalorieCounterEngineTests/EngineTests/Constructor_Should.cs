using System;
using System.Collections.Generic;
using CalorieCounter.Contracts;
using CalorieCounter.UnitTests.Builders;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.CalorieCounterEngineTests.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParametersAreCorrect()
        {
            //// Arrange
            //var productFactoryMock = new Mock<IProductFactory>();
            //var activityFactoryMock = new Mock<IActivityFactory>();
            //var goalFactoryMock = new Mock<IGoalFactory>();
            //var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            //var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            //// Act
            //var engine = new Engine
            //    (productFactoryMock.Object,
            //    activityFactoryMock.Object,
            //    goalFactoryMock.Object,
            //    dailyNutriCalcMock.Object,
            //    restingEnergyMock.Object
            //    );

            //// Assert
            //Assert.IsInstanceOfType(engine, typeof(IEngine));

            var jsonSerializerMock = new Mock<IJsonSerializer>();
            jsonSerializerMock.Setup(x => x.GetProducts()).Returns(new List<IProduct>());
            Assert.IsInstanceOfType(new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object).Build(),
                typeof(IEngine));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenProductFactoryIsNull()
        {
            // Arrange
            //var productFactoryMock = new Mock<IProductFactory>();
            //var activityFactoryMock = new Mock<IActivityFactory>();
            //var goalFactoryMock = new Mock<IGoalFactory>();
            //var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            //var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            //// Act && Assert
            //Assert.ThrowsException<ArgumentNullException>(() => new Engine
            //    (null,
            //    activityFactoryMock.Object,
            //    goalFactoryMock.Object,
            //    dailyNutriCalcMock.Object,
            //    restingEnergyMock.Object));

            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EngineBuilder().WithProductFactory(null).Build());
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenActivityFactoryIsNull()
        {
            // // Arrange
            // var productFactoryMock = new Mock<IProductFactory>();
            ////var activityFactoryMock = new Mock<IActivityFactory>();
            // var goalFactoryMock = new Mock<IGoalFactory>();
            // var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            // var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            // // Act && Assert
            // Assert.ThrowsException<ArgumentNullException>(() => new Engine
            //     (productFactoryMock.Object,
            //     null,
            //     goalFactoryMock.Object,
            //     dailyNutriCalcMock.Object,
            //     restingEnergyMock.Object));

            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EngineBuilder().WithActivityFactory(null).Build());
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenGoalFactoryIsNull()
        {
            //// Arrange
            //var productFactoryMock = new Mock<IProductFactory>();
            //var activityFactoryMock = new Mock<IActivityFactory>();
            ////var goalFactoryMock = new Mock<IGoalFactory>();
            //var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            //var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            //// Act && Assert
            //Assert.ThrowsException<ArgumentNullException>(() => new Engine
            //    (productFactoryMock.Object,
            //    activityFactoryMock.Object,
            //    null,
            //    dailyNutriCalcMock.Object,
            //    restingEnergyMock.Object));

            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EngineBuilder().WithGoalFactory(null).Build());
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenDailyNutriCalcIsNull()
        {
            //// Arrange
            //var productFactoryMock = new Mock<IProductFactory>();
            //var activityFactoryMock = new Mock<IActivityFactory>();
            //var goalFactoryMock = new Mock<IGoalFactory>();
            ////var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            //var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            //// Act && Assert
            //Assert.ThrowsException<ArgumentNullException>(() => new Engine
            //    (productFactoryMock.Object,
            //    activityFactoryMock.Object,
            //    goalFactoryMock.Object,
            //    null,
            //    restingEnergyMock.Object));

            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EngineBuilder().WithDailyNutriCalc(null).Build());
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenRestingEnergyIsNull()
        {
            //// Arrange
            //var productFactoryMock = new Mock<IProductFactory>();
            //var activityFactoryMock = new Mock<IActivityFactory>();
            //var goalFactoryMock = new Mock<IGoalFactory>();
            //var dailyNutriCalcMock = new Mock<IDailyNutriCalc>();
            ////var restingEnergyMock = new Mock<IRestingEnergyCalculator>();

            //// Act && Assert
            //Assert.ThrowsException<ArgumentNullException>(() => new Engine
            //    (productFactoryMock.Object,
            //    activityFactoryMock.Object,
            //    goalFactoryMock.Object,
            //    dailyNutriCalcMock.Object,
            //    null));

            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new EngineBuilder().WithRestingEnergyCalculator(null).Build());
        }
    }
}