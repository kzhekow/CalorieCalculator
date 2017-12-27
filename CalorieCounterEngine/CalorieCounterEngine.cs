using System.Collections.Generic;
using System.Windows.Input;
using CalorieCounter.Contracts;
using CalorieCounter.Factories;
using CalorieCounter.Utils;

namespace CalorieCounter
{
    public sealed class CalorieCounterEngine : IEngine
    {
        private static IEngine instance;
        private readonly IProductFactory productFactory;
        private readonly IDictionary<string, IProduct> products;
        private ICommand createProduct;

        public CalorieCounterEngine()
        {
            // TODO: Set proper can execute conditions.
            this.createProduct = new RelayCommand(CreateProduct, arg => true);
            this.productFactory = new ProductFactory();
            this.products = new Dictionary<string, IProduct>();
            //TODO: Deserialize and load all products from the local directory into the list.
        }

        public static IEngine Instance
        {
            get
            {
                if (instance == null) instance = new CalorieCounterEngine();

                return instance;
            }
        }

        public ICommand CreateProductCommand
        {
            get
            {
                if (this.createProduct == null) this.createProduct = new RelayCommand(CreateProduct);

                return this.createProduct;
            }
        }

        private void CreateProduct(object parameter)
        {
            // TODO: Validations, dissection of the passed arguments and creation of the new product (using the factory)

            //unboxing the values
            var args = parameter as object[];
            var name = (string) args[0];
            var weight = (decimal) args[1];
            var protein = (int) args[2];
            var carbs = (int) args[3];
            var fats = (int) args[4];
            var calories = (int) args[5];
            var sugar = (int) args[6];
            var fiber = (int) args[7];

            var product = this.productFactory.CreateProduct(name, protein, carbs, fats, calories, sugar, fiber);
            this.products.Add(product.Name, product);
        }
    }
}