using System.Windows.Input;

namespace CalorieCounterEngine.Contracts
{
    public interface IEngine
    {
        ICommand CreateProductCommand { get; }
    }
}
