using System.Windows.Input;

namespace CalorieCounter.Contracts
{
    public interface ICalorieCounterEngine
    {
        ICommand CreateProductCommand { get; }
        ICommand CreateDrinkCommand { get; }
        ICommand CreateMealCommand { get; }
        ICommand AddConsumedProductCommand { get; }
        ICommand AddWaterCommand { get; }
        ICommand AddActivityCommand { get; }
        ICommand GetAllProductsCommand { get; }
        string GetDailyReport();
    }
}