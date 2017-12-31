using System;
using System.Collections.Generic;
using CalorieCounter.Contracts;

namespace Console_App.Core.Commands.Creating
{
    internal class CreateFoodProductCommand : CreateProductCommand
    {
        public CreateFoodProductCommand(ICalorieCounterEngine calorieCounterEngine)
            : base(calorieCounterEngine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            string name;
            int calories;
            int protein;
            int carbs;
            int fat;
            int sugar;
            int fiber;

            try
            {
                name = parameters[0];
                calories = int.Parse(parameters[1]);
                protein = int.Parse(parameters[2]);
                carbs = int.Parse(parameters[3]);
                fat = int.Parse(parameters[4]);
                sugar = int.Parse(parameters[5]);
                fiber = int.Parse(parameters[6]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateFoodProduct command parameters.");
            }

            //var foodProduct = this.Factory.CreateFoodProduct(name, calories, protein, carbs, fat, sugar, fiber);

            return $"Food {name} product was created!";
        }
    }
}