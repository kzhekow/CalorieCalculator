using System.Collections.Generic;
using System.Linq;
using CalorieCounter.Contracts;

namespace CalorieCounter.Models
{
    internal class DailyIntake
    {
        public DailyIntake()
        {
            this.ProductList = new List<IProduct>();
        }

        public ICollection<IProduct> ProductList { get; }


        public void AddProduct(IProduct product)
        {
            this.ProductList.Add(product);
        }

        public void RemoveProduct(IProduct product)
        {
            this.ProductList.Remove(product);
        }

        public int TotalDailyCalories()
        {
            return this.ProductList.Sum(x => x.Calories);
        }

        public int TotalDailyProteins()
        {
            return this.ProductList.Sum(x => x.Protein);
        }

        public int TotalDailyCarbs()
        {
            return this.ProductList.Sum(x => x.Carbs);
        }

        public int TotalDailyFats()
        {
            return this.ProductList.Sum(x => x.Fat);
        }

        public int TotalDailySugars()
        {
            return this.ProductList.Sum(x => x.Sugar);
        }

        public int TotalDailyFibers()
        {
            return this.ProductList.Sum(x => x.Fiber);
        }
    }
}