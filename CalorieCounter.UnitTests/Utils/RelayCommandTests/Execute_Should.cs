using CalorieCounter.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CalorieCounter.UnitTests.Utils.RelayCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ExecuteDelegate()
        {
            // Arrange
            //var action = new Mock<Action<object>>();
            //action.Setup(a => a.Invoke(It.IsAny<object>())).Callback((object a) =>
            //{
            //    Assert.IsTrue(true);
            //});
            //Action<object> action = ((a) =>
            //{
            //    Assert.IsTrue(true);
            //});

            // grozna shema
            bool executed = false;
            Action<object> action = o => { executed = true; };

            var relayCommand = new RelayCommand(action);

            // Act 
            relayCommand.Execute(It.IsAny<object>());

            // Assert
            Assert.IsTrue(executed);
        }
    }
}
