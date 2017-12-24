using CalorieCounterEngine.Contracts;

namespace CalorieCounterEngine.Models
{
    public class CustomProduct : Product, IProduct
    {
        public CustomProduct(string name, int protein, int carbs, int fat, int calories, int sugar = 0, int fiber = 0)
        {
            // TODO: Validations
            this.Name = name;
            this.Protein = protein;
            this.Carbs = carbs;
            this.Fat = fat;
            this.Calories = calories;
            this.Sugar = sugar;
            this.Fiber = fiber;
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