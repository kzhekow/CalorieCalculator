using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEngine.Contracts
{
    abstract class IFood
    {
        /// <summary>
        /// Name of the product.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Protein contained in the product.
        /// </summary>
        int Protein { get; }
        /// <summary>
        /// Carbohydrates contained in the product.
        /// </summary>
        int Carbs { get; }
        /// <summary>
        /// Fats contained in the product.
        /// </summary>
        int Fat { get; }
        /// <summary>
        /// Approximate amount of energy in the product.
        /// </summary>
        int Calories { get; }
        /// <summary>
        /// Sugar contained in the product.
        /// </summary>
        int Sugar { get; }
        /// <summary>
        /// Fibers in the product.
        /// </summary>
        int Fiber { get; }
    }
}
