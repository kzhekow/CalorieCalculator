using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Input;
using Bytes2you.Validation;
using CalorieCounter.Contracts;
using CalorieCounter.Factories;
using CalorieCounter.Factories.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Models;
using CalorieCounterEngine.Models.Contracts;
using CalorieCounterEngine.Utils;
using Newtonsoft.Json;

namespace CalorieCounter
{
    public sealed class CalorieCounterEngine : ICalorieCounterEngine
    {
        private static ICalorieCounterEngine instance;
        private readonly IProductFactory productFactory;
        private readonly IActivityFactory activityFactory;
        private ICurrentDayCalorieTracker currentDayCalorieTracker;
        private IDictionary<string, IProduct> products;
        private readonly DirectoryInfo dailyProgressDirectory;
        private readonly DirectoryInfo productsDirectory;
        private ICommand createProductCommand;
        private ICommand createMealCommand;
        private ICommand createDrinkCommand;
        private ICommand addConsumedProductCommand;
        private ICommand addWaterCommand;
        private ICommand addActivityCommand;
        private ICommand getAllProductsCommand;

        public CalorieCounterEngine()
        {
            this.dailyProgressDirectory = Directory.CreateDirectory(EngineConstants.DailyProgressDirectoryName);
            this.productsDirectory = Directory.CreateDirectory(EngineConstants.ProductsDirectoryName);
            // TODO: Set proper can execute conditions.

            // TODO: JSON deserialization for current date.
            this.LoadProgress();
            this.createProductCommand = new RelayCommand(CreateProduct, arg => true);
            this.productFactory = new ProductFactory();
            this.activityFactory = new ActivityFactory();
            this.products = new Dictionary<string, IProduct>(StringComparer.InvariantCultureIgnoreCase);
            //TODO: Deserialize and load all products from the local directory into the list.
        }

        public static ICalorieCounterEngine Instance
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

            this.SaveProgress();
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
            var args = parameter as object[];
            var name = (string)args[0];
            var caloriesPer100g = (int)args[1];
            var proteinPer100g = (int)args[2];
            var carbsPer100g = (int)args[3];
            var fatsPer100g = (int)args[4];
            var sugar = (int)args[5];
            var fiber = (int)args[6];

            var drink = this.productFactory.CreateDrink(name, caloriesPer100g, proteinPer100g, carbsPer100g, fatsPer100g, sugar, fiber);
            this.products.Add(drink.Name, drink);
            this.SaveProgress();
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
            throw new NotImplementedException();
        }

        public ICommand AddConsumedProductCommand
        {
            get
            {
                if (this.addConsumedProductCommand == null)
                {
                    this.addConsumedProductCommand = new RelayCommand(AddConsumedProduct);
                }

                return this.addConsumedProductCommand;
            }
        }

        private void AddConsumedProduct(object parameter)
        {
            var args = parameter as object[];
            var name = (string)args[0];
            var weightVolume = (int)args[1]; //grams or mililiters (depending on the product type)

            Guard.WhenArgument(this.products.ContainsKey(name), "There is no product with that name.").IsFalse().Throw();
            var productCopy = this.products[name].Clone();
            productCopy.Weight = weightVolume;
            this.currentDayCalorieTracker.AddProduct(productCopy);
            this.SaveProgress();
        }

        public ICommand AddWaterCommand
        {
            get
            {
                if (this.addWaterCommand == null)
                {
                    this.addWaterCommand = new RelayCommand(AddWater);
                }

                return this.addWaterCommand;
            }
        }

        private void AddWater(object parameter)
        {
            var args = parameter as object[];
            var weightVolume = (int)args[0]; //grams or mililiters (depending on the product type)
            
            this.currentDayCalorieTracker.AddWater(weightVolume);
        }

        public ICommand AddActivityCommand
        {
            get
            {
                if (this.addActivityCommand == null)
                {
                    this.addActivityCommand = new RelayCommand(AddActivity);
                }

                return this.addActivityCommand;
            }
        }

        private void AddActivity(object parameter)
        {
            var args = parameter as object[];
            var activityTypeString = (string)args[0];
            var time = (int) args[1];

            Guard.WhenArgument(time, "Time cannot be negative value.").IsLessThan(0).Throw();
            if (!Enum.TryParse(activityTypeString, true, out ActivityType activityType))
            {
                throw new ArgumentException("Invalid activity type");
            }

            var activity = this.activityFactory.CreateActivity(time, activityType);
            this.currentDayCalorieTracker.AddActivity(activity);
        }

        public ICommand GetAllProductsCommand
        {
            get
            {
                if (this.getAllProductsCommand == null)
                {
                    this.getAllProductsCommand = new RelayCommand(GetAllProducts);
                }

                return this.getAllProductsCommand;
            }
        }

        public string GetDailyReport()
        {
            throw new NotImplementedException();
        }

        private void GetAllProducts(object parameter)
        {
            var args = parameter as object[];
            var listToBeFilled = (ICollection<IProduct>)args[0];

            listToBeFilled.Clear();
            foreach (var product in this.products)
            {
                listToBeFilled.Add(product.Value);
            }
        }

        private void LoadProgress()
        {
            if (File.Exists(this.dailyProgressDirectory.FullName + "/" + DateTime.Now.Date))
            {
                var curDay =
                    (CurrentDayCalorieTracker) JsonConvert.DeserializeObject(
                        this.dailyProgressDirectory.FullName + "/" + DateTime.Now.Date);
                this.currentDayCalorieTracker = curDay;
            }
            else
            {
                this.currentDayCalorieTracker = new CurrentDayCalorieTracker();
            }

            // Iterate through all the files in the product directory, unserialize and add to collection.
            var files = this.productsDirectory.GetFiles("*.*");
            foreach (var fileInfo in files)
            {
                var product = (IProduct) JsonConvert.DeserializeObject(fileInfo.DirectoryName);
                this.products.Add(product.Name, product);
            }
        }

        private void SaveProgress()
        {
            var curDay = JsonConvert.SerializeObject(this.currentDayCalorieTracker);
            File.WriteAllText(this.dailyProgressDirectory.FullName + "/" + DateTime.Now.Date, curDay);

            // Iterate through all the products and serialize those that are not saved already.
            var files = this.productsDirectory.GetFiles("*.*");
            foreach (var product in this.products)
            {
                //Not a new product, skip it.
                if (files.Any(file => string.Compare(file.Name, product.Key, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    continue;
                }

                var productJson = JsonConvert.SerializeObject(product.Value);
                File.WriteAllText(this.productsDirectory.FullName + "/" + product.Key, productJson);
            }
        }
    }
}