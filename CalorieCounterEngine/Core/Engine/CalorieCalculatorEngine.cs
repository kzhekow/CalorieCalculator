using CalorieCounterEngine.Contracts;
using CalorieCounterEngine.Factories;
using CalorieCounterEngine.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CalorieCounterEngine.Core.Engine
{
    public sealed class CalorieCalculatorEngine : IEngine
    {
        private static readonly CalorieCalculatorEngine SingleInstance = new CalorieCalculatorEngine();
        private readonly ProductFactory factory;
        private readonly IDictionary<string, IProduct> products;
        private readonly IDictionary<string, IActivity> activities;
        private readonly IDictionary<string, IMeal> meals;
        


        private CalorieCalculatorEngine()
        {
            this.factory = new ProductFactory();
            this.products = new Dictionary<string, IProduct>();
            this.activities = new Dictionary<string, IActivity>();
            this.meals = new Dictionary<string, IMeal>();
        }

        public static CalorieCalculatorEngine Instance => SingleInstance;
        

        public ICommand CreateProductCommand => throw new NotImplementedException();
    }
}
