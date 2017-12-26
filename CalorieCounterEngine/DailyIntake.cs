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
        

        public DailyIntake()
        {
            this.productList = new List<IProduct>();
            
        }

        public ICollection<IProduct> ProductList => productList;
        

        public void AddProduct(IProduct product)
        {
            this.productList.Add(product);
        }
        
        public void RemoveProduct(IProduct product)
        {
            this.productList.Remove(product);
        }
        public int TotalDailyCalories()
        {
            return this.productList.Sum(x => x.Calories);
        }
        public int TotalDailyProteins()
        {
            return this.productList.Sum(x => x.Protein);
        }
        public int TotalDailyCarbs()
        {
            return this.productList.Sum(x => x.Carbs);
        }
        public int TotalDailyFats()
        {
            return this.productList.Sum(x => x.Fat);
        }
        public int TotalDailySugars()
        {
            return this.productList.Sum(x => x.Sugar);
        }
        public int TotalDailyFibers()
        {
            return this.productList.Sum(x => x.Fiber);
        }
    }
}
