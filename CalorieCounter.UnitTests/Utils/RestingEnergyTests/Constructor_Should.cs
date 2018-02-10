﻿using CalorieCounter.Models.Contracts;
using CalorieCounterEngine.Contracts;
using CalorieCounterEngine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

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
            var restingEnergy = new RestingEnergy(goalMock.Object);

            // Assert
            Assert.IsNotNull(restingEnergy);
            Assert.IsInstanceOfType(restingEnergy, typeof(IRestingEnergy));
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenIvokedWithNullGoalParameter()
        {
            // Arrange
            //var goalMock = new Mock<IGoal>();

            // Act
            Assert.ThrowsException<ArgumentNullException>(() => new RestingEnergy(null));
        }
    }
}