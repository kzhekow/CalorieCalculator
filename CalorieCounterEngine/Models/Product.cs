using CalorieCounterEngine.Contracts;

namespace CalorieCounterEngine.Models
{
    using System.Collections.Generic;

    public abstract class Product : IProduct
    {
        public abstract string Name { get; }
        public abstract int Protein { get; }
        public abstract int Carbs { get;}
        public abstract int Fat { get; }
        public abstract int Calories { get; }
        public abstract int Sugar { get; }
        public abstract int Fiber { get; }

        public static IProduct operator +(Product left, Product right)
        {
            var collection = new List<IProduct> {left, right};
            return new CustomMeal(collection);
        }
    }
}