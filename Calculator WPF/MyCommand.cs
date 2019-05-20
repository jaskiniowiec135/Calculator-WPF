using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if(_execute != null)
            {
                _execute(parameter ?? "<N/A>");
            }
        }
        
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
