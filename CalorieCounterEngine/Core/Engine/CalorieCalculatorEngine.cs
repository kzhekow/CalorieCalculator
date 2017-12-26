using CalorieCounterEngine.Contracts;
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

        private CalorieCalculatorEngine()
        {

        }

        public static CalorieCalculatorEngine Instance => SingleInstance;
        

        public ICommand CreateProductCommand => throw new NotImplementedException();
    }
}
