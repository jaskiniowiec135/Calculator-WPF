using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public Calculator()
        {
            rDigit = new Regex(@"\d.?");
            rSpecial = new Regex(@"[-()+/*^]");
            rOther = new Regex($@"[{"Clear"}{"RemoveLast"}{"Calculate"}{","}]");
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
                foreach (string c in values)
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
                        if (!(input == "," && values.Last().Contains(".")))
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
                                while(input.Length > 0)
                                {
                                    values.Add(input[0].ToString());
                                    input = input.Substring(1);
                                }
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
                case var inp when rOther.IsMatch(inp):
                    if (inp == SpecialSignals.Calculate.ToString() &&
                        IsEquationValid())
                    {
                        RPN rpn = new RPN(rDigit, rSpecial, values);
                        rpn.PrepareRPN();
                        rpn.CountRPN();
                    }
                    else if (inp == SpecialSignals.RemoveLast.ToString())
                    {
                        if (values.Last().Length == 1)
                        {
                            values.RemoveAt(values.Count - 1);
                        }
                        else
                        {
                            values[values.Count - 1] = values.Last().Substring(0, values.Last().Length - 1);
                        }
                    }
                    else if (inp == SpecialSignals.Clear.ToString())
                    {
                        values.Clear();
                    }
                    break;
            }

            UpdateProperties();
        }

        private bool IsEquationValid()
        {
            return true;
        }

        public static bool IsValidInput(string input)
        {
            Func<string, bool> result = (x) => rDigit.IsMatch(x) || rSpecial.IsMatch(x) || rOther.IsMatch(x);

            return result(input);
        }

        private void UpdateProperties()
        {
            OnPropertyChanged("Values");
            OnPropertyChanged("PrintedValues");
        }

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
