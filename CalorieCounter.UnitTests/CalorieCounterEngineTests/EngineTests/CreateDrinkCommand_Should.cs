using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using CalorieCounter.UnitTests.Builders;
using CalorieCounterEngine.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace CalorieCounter.UnitTests.CalorieCounterEngineTests.EngineTests
{
    [TestClass]
    public class CreateDrinkCommand_Should
    {
        private Mock<IDataRepository> dataRepositoryMock;
        private Mock<IJsonSerializer> jsonSerializerMock;
        private Dictionary<string, IProduct> productCollection;
        private Mock<IProductFactory> productFactoryMock;
        private Mock<IProduct> drinkMock;

        [TestInitialize]
        public void Setup()
        {
            this.productCollection = new Dictionary<string, IProduct>();
            this.jsonSerializerMock = new Mock<IJsonSerializer>();
            this.dataRepositoryMock = new Mock<IDataRepository>();
            this.dataRepositoryMock.SetupGet(x => x.Products).Returns(this.productCollection);
            this.productFactoryMock = new Mock<IProductFactory>();
            this.drinkMock = new Mock<IProduct>();
            this.drinkMock.Setup(x => x.Name).Returns("mockName");
        }

        [TestMethod]
        public void CallsCreateDrink_WithCorrectParameters()
        {
            // Arrange
            var name = "Bozichka";
            var caloriesPer100g = 150;
            var proteinPer100g = 1;
            var carbsPer100g = 23;
            var fatsPer100g = 12;

            this.productFactoryMock
                .Setup(x => x.CreateDrink(name, caloriesPer100g, proteinPer100g, carbsPer100g, fatsPer100g, 0, 0))
                .Returns(drinkMock.Object);
            var engine = new EngineBuilder().WithDataRepository(this.dataRepositoryMock.Object)
                .WithProductFactory(this.productFactoryMock.Object).Build();
            var args = new object[] { name, caloriesPer100g, proteinPer100g, carbsPer100g, fatsPer100g };

            //Act

            engine.CreateDrinkCommand.Execute(args);

            //Assert
            this.productFactoryMock.Verify(
                x => x.CreateDrink(name, caloriesPer100g, proteinPer100g, carbsPer100g, fatsPer100g, 0, 0), Times.Once);
        }

        [TestMethod]
        public void CallsSaveProgress_WithCorrectParameters()
        {
            // Arrange
            var name = "Bozichka";
            var caloriesPer100g = 150;
            var proteinPer100g = 1;
            var carbsPer100g = 23;
            var fatsPer100g = 12;

            this.productFactoryMock
                .Setup(x => x.CreateDrink(name, caloriesPer100g, proteinPer100g, carbsPer100g, fatsPer100g, 0, 0))
                .Returns(this.drinkMock.Object);
            var engine = new EngineBuilder().WithJsonSerializer(this.jsonSerializerMock.Object)
                .WithDataRepository(this.dataRepositoryMock.Object)
                .WithProductFactory(this.productFactoryMock.Object).Build();
            var args = new object[] { name, caloriesPer100g, proteinPer100g, carbsPer100g, fatsPer100g };
            //Act
            engine.CreateDrinkCommand.Execute(args);
            //Assert
            this.jsonSerializerMock.Verify(x => x.SaveAllProducts(this.productCollection), Times.Once);
        }
    }
}