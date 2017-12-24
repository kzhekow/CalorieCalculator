using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEngine.Models
{
    using CalorieCounterEngine.Contracts;
    public sealed class CustomMeal : Meal, IMeal, IProduct
    {
        public CustomMeal(ICollection<IProduct> products) : base(products)
        {
            //TODO: Validations

            foreach (var product in products)
            {
                this.Name += product.Name + " ";
                this.Calories += product.Calories;
                this.Carbs += product.Carbs;
                this.Fat += product.Fat;
                this.Fiber += product.Fiber;
                this.Protein += product.Protein;
                this.Sugar += product.Sugar;
            }
        }

        public override string Name { get; }
        public override int Protein { get; }
        public override int Carbs { get; }
        public override int Fat { get; }
        public override int Calories { get; }
        public override int Sugar { get; }
        public override int Fiber { get; }
    }
}
