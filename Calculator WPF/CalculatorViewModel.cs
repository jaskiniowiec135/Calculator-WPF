using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

namespace Calculator_WPF
{
    class CalculatorViewModel : INotifyPropertyChanged
    {
        private Calculator calc;
        public Calculator Calc
        {
            get { return calc; }
            set
            {
                calc = value;
                //OnPropertyChanged("Calculator");
            }
        }

        public MyCommand Input {get; set;}

        public CalculatorViewModel()
        {
            calc = new Calculator();
            Input = new MyCommand(new Action<object>(InputData));
        }

        private void InputData(object sender)
        {
            calc.InputValue(sender.ToString());  
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
