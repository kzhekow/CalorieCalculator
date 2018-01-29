using System;
using System.Collections.Generic;
using System.Text;
using CalorieCounter.Contracts;
using Console_App.Core.Contracts;

namespace Console_App.Core.Commands.Showing
{
    internal class ShowAllProductsCommand : BaseCommand
    {
        public ShowAllProductsCommand(ICalorieCounterEngine calorieCounterEngine)
            : base(calorieCounterEngine)
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
                sb.AppendLine(product.ToString());
            }

            if (string.IsNullOrEmpty(sb.ToString()))
            {
                sb.Append("No products added.");
            }

            //Trim the last end line.
            return sb.ToString().Substring(0, sb.ToString().Length -1);
        }
    }
}