using System.Windows.Input;

namespace CalorieCounter.Contracts
{
    public interface IEngine
    {
        ICommand CreateProductCommand { get; }
    }
}