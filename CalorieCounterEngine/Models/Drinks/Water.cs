using CalorieCounterEngine.Contracts;

namespace CalorieCounterEngine.Models.Food
{
    public class Water : IProduct
    {
        private const string DrinkName = "Water";
        private readonly decimal weightInMl;

        public Water(decimal weightInMl)
        {
            this.weightInMl = weightInMl;
        }

        public string Name => DrinkName;

        public decimal Weight => this.weightInMl;
    }
}
