using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Bytes2you.Validation;
using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Contracts;

namespace CalorieCounter
{
    public sealed class Engine : IEngine
    {
        private readonly IActivityFactory activityFactory;
        private readonly IDailyNutriCalc dailyNutriCalc;

        private readonly IDataRepository dataRepository;
        private readonly IGoalFactory goalFactory;

        private readonly IJsonSerializer jsonSerializer;
        private readonly IProductFactory productFactory;
        private ICommand addActivityCommand;
        private ICommand addConsumedProductCommand;
        private ICommand addWaterCommand;

        private ICommand createDrinkCommand;
        private ICommand createProductCommand;

        private IDailyIntake currentDayCalorieTracker;
        private ICommand getAllProductsCommand;
        private readonly IRestingEnergyCalculator restingEnergyCalculator;
        private ICommand setGoalCommand;
        private readonly ISuggestedDailyNutrientsIntakeCalc suggestedDailyNutrientsIntakeCalc;

        public Engine(
            IProductFactory productFactory,
            IActivityFactory activityFactory,
            IGoalFactory goalFactory,
            IDailyNutriCalc dailyNutriCalc,
            IRestingEnergyCalculator restingEnergyCalculator,
            IJsonSerializer jsonSerializer,
            IDataRepository dataRepository,
            ISuggestedDailyNutrientsIntakeCalc suggestedDailyNutrientsIntakeCalc)
        {
            Guard.WhenArgument(productFactory, "Product factory can not be null").IsNull().Throw();
            Guard.WhenArgument(activityFactory, "Activity factory can not be null").IsNull().Throw();
            Guard.WhenArgument(goalFactory, "Goal factory can not be null").IsNull().Throw();
            Guard.WhenArgument(dailyNutriCalc, "DailyNutriCalc can not be null").IsNull().Throw();
            Guard.WhenArgument(restingEnergyCalculator, "RestingEnergyCalculator can not be null").IsNull().Throw();

            this.productFactory = productFactory;
            this.activityFactory = activityFactory;
            this.goalFactory = goalFactory;
            this.dailyNutriCalc = dailyNutriCalc;
            this.restingEnergyCalculator = restingEnergyCalculator;
            this.jsonSerializer = jsonSerializer;
            this.dataRepository = dataRepository;
            this.suggestedDailyNutrientsIntakeCalc = suggestedDailyNutrientsIntakeCalc;

            // JSON deserialization for current date.
            LoadProgress();
        }

        public ICommand CreateFoodProductCommand
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

        public ICommand SetGoalCommand
        {
            get
            {
                if (this.setGoalCommand == null)
                {
                    this.setGoalCommand = new RelayCommand(SetGoal);
                }

                return this.setGoalCommand;
            }
        }

        public string GetRemainingNutrients()
        {
            if (this.currentDayCalorieTracker?.Goal == null)
            {
                return "Goal has not been set!";
            }

            var sb = new StringBuilder();
            sb.Append("Remaining calories intake: ");
            sb.AppendLine(((int) this.dailyNutriCalc.RemainingCaloriesIntake(
                    this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedDailyCalorieIntake(
                        this.currentDayCalorieTracker.Goal, this.restingEnergyCalculator),
                    this.currentDayCalorieTracker.ProductsConsumed, this.currentDayCalorieTracker.ActivitiesPerformed))
                .ToString());
            sb.Append("Remaining protein intake: ");
            sb.AppendLine(((int) this.dailyNutriCalc.RemainingProteinIntake(
                this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedDailyProteinIntake(
                    this.currentDayCalorieTracker.Goal, this.restingEnergyCalculator),
                this.currentDayCalorieTracker.ProductsConsumed)).ToString());
            sb.Append("Remaining carbs intake: ");
            sb.AppendLine(((int) this.dailyNutriCalc.RemainingCarbsIntake(
                this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedDailyCarbsIntake(
                    this.currentDayCalorieTracker.Goal, this.restingEnergyCalculator),
                this.currentDayCalorieTracker.ProductsConsumed)).ToString());
            sb.Append("Remaining fat intake: ");
            sb.AppendLine(((int) this.dailyNutriCalc.RemainingFatsIntake(
                this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedDailyFatIntake(
                    this.currentDayCalorieTracker.Goal, this.restingEnergyCalculator),
                this.currentDayCalorieTracker.ProductsConsumed)).ToString());
            sb.Append("Remaining water intake: ");
            sb.AppendLine(this.dailyNutriCalc
                .RemainingWaterIntake(
                    this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedWaterIntake(this.currentDayCalorieTracker
                        .Goal), this.currentDayCalorieTracker.Water).ToString());
            sb.Append("Current day macros ratio: ");

            if (this.currentDayCalorieTracker.ProductsConsumed == null ||
                this.currentDayCalorieTracker.ProductsConsumed.Count == 0)
            {
                sb.AppendLine(
                    this.suggestedDailyNutrientsIntakeCalc.CalculateSuggestedMacrosRatio(this.currentDayCalorieTracker
                        .Goal));
            }
            else
            {
                sb.AppendLine(
                    this.dailyNutriCalc.CurrentDayMacrosRatio(this.currentDayCalorieTracker.ProductsConsumed));
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
            var name = (string) args[0];
            var caloriesPer100g = (int) args[1];
            var proteinPer100g = (int) args[2];
            var carbsPer100g = (int) args[3];
            var fatsPer100g = (int) args[4];
            var sugar = args.Length > 5 ? (int) args[5] : 0;
            var fiber = args.Length > 6 ? (int) args[6] : 0;

            var product = this.productFactory.CreateFoodProduct(name, caloriesPer100g, proteinPer100g, carbsPer100g,
                fatsPer100g, sugar, fiber);
            this.dataRepository.Products.Add(product.Name, product);

            SaveProgress();
        }

        private void CreateDrink(object parameter)
        {
            var args = parameter as object[];
            var name = (string) args[0];
            var caloriesPer100g = (int) args[1];
            var proteinPer100g = (int) args[2];
            var carbsPer100g = (int) args[3];
            var fatsPer100g = (int) args[4];
            var sugar = args.Length > 5 ? (int)args[5] : 0;
            var fiber = args.Length > 6 ? (int)args[6] : 0;

            var drink = this.productFactory.CreateDrink(name, caloriesPer100g, proteinPer100g, carbsPer100g,
                fatsPer100g, sugar, fiber);
            this.dataRepository.Products.Add(drink.Name, drink);
            SaveProgress();
        }

        private void AddConsumedProduct(object parameter)
        {
            var args = parameter as object[];
            var name = (string) args[0];
            var weightVolume = (int) args[1]; //grams or mililiters (depending on the product type)

            Guard.WhenArgument(this.dataRepository.Products.ContainsKey(name), "There is no product with that name.")
                .IsFalse()
                .Throw();
            var productCopy = this.dataRepository.Products[name].Clone();
            productCopy.Weight = weightVolume;
            this.currentDayCalorieTracker.AddProduct(productCopy);
            SaveProgress();
        }

        private void AddWater(object parameter)
        {
            var args = parameter as object[];
            var weightVolume = (int) args[0]; //grams or mililiters (depending on the product type)

            this.currentDayCalorieTracker.AddWater(weightVolume);
            SaveProgress();
        }

        private void AddActivity(object parameter)
        {
            var args = parameter as object[];
            var activityTypeString = (string) args[0];
            var time = (int) args[1];

            Guard.WhenArgument(time, "Time cannot be negative value.").IsLessThan(0).Throw();
            if (!Enum.TryParse(activityTypeString.ToLower(), true, out ActivityType activityType))
            {
                throw new ArgumentException("Invalid activity type");
            }

            var activity = this.activityFactory.CreateActivity(time, activityType);
            this.currentDayCalorieTracker.AddActivity(activity);
            SaveProgress();
        }

        private void GetAllProducts(object parameter)
        {
            var args = parameter as object[];
            var listToBeFilled = (ICollection<IProduct>) args[0];

            listToBeFilled.Clear();
            foreach (var product in this.dataRepository.Products)
            {
                listToBeFilled.Add(product.Value);
            }
        }

        private void SetGoal(object parameter)
        {
            var args = parameter as object[];
            var startingWeight = (double) args[0];
            var goalWeight = (double) args[1];
            var height = (double) args[2];
            var age = (int) args[3];
            var gender = (GenderType) args[4];
            var goalType = (GoalType) args[5];
            var activityLevel = (ActivityLevel) args[6];

            var goal = this.goalFactory.CreateGoal(startingWeight, goalWeight, height, age, gender, goalType,
                activityLevel);
            this.currentDayCalorieTracker.Goal = goal;
            SaveProgress();
        }


        private void LoadProgress()
        {
            var products = this.jsonSerializer.GetProducts();
            if (products != null)
            {
                foreach (var product in products)
                {
                    if (!this.dataRepository.Products.ContainsKey(product.Name))
                    {
                        this.dataRepository.Products.Add(product.Name, product);
                    }
                }
            }

            this.currentDayCalorieTracker = this.jsonSerializer.GetDailyIntake();
        }

        private void SaveProgress()
        {
            this.jsonSerializer.SaveAllProducts(this.dataRepository.Products);
            this.jsonSerializer.SaveDailyIntake(this.currentDayCalorieTracker);
        }
    }
}