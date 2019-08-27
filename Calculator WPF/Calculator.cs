using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Calculator_WPF
{
    public class Calculator : INotifyPropertyChanged
    {
        private List<string> values;
        private string printedValues;
        private int openedBrackets;

        private static Regex rDigit;
        private static Regex rSpecial;
        private static Regex rOther;

        public Calculator()
        {
            rDigit = new Regex(@"\d.?");
            rSpecial = new Regex(@"[-()+/*^]");
            rOther = new Regex($@"[{'\x002E'}{'\u0008'}{"="}{","}]");
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
                    if (values.Count > 0)
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
                                }
                                else if (rSpecial.IsMatch(values.Last()))
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
                        if (input.Contains("("))
                            openedBrackets++;
                    }
                    break;
                case "=":
                    RPN rpn = new RPN(rDigit, rSpecial, rOther, values);
                    rpn.PrepareRPN();
                    rpn.countRPN();
                    break;
                case "\\u0008":
                    if (values.Last().Length == 1)
                    {
                        values.RemoveAt(values.Count - 1);
                    }
                    else
                    {
                        values[values.Count - 1] = values.Last().Substring(0, values.Last().Length - 1);
                    }
                    break;
                case "\\x002E":
                    values.Clear();
                    break;
            }
            OnPropertyChanged("Values");
            OnPropertyChanged("PrintedValues");
            
        }
        
        public static bool IsValidInput(string input)
        {
            Func<string, bool> result = (x) => rDigit.IsMatch(x) || rSpecial.IsMatch(x) || rOther.IsMatch(x);

            return result(input);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
