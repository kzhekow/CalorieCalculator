using System;

namespace CalorieCounterEngine.Models
{
    using System.Collections.Generic;
    using global::CalorieCounterEngine.Contracts;

    public abstract class Meal : IMeal
    {
        private readonly ICollection<IProduct> products;
        private readonly MealType type;

        protected Meal(ICollection<IProduct> products, MealType type)
        {
            if (!Enum.IsDefined(typeof(MealType), type)) throw new ArgumentException("The provided meal type is not valid!");
            this.products = products ?? throw new ArgumentNullException("You must add some products");
            this.type = type;
        }

        public ICollection<IProduct> Products => this.products;

        public MealType Type => throw new System.NotImplementedException();

    }
}