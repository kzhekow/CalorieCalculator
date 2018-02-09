using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CalorieCounter.UnitTests.Utils.RelayCommandTests
{
    [TestClass]
    public class CanExecute_Should
    {
        [TestMethod]
        public void ReturnsTrue_WhenConditionIsTrue()
        {
            // Arrange
            var action = new Mock<Action<object>>(); 
            var relayCommand = new RelayCommand(action.Object, a => true);

            // Act & Assert
            Assert.IsTrue(relayCommand.CanExecute(null));
        }

        [TestMethod]
        public void ReturnsFalse_WhenConditionIsFalse()
        {
            // Arrange
            var action = new Mock<Action<object>>(); 
            var relayCommand = new RelayCommand(action.Object, a => false);

            // Act & Assert
            Assert.IsFalse(relayCommand.CanExecute(null));
        }
    }
}
