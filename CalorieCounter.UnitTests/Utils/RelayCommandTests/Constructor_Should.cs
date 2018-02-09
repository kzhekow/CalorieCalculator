using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CalorieCounter.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalorieCounter.UnitTests.Utils.RelayCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowArgumentNullException_WhenMethodDelegateIsNull()
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() => new RelayCommand(null));
        }

        [TestMethod]
        public void CreateInstance_WhenInvokedWithValidParameters()
        {
            // Arrange & Act
            var rc = new RelayCommand(a => {});

            // Assert
            Assert.IsNotNull(rc);
            Assert.IsInstanceOfType(rc, typeof(ICommand));
        }
    }
}
