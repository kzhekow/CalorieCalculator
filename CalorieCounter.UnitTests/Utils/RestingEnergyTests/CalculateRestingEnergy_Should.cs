using CalorieCounter.Models.Contracts;
using CalorieCounterEngine.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.RestingEnergyTests
{
    [TestClass]
    public class CalculateRestingEnergy_Should
    {
        [TestMethod]
        public void ReturnTheCorrectValue_WhenGenderIsSetToMale()
        {
            // Arrange
            var expectedResult = 1623.75;
            var goalMock = new Mock<IGoal>();

            goalMock
                .SetupGet(m => m.Gender)
                .Returns(GenderType.male);

            goalMock
                .SetupGet(m => m.StartingWeight)
                .Returns(65);

            goalMock
                .SetupGet(m => m.Height)
                .Returns(175);

            goalMock
                .SetupGet(m => m.Age)
                .Returns(25);

            var restingEnergy = new RestingEnergy(goalMock.Object);

            // Act
            var actualResult = restingEnergy.CalculateRestingEnergy();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnTheCorrectValue_WhenGenderIsSetToFemale()
        {
            // Arrange
            var expectedResult = 1457.75;
            var goalMock = new Mock<IGoal>();

            goalMock
                .SetupGet(m => m.Gender)
                .Returns(GenderType.female);

            goalMock
                .SetupGet(m => m.StartingWeight)
                .Returns(65);

            goalMock
                .SetupGet(m => m.Height)
                .Returns(175);

            goalMock
                .SetupGet(m => m.Age)
                .Returns(25);

            var restingEnergy = new RestingEnergy(goalMock.Object);

            // Act
            var actualResult = restingEnergy.CalculateRestingEnergy();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
