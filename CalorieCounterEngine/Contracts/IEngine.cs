using System.Windows.Input;

namespace CalorieCounter.Contracts
{
    public interface IEngine
    {
        ICommand CreateFoodProductCommand { get; }

        ICommand CreateDrinkCommand { get; }

        ICommand SetGoalCommand { get; }

        ICommand AddConsumedProductCommand { get; }

        ICommand AddWaterCommand { get; }

        ICommand AddActivityCommand { get; }

        ICommand GetAllProductsCommand { get; }

        string GetDailyReport();

        string GetRemainingNutrients();
    }
}