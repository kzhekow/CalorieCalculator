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
    public class CreateProductCommand_Should
    {
        private Mock<IDataRepository> dataRepositoryMock;
        private Mock<IJsonSerializer> jsonSerializerMock;
        private Dictionary<string, IProduct> productCollection;
        private Mock<IProductFactory> productFactoryMock;
        private Mock<IProduct> productMock;

        [TestInitialize]
        public void Setup()
        {
            this.productCollection = new Dictionary<string, IProduct>();
            this.jsonSerializerMock = new Mock<IJsonSerializer>();
            this.dataRepositoryMock = new Mock<IDataRepository>();
            this.dataRepositoryMock.Setup(x => x.Products).Returns(this.productCollection);
            this.productFactoryMock = new Mock<IProductFactory>();
            this.productMock = new Mock<IProduct>();
            this.productMock.Setup(x => x.Name).Returns("mockedName");
        }

        [TestMethod]
        public void CallsCreateProduct_WithCorrectParameters()
        {
            // Arrange
            var name = "Skyr";
            var caloriesPer100g = 100;
            var proteinPer100g = 14;
            var carbsPer100g = 4;
            var fatsPer100g = 0;

            this.productFactoryMock
                .Setup(x => x.CreateFoodProduct(name, caloriesPer100g, proteinPer100g, carbsPer100g, 0, 0, 0))
                .Returns(this.productMock.Object);
            var engine = new EngineBuilder().WithDataRepository(this.dataRepositoryMock.Object)
                .WithProductFactory(this.productFactoryMock.Object).Build();
            var args = new object[] {name, caloriesPer100g, proteinPer100g, carbsPer100g, fatsPer100g};
            engine.CreateFoodProductCommand.Execute(args);
            this.productFactoryMock.Verify(
                x => x.CreateFoodProduct(name, caloriesPer100g, proteinPer100g, carbsPer100g, 0, 0, 0), Times.Once);
        }

        [TestMethod]
        public void CallsSaveProgress_WithCorrectParameters()
        {
            // Arrange
            var name = "Skyr";
            var caloriesPer100g = 100;
            var proteinPer100g = 14;
            var carbsPer100g = 4;
            var fatsPer100g = 0;

            this.productFactoryMock
                .Setup(x => x.CreateFoodProduct(name, caloriesPer100g, proteinPer100g, carbsPer100g, 0, 0, 0))
                .Returns(this.productMock.Object);
            var engine = new EngineBuilder().WithJsonSerializer(this.jsonSerializerMock.Object)
                .WithDataRepository(this.dataRepositoryMock.Object)
                .WithProductFactory(this.productFactoryMock.Object).Build();
            var args = new object[] {name, caloriesPer100g, proteinPer100g, carbsPer100g, fatsPer100g};
            engine.CreateFoodProductCommand.Execute(args);
            this.jsonSerializerMock.Verify(x => x.SaveAllProducts(this.productCollection), Times.Once);
        }
    }
}