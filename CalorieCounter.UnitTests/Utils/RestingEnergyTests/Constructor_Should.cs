using System;
using CalorieCounter.Models.Contracts;
using CalorieCounterEngine.Contracts;
using CalorieCounterEngine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.RestingEnergyTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenInvokedWithValidGoalParameter()
        {
            // Arrange
            var goalMock = new Mock<IGoal>();

            // Act
            var restingEnergy = new RestingEnergyCalculator();

            // Assert
            Assert.IsNotNull(restingEnergy);
            Assert.IsInstanceOfType(restingEnergy, typeof(IRestingEnergyCalculator));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenIvokedWithNullGoalParameter()
        {
            // Arrange
            //var goalMock = new Mock<IGoal>();

            // Act
            Assert.ThrowsException<ArgumentNullException>(() =>
                new RestingEnergyCalculator().CalculateRestingEnergy(null));
        }
    }
}