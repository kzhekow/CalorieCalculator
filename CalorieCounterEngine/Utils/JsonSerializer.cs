using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CalorieCounter.Contracts;
using CalorieCounter.Models;
using CalorieCounter.Models.Contracts;
using CalorieCounter.Utils;
using CalorieCounterEngine.Contracts;
using Newtonsoft.Json;

namespace CalorieCounterEngine.Utils
{
    public class JsonSerializer : IJsonSerializer
    {
        private readonly DirectoryInfo dailyProgressDirectory;
        private readonly DirectoryInfo productsDirectory;

        public JsonSerializer()
        {
            this.dailyProgressDirectory = Directory.CreateDirectory(EngineConstants.DailyProgressDirectoryName);
            this.productsDirectory = Directory.CreateDirectory(EngineConstants.ProductsDirectoryName);
        }

        public IList<IProduct> GetProducts()
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            var products = new List<IProduct>();
            // Iterate through all the files in the product directory, unserialize and add to collection.
            var files = this.productsDirectory.GetFiles("*.*");
            foreach (var fileInfo in files)
            {
                var jsonVal = File.ReadAllText(fileInfo.DirectoryName + "\\\\" + fileInfo.Name);
                var product = (IProduct) JsonConvert.DeserializeObject(jsonVal, settings);
                products.Add(product);
            }

            return products;
        }

        public IDailyIntake GetDailyIntake()
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;

            if (File.Exists(this.dailyProgressDirectory.FullName + "\\\\" + DateTime.Now.Date.ToString("dd-MM-yyyy")))
            {
                var jsonVal = File.ReadAllText(this.dailyProgressDirectory.FullName + "\\\\" +
                                               DateTime.Now.Date.ToString("dd-MM-yyyy"));
                var curDay = JsonConvert.DeserializeObject(jsonVal, settings);
                return (IDailyIntake) curDay;
            }

            return new DailyIntake();
        }

        public void SaveDailyIntake(IDailyIntake dailyIntake)
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            var curDay = JsonConvert.SerializeObject(dailyIntake, typeof(IDailyIntake), settings);
            File.WriteAllText(this.dailyProgressDirectory.FullName + "\\\\" + DateTime.Now.Date.ToString("dd-MM-yyyy"),
                curDay);
        }

        public void SaveAllProducts(IDictionary<string, IProduct> products)
        {
            var settings = new JsonSerializerSettings();
            settings.TypeNameHandling = TypeNameHandling.Auto;
            // Iterate through all the products and serialize those that are not saved already.
            var files = this.productsDirectory.GetFiles("*.*");
            foreach (var product in products)
            {
                //Not a new product, skip it.
                if (files.Any(file => string.Compare(file.Name, product.Key, StringComparison.OrdinalIgnoreCase) == 0))
                {
                    continue;
                }

                var productJson = JsonConvert.SerializeObject(product.Value, typeof(IProduct), settings);
                File.WriteAllText(this.productsDirectory.FullName + "\\\\" + product.Key, productJson);
            }
        }
    }
}