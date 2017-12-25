using Bytes2you.Validation;
using CalorieCounterEngine.Contracts;

namespace CalorieCounterEngine.Models.Drinks
{
    /// <summary>
    /// CustomDrink class inherits from IFood, because custom drink can have nutrition values.
    /// </summary>
    public class CustomDrink : Drink, IProduct
    {
        private readonly string name;
        private readonly decimal weight;
        private readonly int calories;
        private readonly int protein;
        private readonly int carbs;
        private readonly int fat;
        private readonly int sugar;

        /// <summary>
        /// CustomDrink constructor. We make sure that nutritients can not have a negative value.
        /// </summary>
        public CustomDrink(string name, decimal weightInMl, int calories, int protein, int carbs, int fat, int sugar) : base(name, weightInMl)
        {
            Guard.WhenArgument(calories, "Calories can not be less than zero!").IsLessThan(0).Throw();
            Guard.WhenArgument(protein, "Protein can not be less than zero!").IsLessThan(0).Throw();
            Guard.WhenArgument(carbs, "Carbs can not be less than zero!").IsLessThan(0).Throw();
            Guard.WhenArgument(fat, "Fat can not be less than zero!").IsLessThan(0).Throw();
            Guard.WhenArgument(sugar, "Sugar can not be less than zero!").IsLessThan(0).Throw();

            this.calories = calories;
            this.protein = protein;
            this.carbs = carbs;
            this.fat = fat;
            this.sugar = sugar;
        }

        public int Calories => this.calories * (int)(this.Weight / 100);

        public int Protein => this.protein * (int)(this.Weight / 100);

        public int Carbs => this.carbs * (int)(this.Weight / 100);

        public int Fat => this.fat * (int)(this.Weight / 100);

        public int Sugar => this.sugar * (int)(this.Weight / 100);
    }
}
