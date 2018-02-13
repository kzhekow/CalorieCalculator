using CalorieCounter.Contracts;
using CalorieCounter.UnitTests.Builders;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace CalorieCounter.UnitTests.CalorieCounterEngineTests.EngineTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParametersAreCorrect()
        {
            // Arrange
            var jsonSerializerMock = new Mock<IJsonSerializer>();

            // Act
            jsonSerializerMock.Setup(x => x.GetProducts()).Returns(new List<IProduct>());

            // Assert
            Assert.IsInstanceOfType(new EngineBuilder().WithJsonSerializer(jsonSerializerMock.Object).Build(),
                typeof(IEngine));
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenProductFactoryIsNull()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EngineBuilder().WithProductFactory(null).Build());
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenActivityFactoryIsNull()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EngineBuilder().WithActivityFactory(null).Build());
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenGoalFactoryIsNull()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EngineBuilder().WithGoalFactory(null).Build());
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenDailyNutriCalcIsNull()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new EngineBuilder().WithDailyNutriCalc(null).Build());
        }

        [TestMethod]
        public void ThrowArgumentsNullException_WhenRestingEnergyIsNull()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                new EngineBuilder().WithRestingEnergyCalculator(null).Build());
        }
    }
}