using System;

namespace CalorieCounterEngine.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using global::CalorieCounterEngine.Contracts;

    public abstract class Meal : IMeal, IProduct
    {
        private readonly ICollection<IProduct> products;
        private readonly MealType type;
        private readonly string name;
        private readonly int calories;
        private readonly int protein;
        private readonly int carbs;
        private readonly int fat;
        private readonly int sugar;
        private readonly int fiber;

        protected Meal(ICollection<IProduct> products, MealType type, string name)
        {
            if (!Enum.IsDefined(typeof(MealType), type)) throw new ArgumentException("The provided meal type is not valid!");
            this.products = products ?? throw new ArgumentNullException("You must add some products");
            this.type = type;
            Guard.WhenArgument(name, "Name cannot be null or empty").IsNullOrWhiteSpace().Throw();
            this.name = name;
        }

        public ICollection<IProduct> Products => this.products;

        public MealType Type => this.type;

        public string Name => this.name;

        public int Calories => this.calories;

        public int Protein => this.protein;

        public int Carbs => this.carbs;

        public int Fat => this.fat;

        public int Sugar => this.sugar;

        public int Fiber => this.fiber;
    }
}