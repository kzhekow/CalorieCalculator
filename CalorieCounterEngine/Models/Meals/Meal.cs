using System;

namespace CalorieCounterEngine.Models
{
    using System.Collections.Generic;
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

        protected Meal(ICollection<IProduct> products, MealType type)
        {
            if (!Enum.IsDefined(typeof(MealType), type)) throw new ArgumentException("The provided meal type is not valid!");
            this.products = products ?? throw new ArgumentNullException("You must add some products");
            this.type = type;
        }

        public ICollection<IProduct> Products => this.products;

        public MealType Type => this.type;

        public string Name => this.name;

        public decimal Weight => throw new NotImplementedException();

        public int Calories => throw new NotImplementedException();

        public int Protein => throw new NotImplementedException();

        public int Carbs => throw new NotImplementedException();

        public int Fat => throw new NotImplementedException();

        public int Sugar => throw new NotImplementedException();

        public int Fiber => throw new NotImplementedException();
    }
}