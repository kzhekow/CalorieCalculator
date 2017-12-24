namespace CalorieCounterEngine.Contracts
{
    using System.Windows.Input;

    public interface IEngine
    {
        ICommand CreateProductCommand { get; }
    }
}
