using Bytes2you.Validation;
using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Models.Utils;
using CalorieCounter.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace CalorieCounter
{
    public sealed class CalorieCounterEngine : ICalorieCounterEngine
    {
        private readonly IActivityFactory activityFactory;
        private readonly IGoalFactory goalFactory;
        private ISuggestedDailyNutrientsIntakeCalc suggestedDailyNutrientsIntakeCalc;
        private readonly DirectoryInfo dailyProgressDirectory;

        //private readonly IGoalFactory goalFactory;
        private readonly IProductFactory productFactory;

        private readonly IDictionary<string, IProduct> products;
        private readonly DirectoryInfo productsDirectory;
        private ICommand addActivityCommand;
        private ICommand addConsumedProductCommand;
        private ICommand addWaterCommand;

        private ICommand createDrinkCommand;
        private ICommand createMealCommand;
        private ICommand createProductCommand;
        private ICommand setGoalCommand;

        private IDailyIntake currentDayCalorieTracker;
        private ICommand getAllProductsCommand;

        public CalorieCounterEngine(IProductFactory productFactory, IActivityFactory activityFactory, IGoalFactory goalFactory)
        {
            this.products = new Dictionary<string, IProduct>(StringComparer.InvariantCultureIgnoreCase);
            this.dailyProgressDirectory = Directory.CreateDirectory(EngineConstants.DailyProgressDirectoryName);
            this.productsDirectory = Directory.CreateDirectory(EngineConstants.ProductsDirectoryName);
            // TODO: Set proper can execute conditions.

            // TODO: JSON deserialization for current date.
            this.LoadProgress();
            this.productFactory = productFactory;
            this.activityFactory = activityFactory;
            this.goalFactory = goalFactory;
            //TODO: Deserialize and load all products from the local directory into the list.
        }

        public ICommand CreateFoodProductCommand
        {
            get
            {
                if (this.createProductCommand == null)
                {
                    this.createProductCommand = new RelayCommand(this.CreateProduct);
                }

                return this.createProductCommand;
            }
        }

        public ICommand CreateDrinkCommand
        {
            get
            {
                if (this.createDrinkCommand == null)
                {
                    this.createDrinkCommand = new RelayCommand(this.CreateDrink);
                }

                return this.createDrinkCommand;
            }
        }

        public ICommand CreateMealCommand
        {
            get
            {
                if (this.createMealCommand == null)
                {
                    this.createMealCommand = new RelayCommand(this.CreateMeal);
                }

                return this.createMealCommand;
            }
        }

        public ICommand AddConsumedProductCommand
        {
            get
            {
                if (this.addConsumedProductCommand == null)
                {
                    this.addConsumedProductCommand = new RelayCommand(this.AddConsumedProduct);
                }

                return this.addConsumedProductCommand;
            }
        }

        public ICommand AddWaterCommand
        {
            get
            {
                if (this.addWaterCommand == null)
                {
                    this.addWaterCommand = new RelayCommand(this.AddWater);
                }

                return this.addWaterCommand;
            }
        }

        public ICommand AddActivityCommand
        {
            get
            {
                if (this.addActivityCommand == null)
                {
                    this.addActivityCommand = new RelayCommand(this.AddActivity);
                }

                return this.addActivityCommand;
            }
        }

        public ICommand GetAllProductsCommand
        {
            get
            {
                if (this.getAllProductsCommand == null)
                {
                    this.getAllProductsCommand = new RelayCommand(this.GetAllProducts);
                }

                return this.getAllProductsCommand;
            }
        }

        public ICommand SetGoalCommand
        {
            get
            {
                if (this.setGoalCommand == null)
                {
                    this.setGoalCommand = new RelayCommand(this.SetGoal);
                }

                return this.setGoalCommand;
            }
        }

        public string GetRemainingNutrients()
        {
            if (this.currentDayCalorieTracker.Goal == null)
            {
                return "Goal has not been set!";
            }

            var sb = new StringBuilder();
            sb.Append("Remaining calories intake: ");
            sb.AppendLine(((int)DailyNutriCalc.RemainingCaloriesIntake(this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedDailyCalorieIntake(), this.currentDayCalorieTracker.ProductsConsumed, this.currentDayCalorieTracker.ActivitiesPerformed)).ToString());
            sb.Append("Remaining protein intake: ");
            sb.AppendLine(((int)DailyNutriCalc.RemainingProteinIntake(this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedDailyProteinIntake(), this.currentDayCalorieTracker.ProductsConsumed)).ToString());
            sb.Append("Remaining carbs intake: ");
            sb.AppendLine(((int)DailyNutriCalc.RemainingCarbsIntake(this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedDailyCarbsIntake(), this.currentDayCalorieTracker.ProductsConsumed)).ToString());
            sb.Append("Remaining fat intake: ");
            sb.AppendLine(((int)DailyNutriCalc.RemainingFatsIntake(this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedDailyFatIntake(), this.currentDayCalorieTracker.ProductsConsumed)).ToString());
            sb.Append("Remaining water intake: ");
            sb.AppendLine(((int)DailyNutriCalc.RemainingWaterIntake(this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedWaterIntake(), this.currentDayCalorieTracker.Water)).ToString());
            sb.Append("Current day macros ratio: ");

            if (this.currentDayCalorieTracker.ProductsConsumed.Count == 0)
            {
                sb.AppendLine(this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedMacrosRatio());
            }
            else
            {
                sb.AppendLine(DailyNutriCalc.CurrentDayMacrosRatio(this.currentDayCalorieTracker.ProductsConsumed));
            }

            return sb.ToString().TrimEnd();
        }

        public string GetDailyReport()
        {
            var sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("----Products Consumed----");
            foreach (var product in this.currentDayCalorieTracker.ProductsConsumed)
            {
                sb.AppendLine(product.ToString());
            }

            sb.AppendLine();
            sb.AppendLine("----Activities----");
            foreach (var activity in this.currentDayCalorieTracker.ActivitiesPerformed)
            {
                sb.AppendLine($"{activity.Type.ToString().ToUpper()} - {activity.Time} minutes");
            }

            sb.AppendLine();
            sb.Append($"Water consumed: {this.currentDayCalorieTracker.Water} ml");

            return sb.ToString().TrimEnd();
        }

        private void CreateProduct(object parameter)
        {
            // TODO: Validations, dissection of the passed arguments and creation of the new product (using the factory)

            //unboxing the values
            var args = parameter as object[];
            var name = (string)args[0];
            var caloriesPer100g = (int)args[1];
            var proteinPer100g = (int)args[2];
            var carbsPer100g = (int)args[3];
            var fatsPer100g = (int)args[4];
            var sugar = args.Length > 5 ? (int)args[5] : 0;
            var fiber = args.Length > 6 ? (int)args[6] : 0;

            var product = this.productFactory.CreateFoodProduct(name, caloriesPer100g, proteinPer100g, carbsPer100g,
                fatsPer100g, sugar, fiber);
            this.products.Add(product.Name, product);

            this.SaveProgress();
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

            var drink = this.productFactory.CreateDrink(name, caloriesPer100g, proteinPer100g, carbsPer100g,
                fatsPer100g, sugar, fiber);
            this.products.Add(drink.Name, drink);
            this.SaveProgress();
        }

        private void CreateMeal(object parameter)
        {
            throw new NotImplementedException();
        }

        private void AddConsumedProduct(object parameter)
        {
            var args = parameter as object[];
            var name = (string)args[0];
            var weightVolume = (int)args[1]; //grams or mililiters (depending on the product type)

            Guard.WhenArgument(this.products.ContainsKey(name), "There is no product with that name.").IsFalse()
                .Throw();
            var productCopy = this.products[name].Clone();
            productCopy.Weight = weightVolume;
            this.currentDayCalorieTracker.AddProduct(productCopy);
            this.SaveProgress();
        }

        private void AddWater(object parameter)
        {
            var args = parameter as object[];
            var weightVolume = (int)args[0]; //grams or mililiters (depending on the product type)

            this.currentDayCalorieTracker.AddWater(weightVolume);
        }

        private void AddActivity(object parameter)
        {
            var args = parameter as object[];
            var activityTypeString = (string)args[0];
            var time = (int)args[1];

            Guard.WhenArgument(time, "Time cannot be negative value.").IsLessThan(0).Throw();
            if (!Enum.TryParse(activityTypeString.ToLower(), true, out ActivityType activityType))
            {
                throw new ArgumentException("Invalid activity type");
            }

            var activity = this.activityFactory.CreateActivity(time, activityType);
            this.currentDayCalorieTracker.AddActivity(activity);
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

        private void SetGoal(object parameter)
        {
            var args = parameter as object[];
            var startingWeight = (double)args[0];
            var goalWeight = (double)args[1];
            var height = (double)args[2];
            var age = (int)args[3];
            var gender = (GenderType)args[4];
            var goalType = (GoalType)args[5];
            var activityLevel = (ActivityLevel)args[6];

            var goal = goalFactory.CreateGoal(startingWeight, goalWeight, height, age, gender, goalType, activityLevel);
            this.currentDayCalorieTracker.Goal = goal;

            this.suggestedDailyNutrientsIntakeCalc = new SuggestedDailyNutrientsIntakeCalc(goal);
        }

        private void LoadProgress()
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            // Iterate through all the files in the product directory, unserialize and add to collection.
            var files = this.productsDirectory.GetFiles("*.*");
            foreach (var fileInfo in files)
            {
                var jsonVal = File.ReadAllText(fileInfo.DirectoryName + "\\\\" + fileInfo.Name);
                var product = (IProduct)JsonConvert.DeserializeObject(jsonVal, settings);
                this.products.Add(product.Name, product);
            }

            if (File.Exists(this.dailyProgressDirectory.FullName + "\\\\" + DateTime.Now.Date.ToString("dd-MM-yyyy")))
            {
                var jsonVal = File.ReadAllText(this.dailyProgressDirectory.FullName + "\\\\" +
                                               DateTime.Now.Date.ToString("dd-MM-yyyy"));
                var curDay = JsonConvert.DeserializeObject(jsonVal, settings);
                this.currentDayCalorieTracker = (Models.Contracts.IDailyIntake)curDay;
            }
            else
            {
                this.currentDayCalorieTracker = new Models.DailyIntake();
            }
        }

        private void SaveProgress()
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            var curDay = JsonConvert.SerializeObject(this.currentDayCalorieTracker, typeof(IDailyIntake), settings);
            File.WriteAllText(this.dailyProgressDirectory.FullName + "\\\\" + DateTime.Now.Date.ToString("dd-MM-yyyy"),
                curDay);

            // Iterate through all the products and serialize those that are not saved already.
            var files = this.productsDirectory.GetFiles("*.*");
            foreach (var product in this.products)
            {
                //Not a new product, skip it.
                if (files.Any(file => string.Compare(file.Name, product.Key, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    continue;
                }

                var productJson = JsonConvert.SerializeObject(product.Value, typeof(IProduct), settings);
                File.WriteAllText(this.productsDirectory.FullName + "\\\\" + product.Key, productJson);
            }
        }
    }
}