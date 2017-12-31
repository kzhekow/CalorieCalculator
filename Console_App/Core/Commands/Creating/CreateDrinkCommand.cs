using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCounter.Contracts;
using CalorieCounter.Factories.Contracts;
using Console_App.Core.Engine;

namespace Console_App.Core.Commands.Creating
{
    class CreateDrinkCommand : CreateProductCommand
    {
        public CreateDrinkCommand(ICalorieCounterEngine calorieCounterEngine) 
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
                throw new ArgumentException("Failed to parse CreateDrink command parameters.");
            }

            object[] args = {name,calories,protein,carbs,fat,sugar,fiber};
            if (this.CalorieCounterEngine.CreateDrinkCommand.CanExecute(args))
            {
                this.CalorieCounterEngine.CreateDrinkCommand.Execute(args);
            }

            return $"Drink {name} was created!";
        }
    }
}
