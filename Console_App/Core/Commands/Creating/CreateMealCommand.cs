using System;
using System.Collections.Generic;
using System.Linq;
using CalorieCounter.Contracts;
using CalorieCounter.CustomException;

namespace Console_App.Core.Commands.Creating
{
    internal class CreateMeal : BaseCommand
    {
        public CreateMeal(IEngine calorieCounterEngine)
            : base(calorieCounterEngine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            ICollection<IProduct> products;
            MealType type;
            string name;

            try
            {
                products = (ICollection<IProduct>)parameters[0]
                    .Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                type = (MealType)Enum.Parse(typeof(MealType), parameters[1]);
                name = parameters[2];
            }
            catch (Exception)
            {
                throw new CommandParseЕxception("Failed to parse CreateMeal command parameters.");
            }

            //var meal = this.Factory.CreateMeal(products, type, name);

            return $"Meal {name} was created!";
        }
    }
}