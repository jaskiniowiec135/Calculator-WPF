using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Calculator_WPF
{
    class Calculator : INotifyPropertyChanged
    {
        private List<string> values;
        private string printedValues;
        private int openedBrackets;

        private Regex rDigit;
        private Regex rSpecial;

        public Calculator()
        {
            rDigit = new Regex(@"\d.?");
            rSpecial = new Regex(@"[-()+/*^]");
            values = new List<string>();
            printedValues = "";
            openedBrackets = 0;
        }

        public List<string> Values
        {
            get
            {
                return values;
            }
        }

        public string PrintedValues
        {
            get
            {
                printedValues = "";
                foreach(string c in values)
                {
                    printedValues += c;
                }
                return printedValues;
            }
        }
      
        public void InputValue(string input)
        {
            if(IsValidInput(input) == true)
            {
                switch (input)
                {
                    case var inp when input.Length == 1 && (rDigit.IsMatch(inp) || input == ","):
                        if (values.Count != 0 && (rDigit.IsMatch(values.Last()) || input == ","))
                        {
                            if (input == "," && values.Last().Contains("."))
                            {

                            }
                            else
                            {
                                values[values.Count - 1] = values[values.Count - 1] + input;
                            }
                        }
                        else
                        {
                            if (input != ".")
                            {
                                values.Add(input);
                            }
                        }
                        break;
                    case var inp when rSpecial.IsMatch(inp):
                        if (values.Count > 0 )
                        {
                            if (rSpecial.IsMatch(values.Last()) && input != "(" && input != ")" && input.Contains("^") == false)
                            {
                                if (values.Last() != ")" && values.Last() != "(")
                                {
                                    values.Add(input);
                                }
                                else if (values.Last() == ")")
                                {
                                    values.Add(input);
                                }
                            }
                            else if (input.Contains("("))
                            {
                                if (input.Contains("^"))
                                {
                                    values.Add(input);
                                }
                                else
                                {
                                    if (rDigit.IsMatch(values.Last()))
                                    {
                                        values.Add("*");
                                        values.Add(input);
                                    }
                                    else if (values.Last() == ")")
                                    {
                                        values.Add("*");
                                        values.Add(input);
                                    } else if (rSpecial.IsMatch(values.Last()))
                                    {
                                        values.Add(input);
                                    }
                                }
                                openedBrackets++;
                            }
                            else if (input == ")")
                            {
                                if (openedBrackets > 0)
                                {
                                    if (rDigit.IsMatch(values.Last()) || values.Last() == ")")
                                    {
                                        values.Add(input);
                                        openedBrackets--;
                                    }
                                }
                            }
                            else if (input.Contains("^"))
                            {
                                if ((rSpecial.IsMatch(values.Last()) == false && values.Last() != ",") || values.Last() == ")")
                                {
                                    values.Add("^");
                                    values.Add(input.Remove(0, 1));
                                }
                            }
                            else
                            {
                                values.Add(input);
                            }
                        }
                        else
                        {
                            values.Add(input);
                        }
                        break;
                    case "=":
                        RPN rpn = new RPN(rDigit, rSpecial, values);
                        rpn.prepareRPN();
                        rpn.countRPN();
                        break;
                    case "":
                        values.Clear();
                        break;
                }
                OnPropertyChanged("Values");
                OnPropertyChanged("PrintedValues");
            }
        }

        private bool IsValidInput(string input)
        {
            Func<string, bool> result = (x) => rDigit.IsMatch(x) || rSpecial.IsMatch(x) || input == "" || input == "=" || input == ",";

            return result(input);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
