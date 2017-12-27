using CalorieCounter.Contracts;
using System.Collections.Generic;

namespace CalorieCounterEngine.Models.Contracts
{
    public interface ICurrentDay
    {
        double RestingEnergy { get; }

        double SuggestedDailyCalorieIntake { get; }

        int BurnedCaloriesFromExercise { get; }

        ICollection<IProduct> Products { get; }

        ICollection<IMeal> Meals { get; }

        string CalculateMacros();

        double CalculateDailyIntake();

        void AddProducts(IProduct product);

        void RemoveProducts(IProduct product);
    }
}
