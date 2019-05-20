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
            rSpecial = new Regex(@"[+-/()^*]");
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
                            if (input == "," && values.Last().Contains(","))
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
                                    values.Add(input);
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
                        Count();
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
            Func<string, bool> result = (x) => rDigit.IsMatch(x) || rSpecial.IsMatch(x) || input == "" || input == "=";

            return result(input);
        }

        #region Counting

        public void Count()
        {
            printedValues = "";            
            
            while(openedBrackets > 0)
            {
                values.Add(")");
            }

            while(values.IndexOf(")") != -1)
            {
                List<string> valuesInsideBrackets = new List<string>();
                int startIndex = -1, endIndex = -1;
                endIndex = values.IndexOf(")");

                startIndex = values.LastIndexOf("(", endIndex);

                valuesInsideBrackets.AddRange(values.GetRange(startIndex + 1,endIndex - startIndex - 1));

                values.RemoveRange(startIndex, endIndex - startIndex + 1);
                values.Insert(startIndex, CountInsideBrackets(valuesInsideBrackets));
            }

            while (values.Contains("^"))
            {
                int index = values.IndexOf("^");
                int number = int.Parse(values[index - 1]);
                int power = int.Parse(values[index + 1]);

                values.RemoveRange(index - 1, 3);
                values.Insert(index - 1, CountPower(number, power));
            }

            printedValues = CountRest(values);

            values.Clear();
            values.Add(printedValues);
        }

        string CountInsideBrackets(List<string> val)
        {
            string output = "";

            while (val.Contains("^"))
            {
                int index = val.IndexOf("^");
                int number = index - 1;
                int power = index + 1;

                val.RemoveRange(val.IndexOf("^") - 1,val.IndexOf("^" + 1));
                val.Insert(index, CountPower(number, power));
            }

            output = CountRest(val);

            return output;
        }

        string CountPower(int num, int pow)
        {
            string output = "";

            output = Math.Pow(num, pow).ToString();

            return output;
        }

        string CountRest(List<string> val)
        {
            string output = "";

            while(val.Contains("*") || val.Contains("/"))
            {
                int indexMul = val.IndexOf("*");
                int indexDiv = val.IndexOf("/");

                if(indexDiv == -1 || (indexMul < indexDiv && indexMul != -1))
                {
                    val[indexMul - 1] = CountMulDiv(Convert.ToDouble(val[indexMul - 1]), Convert.ToDouble(val[indexMul + 1]), "*");
                    val.RemoveRange(indexMul, 2);
                }
                else
                {
                    val[indexDiv - 1] = CountMulDiv(Convert.ToDouble(val[indexDiv - 1]), Convert.ToDouble(val[indexDiv + 1]), "/");
                    val.RemoveRange(indexDiv, 2);
                }
            }

            while(val.Contains("+") || val.Contains("-"))
            {
                int indexPlus = val.IndexOf("+");
                int indexMinus = val.IndexOf("-");

                if(indexMinus == -1 ||(indexPlus < indexMinus && indexPlus != -1))
                {
                    val[indexPlus - 1] = CountPlusMin(Convert.ToDouble(val[indexPlus - 1]), Convert.ToDouble(val[indexPlus + 1]), "+");
                    val.RemoveRange(indexPlus, 2);
                }
                else
                {
                    val[indexMinus - 1] = CountPlusMin(Convert.ToDouble(val[indexMinus - 1]), Convert.ToDouble(val[indexMinus + 1]), "-");
                    val.RemoveRange(indexMinus, 2);
                }
            }

            output = val[0];

            return output;
        }

        string CountMulDiv(double a, double b, string sign)
        {
            string output = "";

            if(sign == "*")
            {
                output = (a * b).ToString();
            }
            else
            {
                output = (a / b).ToString();
            }

            return output;
        }

        string CountPlusMin(double a, double b, string sign)
        {
            string output = "";

            if(sign == "+")
            {
                output = (a + b).ToString();
            }
            else
            {
                output = (a - b).ToString();
            }

            return output;
        }

        #endregion

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
