using CalorieCounterEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEngine
{
    class DailyIntake
    {
        private readonly ICollection<IProduct> productList;
        private readonly ICollection<IMeal> mealList;

        public DailyIntake()
        {
            this.productList = new List<IProduct>();
            this.mealList = new List<IMeal>();
        }

        public ICollection<IProduct> ProductList => productList;
        public ICollection<IMeal> MealList => mealList;



    }
}
