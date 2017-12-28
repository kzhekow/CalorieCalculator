using Bytes2you.Validation;
using CalorieCounter.Contracts;
using CalorieCounterEngine.Models.Contracts;
using System;
using System.Collections.Generic;

namespace CalorieCounterEngine.Models
{
    public class CurrentDayCalorieTracker : ICurrentDay, IProduct
    {
        private double restingEnergy;
        private double suggestedDailyCalorieIntake;
        private int burnedCaloriesFromExercise;

        public CurrentDayCalorieTracker(double restingEnergy, double suggestedDailyCalorieIntake, int burnedCaloriesFromExercise = 0)
        {
            this.RestingEnergy = restingEnergy;
            this.SuggestedDailyCalorieIntake = suggestedDailyCalorieIntake;
            this.burnedCaloriesFromExercise = burnedCaloriesFromExercise;
        }

        public double RestingEnergy
        {
            get
            {
                return this.restingEnergy;
            }
            private set
            {
                Guard.WhenArgument(value, "Resting energy can not be a negative number!").IsLessThan(0).Throw();
                this.restingEnergy = value;
            }
        }

        public double SuggestedDailyCalorieIntake
        {
            get
            {
                return this.suggestedDailyCalorieIntake;
            }
            private set
            {
                Guard.WhenArgument(value, "Suggested daily calorie intake can not be a negative number!").IsLessThan(0).Throw();
                this.suggestedDailyCalorieIntake = value;
            }
        }

        public int BurnedCaloriesFromExercise
        {
            get
            {
                return this.burnedCaloriesFromExercise;
            }
            private set
            {
                Guard.WhenArgument(value, "Burned calories from exercise can not be a negative number!").IsLessThan(0).Throw();
                this.burnedCaloriesFromExercise = value;
            }
        }

        public ICollection<IProduct> Products => new List<IProduct>();

        public ICollection<IMeal> Meals => new List<IMeal>();

        public string Name => DateTime.Today.ToShortDateString();

        public int Calories { get; private set; }

        public int Protein { get; private set; }

        public int Carbs { get; private set; }

        public int Fat { get; private set; }

        public int Sugar { get; private set; }

        public int Fiber { get; private set; }

        public double CalculateDailyIntake()
        {
            foreach (var product in this.Products)
            {
                this.Calories += product.Calories;
                this.Protein += product.Protein;
                this.Carbs += product.Carbs;
                this.Fat += product.Fat;
                this.Sugar += product.Sugar;
                this.Fiber += product.Fiber;
            }

            foreach (var meal in this.Meals)
            {
                foreach (var product in meal.Products)
                {
                    this.Calories += product.Calories;
                    this.Protein += product.Protein;
                    this.Carbs += product.Carbs;
                    this.Fat += product.Fat;
                    this.Sugar += product.Sugar;
                    this.Fiber += product.Fiber;
                }
            }

            return (this.SuggestedDailyCalorieIntake + this.BurnedCaloriesFromExercise) - this.Calories;
        }

        public string CalculateMacros()
        {
            var carbsRatio = Math.Round(((double)(this.Carbs * 4) / this.Calories) * 100);
            var proteinRatio = Math.Round(((double)(this.Protein * 4) / this.Calories) * 100);
            var fatRatio = Math.Round(((double)(this.Fat * 9) / this.Calories) * 100);

            return $"Carbs:Protein:Fat = {carbsRatio}:{proteinRatio}:{fatRatio}";
        }

        public void AddProducts(IProduct product)
        {
            Guard.WhenArgument(product, "Product can not be null!").IsNull().Throw();
            this.Products.Add(product);
        }

        public void RemoveProducts(IProduct product)
        {
            Guard.WhenArgument(product, "Product can not be null!").IsNull().Throw();
            Guard.WhenArgument(this.Products, "The list of products is empty!").IsNull().Throw();

            this.Products.Remove(product);
        }

        public void AddMeal(IMeal meal)
        {
            Guard.WhenArgument(meal, "Meal can not be null!").IsNull().Throw();
            this.Meals.Add(meal);
        }

        public void RemoveMeal(IMeal meal)
        {
            Guard.WhenArgument(meal, "Meal can not be null!").IsNull().Throw();
            Guard.WhenArgument(this.Meals, "The list of meals is empty!").IsNull().Throw();
            this.Meals.Remove(meal);
        }
    }
}
