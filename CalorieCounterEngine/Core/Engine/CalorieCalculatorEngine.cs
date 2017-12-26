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
        private readonly DailyIntake dailyIntake;
        
        
        private CalorieCalculatorEngine()
        {
            this.factory = new ProductFactory();
            this.dailyIntake = new DailyIntake();
            this.products = new Dictionary<string, IProduct>();
            this.activities = new Dictionary<string, IActivity>();
        }

        public static CalorieCalculatorEngine Instance => SingleInstance;
        

        public ICommand CreateProductCommand => throw new NotImplementedException();
    }
}
