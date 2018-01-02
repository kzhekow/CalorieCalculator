using System;
using System.Collections.Generic;
using System.Text;
using CalorieCounter.Contracts;
using Console_App.Core.Contracts;

namespace Console_App.Core.Commands.Showing
{
    internal class ShowAllProductsCommand : BaseCommand
    {
        public ShowAllProductsCommand(ICalorieCounterEngine calorieCounterEngine) : base(calorieCounterEngine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var list = new List<IProduct>();
            var args = new object[] { list };
            if (this.CalorieCounterEngine.GetAllProductsCommand.CanExecute(args))
            {
                this.CalorieCounterEngine.GetAllProductsCommand.Execute(args);
            }

            var sb = new StringBuilder();

            foreach (var product in list)
            {
                sb.AppendLine(
                    $"{product.Name} {product.Calories} kcal {(product.Weight == 0 ? 100 : product.Weight)} gr/ml {product.Protein} protein {product.Carbs} carbs {product.Fat} fat {product.Sugar} sugar {product.Fiber} fiber");
            }

            if (string.IsNullOrEmpty(sb.ToString()))
            {
                sb.Append("No products added.");
            }

            return sb.ToString();
        }
    }
}