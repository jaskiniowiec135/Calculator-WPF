using System;
using System.Windows.Input;

namespace Calculator_WPF
{
    class MyCommand : ICommand
    {
        private readonly Action<object> _execute;

        public MyCommand(Action<object> executeMethod)
        {
            _execute = executeMethod;
        }

        public void Execute(object parameter)
        {
            if (_execute != null)
            {
                _execute(parameter ?? "<N/A>");
            }
        }

        public bool CanExecute(object parameter)
        {
            if (Calculator.IsValidInput(parameter.ToString()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
