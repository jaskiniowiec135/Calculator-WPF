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
        private static Regex rSeparator;
        private static Regex rBasic;
        private static Regex rBrackets;
        private static Regex rOther;

        public event PropertyChangedEventHandler PropertyChanged;

        public Calculator()
        {
            rDigit = new Regex(@"[\d]");
            rSeparator = new Regex(@"[\.\,]");
            rBasic = new Regex(@"[-+/*^]");
            rBrackets = new Regex(@"[()]");
            rOther = new Regex($@"[{"Clear"}{"RemoveLast"}{"Calculate"}]");
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
                case var inp when (rDigit.IsMatch(inp) || rSeparator.IsMatch(inp))
                    && !rBasic.IsMatch(inp):
                    if (rDigit.IsMatch(input))
                    {
                        if (values.Count != 0 && (rDigit.IsMatch(values.Last())))
                        {
                            if (values.Count == 1 && values.Last() == "-")
                            {
                                values.Add(input);
                            }
                            else
                            {
                                values[values.Count - 1] = values[values.Count - 1] + input;
                            }
                        }
                        else
                        {
                            values.Add(input);
                        }
                    }
                    else
                    {
                        if (values.Count > 0 &&
                            !rSeparator.IsMatch(values.Last()) &&
                            rDigit.IsMatch(values.Last()))
                        {
                            values[values.Count - 1] = values[values.Count - 1] + input;
                        }
                    }
                    break;
                case var inp when rBasic.IsMatch(inp):
                    if (values.Count > 0)
                    {
                        if (!rBasic.IsMatch(values.Last()))
                        {
                            if (values.Last() != "(")
                            {
                                if (input.Contains("^"))
                                {
                                    for (int i = 0; i < input.Length; i++)
                                    {
                                        values.Add(input[i].ToString());
                                    }
                                }
                                else
                                {
                                    values.Add(input);
                                }
                            }
                        }
                        else if (values.Last() == "^")
                        {
                            if (rSeparator.IsMatch(values.Last()) || values.Last() == ")")
                            {
                                values.Add(input);
                            }
                        }
                    }
                    else if (input == "-")
                    {
                        values.Add(input);
                    }
                    break;
                case var inp when rBrackets.IsMatch(inp):
                    if (input == "(")
                    {
                        if (values.Count > 0)
                        {
                            if (rDigit.IsMatch(values.Last()) || values.Last() == ")")
                            {
                                values.Add("*");
                                values.Add(input);
                            }
                            else if (rBasic.IsMatch(values.Last()))
                            {
                                values.Add(input);
                            }
                        }
                        else
                        {
                            values.Add(input);
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
                    break;
                case var inp when rOther.IsMatch(inp):
                    if (inp == SpecialSignals.Calculate.ToString())
                    {
                        while (openedBrackets > 0)
                        {
                            values.Add(")");
                            openedBrackets--;
                        }

                        while (rBasic.IsMatch(values.Last()))
                        {
                            values.RemoveAt(values.Count - 1);
                        }

                        RPN rpn = new RPN(rDigit, rBasic, rBrackets, values);
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

        public static bool IsValidInput(string input)
        {
            Func<string, bool> result = (x) => rDigit.IsMatch(x) || rSeparator.IsMatch(x) || rBasic.IsMatch(x) || rBrackets.IsMatch(x) || rOther.IsMatch(x);

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
