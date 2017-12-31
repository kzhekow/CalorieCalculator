using System;
using CalorieCounter.Contracts;

namespace CalorieCounter.Models
{
    /// <summary>
    ///     Product class implements IProduct.
    /// </summary>
    public abstract class Product : IProduct
    {
        private readonly int calories;
        private readonly int carbs;
        private readonly int fat;
        private readonly int fiber;
        private readonly int protein;
        private readonly int sugar;

        /// <summary>
        ///     Product constructor. Every new instantiated product must have a name and weight. New products can also contain
        ///     calories, protein, carbs, fat, sugar and fiber.
        /// </summary>
        /// <param name="name"></param>
        /// Name must be between 3 and 20 symbols!
        /// <param name="weightInGrams"></param>
        /// Weight can not be a negative number!
        /// <param name="calories"></param>
        /// Calories can not be a negative number!
        /// <param name="protein"></param>
        /// Protein can not be a negative number!
        /// <param name="carbs"></param>
        /// Carbs can not be a negative number!
        /// <param name="fat"></param>
        /// Fat can not be a negative number!
        /// <param name="sugar"></param>
        /// Sugar can not be a negative number!
        /// <param name="fiber"></param>
        /// Fiber can not be a negative number!
        public Product(string name, int calories, int protein, int carbs, int fat, int sugar,
            int fiber)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Name can not be null!");
            }

            if (name.Length < 3 || name.Length > 20)
            {
                throw new ArgumentException("Name must be between 3 and 20 symbols!");
            }

            if (calories < 0)
            {
                throw new ArgumentException("Calories can not be a negative number!");
            }

            if (protein < 0)
            {
                throw new ArgumentException("Protein can not be a negative number!");
            }

            if (carbs < 0)
            {
                throw new ArgumentException("Carbs can not be a negative number!");
            }

            if (fat < 0)
            {
                throw new ArgumentException("Fat can not be a negative number!");
            }

            if (sugar < 0)
            {
                throw new ArgumentException("Sugar can not be a negative number!");
            }

            if (fiber < 0)
            {
                throw new ArgumentException("Fiber can not be a negative number!");
            }
            //Guard.WhenArgument(name, "Name can not be null!").IsNotNullOrEmpty().Throw();
            //Guard.WhenArgument(name.Length, "Name must be between 3 and 20 symbols!").IsLessThan(3).IsGreaterThan(20)
            //    .Throw();
            //Guard.WhenArgument(calories, "Calories can not be a negative number!").IsLessThan(0).Throw();
            //Guard.WhenArgument(protein, "Protein can not be a negative number!").IsLessThan(0).Throw();
            //Guard.WhenArgument(carbs, "Carbs can not be a negative number!").IsLessThan(0).Throw();
            //Guard.WhenArgument(fat, "Fat can not be a negative number!").IsLessThan(0).Throw();
            //Guard.WhenArgument(sugar, "Sugar can not be a negative number!").IsLessThan(0).Throw();
            //Guard.WhenArgument(fiber, "Fiber can not be a negative number!").IsLessThan(0).Throw();

            this.Name = name;
            this.calories = calories;
            this.protein = protein;
            this.carbs = carbs;
            this.fat = fat;
            this.sugar = sugar;
            this.fiber = fiber;
        }

        public IProduct Clone()
        {
            return (IProduct) MemberwiseClone();
        }

        public string Name { get; }

        public int Calories => this.Weight > 0 ? this.calories * (int) (this.Weight / 100) : this.calories;

        public int Protein => this.Weight > 0 ? this.protein * (int) (this.Weight / 100) : this.protein;

        public int Carbs => this.Weight > 0 ? this.carbs * (int) (this.Weight / 100) : this.carbs;

        public int Fat => this.Weight > 0 ? this.fat * (int) (this.Weight / 100) : this.fat;

        public int Sugar => this.Weight > 0 ? this.sugar * (int) (this.Weight / 100) : this.sugar;

        public int Fiber => this.Weight > 0 ? this.fiber * (int) (this.Weight / 100) : this.fiber;

        public decimal Weight { get; set; }

        //public static IProduct operator +(Product left, Product right)
        //{
        //    // TODO: Custom meal instances should be created from a factory.
        //    var collection = new List<IProduct> { left, right };
        //    return new CustomMeal(collection);
        //}
    }
}