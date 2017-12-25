namespace CalorieCounterEngine.Models
{
    using System.Collections.Generic;
    using global::CalorieCounterEngine.Contracts;

    public abstract class Meal : IMeal
    {
        protected Meal(ICollection<IFood> products)
        {
            // TODO: Validations
            this.Products = products;
        }

        public ICollection<IFood> Products { get; }
    }
}