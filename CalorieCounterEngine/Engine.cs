namespace CalorieCounterEngine
{
    using System.Collections.Generic;
    using System.Windows.Input;
    using Contracts;
    using global::CalorieCounterEngine.Factories;
    using Utils;

    public sealed class Engine : IEngine
    {
        private static IEngine instance;
        private ICommand createProduct;
        private readonly IDictionary<string, IProduct> products;
        private readonly IProductFactory productFactory;

        public Engine()
        {
            // TODO: Set proper can execute conditions.
            this.createProduct = new RelayCommand(this.CreateProduct, (arg) => true);
            this.productFactory = new ProductFactory();
            this.products = new Dictionary<string, IProduct>();
            //TODO: Deserialize and load all products from the local directory into the list.
        }

        public static IEngine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Engine();
                }

                return instance;
            }
        }

        public ICommand CreateProductCommand
        {
            get
            {
                if (this.createProduct == null)
                {
                    this.createProduct = new RelayCommand(this.CreateProduct);
                }

                return this.createProduct;
            }
        }

        private void CreateProduct(object parameter)
        {
            // TODO: Validations, dissection of the passed arguments and creation of the new product (using the factory)

            //unboxing the values
            var args = parameter as object[];
            string name = (string) args[0];
            decimal weight = (decimal)args[1];
            int protein = (int) args[2];
            int carbs = (int) args[3];
            int fats = (int) args[4];
            int calories = (int) args[5];
            int sugar = (int)args[6];
            int fiber = (int)args[7];

            var product = this.productFactory.CreateProduct(name, protein, carbs, fats, calories, sugar, fiber);
            this.products.Add(product.Name, product);
        }
    }
}
