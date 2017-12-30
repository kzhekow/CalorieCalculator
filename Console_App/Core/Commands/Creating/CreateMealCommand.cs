using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using Console_App.Core.Contracts;
using Console_App.Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_App.Core.Commands.Creating
{
    class CreateMeal : CreateProductCommand
    {
        public CreateMeal(IProductFactory factory, ICommandParserEngine engine, ICalorieCounterEngine calorieCounterEngine) 
            : base(factory, engine, calorieCounterEngine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            ICollection<IProduct> products;
            MealType type;
            string name;

            try
            {
                products = (ICollection<IProduct>)parameters[0].Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                type = (MealType)Enum.Parse(typeof(MealType), parameters[1]);
                name = parameters[2];
            }
            catch (Exception)
            {
                throw new ArgumentException("Failed to parse CreateMeal command parameters.");
            }

            var meal = this.Factory.CreateMeal(products, type, name);

            return $"Meal {name} was created!";
        }
    }
}
