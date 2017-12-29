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
        private ICommand createProductCommand;
        private ICommand createMealCommand;
        private ICommand createDrinkCommand;

        public CalorieCounterEngine()
        {
            // TODO: Set proper can execute conditions.
            this.createProductCommand = new RelayCommand(CreateProduct, arg => true);
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
                if (this.createProductCommand == null)
                {
                    this.createProductCommand = new RelayCommand(CreateProduct);
                }

                return this.createProductCommand;
            }
        }

        private void CreateProduct(object parameter)
        {
            // TODO: Validations, dissection of the passed arguments and creation of the new product (using the factory)

            //unboxing the values
            var args = parameter as object[];
            var name = (string) args[0];
            var caloriesPer100g = (int)args[1];
            var proteinPer100g = (int) args[2];
            var carbsPer100g = (int) args[3];
            var fatsPer100g = (int) args[4];
            var sugar = (int) args[5];
            var fiber = (int) args[6];

            var product = this.productFactory.CreateProduct(name, caloriesPer100g,proteinPer100g,caloriesPer100g,fatsPer100g, sugar, fiber);
            this.products.Add(product.Name, product);
        }

        public ICommand CreateDrinkCommand
        {
            get
            {
                if (this.createDrinkCommand == null)
                {
                    this.createDrinkCommand = new RelayCommand(CreateDrink);
                }

                return this.createDrinkCommand;
            }
        }

        private void CreateDrink(object parameter)
        {
            // TODO: Validations, dissection of the passed arguments and creation of the new drink (using the factory)
            
        }

        public ICommand CreateMealCommand
        {
            get
            {
                if (this.createMealCommand == null)
                {
                    this.createMealCommand = new RelayCommand(CreateMeal);
                }

                return this.createMealCommand;
            }
        }

        private void CreateMeal(object parameter)
        {
            // TODO: Validations, dissection of the passed arguments and creation of the new meal (using the factory)
            
        }
    }
}