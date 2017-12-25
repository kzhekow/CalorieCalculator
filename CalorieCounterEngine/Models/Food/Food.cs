using Bytes2you.Validation;
using CalorieCounterEngine.Contracts;

namespace CalorieCounterEngine.Models.Food
{
    /// <summary>
    /// Food class implements IFood as long as it can contain fibers.
    /// </summary>
    public abstract class Food : IProduct, IFood
    {
        private readonly string name;
        private readonly decimal weight;
        private readonly int calories;
        private readonly int protein;
        private readonly int carbs;
        private readonly int fat;
        private readonly int sugar;
        private readonly int fiber;

        /// <summary>
        /// Food constructor. Every new instantiated product must have a name and weight. New products ca also contain calories, protein, carbs, fat, sugar and fiber.
        /// </summary>
        /// <param name="name"></param> Name must be between 3 and 20 symbols!
        /// <param name="weight"></param> Weight can not be a negative number!
        /// <param name="calories"></param> Calories can not be a negative number!
        /// <param name="protein"></param> Protein can not be a negative number!
        /// <param name="carbs"></param> Carbs can not be a negative number!
        /// <param name="fat"></param> Fat can not be a negative number!
        /// <param name="sugar"></param> Sugar can not be a negative number!
        /// <param name="fiber"></param> Fiber can not be a negative number!
        public Food(string name, decimal weight, int calories, int protein, int carbs, int fat, int sugar, int fiber)
        {
            Guard.WhenArgument(name, "Name can not be null!").IsNotNullOrEmpty().Throw();
            Guard.WhenArgument(name.Length, "Name must be between 3 and 20 symbols!").IsLessThan(3).IsGreaterThan(20).Throw();
            Guard.WhenArgument(weight, "Weight can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(calories, "Calories can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(protein, "Protein can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(carbs, "Carbs can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(fat, "Fat can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(sugar, "Sugar can not be a negative number!").IsLessThan(0).Throw();
            Guard.WhenArgument(fiber, "Fiber can not be a negative number!").IsLessThan(0).Throw();

            this.name = name;
            this.weight = weight;
            this.calories = calories;
            this.protein = protein;
            this.carbs = carbs;
            this.fat = fat;
            this.sugar = sugar;
            this.fiber = fiber;
        }
        public string Name => this.name;

        public decimal Weight => this.weight;

        public int Calories => this.calories *(int)(this.Weight / 100);

        public int Protein => this.protein * (int)(this.Weight / 100);

        public int Carbs => this.carbs * (int)(this.Weight / 100);

        public int Fat => this.fat * (int)(this.Weight / 100);

        public int Sugar => this.calories * (int)(this.Weight / 100);

        public int Fiber => this.calories * (int)(this.Weight / 100);
    }
}
