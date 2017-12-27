using System;
using System.Windows.Input;

namespace CalorieCounter.Utils
{
    public class RelayCommand : ICommand
    {
        private readonly Func<object, bool> canExecuteEvaluator;

        private readonly Action<object> methodToExecute;

        public RelayCommand(Action<object> methodToExecute, Func<object, bool> canExecuteEvaluator)
        {
            this.methodToExecute = methodToExecute;
            this.canExecuteEvaluator = canExecuteEvaluator;
        }

        public RelayCommand(Action<object> methodToExecute)
            : this(methodToExecute, null)
        {
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecuteEvaluator == null)
            {
                return true;
            }

            var result = this.canExecuteEvaluator.Invoke(parameter);
            return result;
        }

        public void Execute(object parameter)
        {
            this.methodToExecute.Invoke(parameter);
        }
    }
}