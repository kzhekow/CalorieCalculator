using CalorieCounterEngine.Models.Drinks;

namespace CalorieCounterEngine.Models.Food
{
    public class Water : Drink
    {
        private const string DrinkName = "Water";

        public Water(decimal weightInMl) : base(DrinkName, weightInMl)
        {
        }
    }
}
