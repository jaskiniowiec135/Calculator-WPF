using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calculator_WPF
{
    class RPN
    {
        Regex rDigit;
        Regex rSpecial;
        Regex rOther;
        List<string> values;

        public RPN(Regex rDig, Regex rSpec, Regex rOth, List<string> val)
        {
            rDigit = rDig;
            rSpecial = rSpec;
            rOther = rOth;
            values = val;
        }

        public void PrepareRPN()
        {
            List<string> output = new List<string>();
            List<string> operators = new List<string>();

            while (values.Count > 0)
            {
                switch (values[0])
                {
                    case var token when rDigit.IsMatch(token):
                        if(output.Count == 0 && operators.Count == 1)
                        {
                            if(operators[0] == "-")
                            {
                                operators.Clear();
                                output.Add("-" + values[0]);
                            }
                            else if(operators[0] == "(")
                            {
                                output.Add(values[0]);
                            }
                        }
                        else
                        {
                            output.Add(values[0]);
                        }
                        break;
                    case var token when rSpecial.IsMatch(token):
                        if (token == "(")
                        {
                            operators.Add("(");
                            break;
                        }
                        else if (token == ")")
                        {
                            while (operators.Last() != "(")
                            {
                                output.Add(operators.Last());
                                operators.RemoveAt(operators.Count - 1);
                            }
                            operators.RemoveAt(operators.Count - 1);
                            break;
                        }

                        int currentPrecedence = checkPrecedence(token);
                        while (operators.Count != 0 && (currentPrecedence > checkPrecedence(operators.Last()) |
                              (currentPrecedence == checkPrecedence(operators.Last()) & operators.Last() != "^") &
                              operators.Last() != "("))
                        {
                            output.Add(operators.Last());
                            operators.RemoveAt(operators.Count - 1);
                        }
                        operators.Add(token);
                        break;

                }
                values.RemoveAt(0);
            }

            if (operators.Count > 0)
            {
                operators.Reverse();
                output.AddRange(operators);
                operators.Clear();
            }

            values.AddRange(output);
        }

        public void countRPN()
        {
            while (values.Count > 1)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    if (!rDigit.IsMatch(values[i]))
                    {
                        double a = double.Parse(values[i - 2]);
                        double b = double.Parse(values[i - 1]);
                        string special = values[i];

                        switch (special)
                        {
                            case "^":
                                values[i - 2] = (Math.Pow(a, b)).ToString();
                                break;
                            case "*":
                                values[i - 2] = (a * b).ToString();
                                break;
                            case "/":
                                values[i - 2] = (a / b).ToString();
                                break;
                            case "+":
                                values[i - 2] = (a + b).ToString();
                                break;
                            case "-":
                                values[i - 2] = (a - b).ToString();
                                break;

                        }

                        values.RemoveRange(i - 1, 2);
                        i = 0;
                    }
                }
            }
        }

        private static int checkPrecedence(string operand)
        {
            int precedence = -1;
            string[][] operatorsPrecedence = new string[4][] {
                                            new string[]{"^"},
                                            new string[]{ @"*",@"/"},
                                            new string[]{ "+", "-" },
                                            new string[]{"(",")" }};


            for (int i = 0; i < operatorsPrecedence.Length; i++)
            {
                for (int j = 0; j < operatorsPrecedence[i].Length; j++)
                {
                    if (operand == operatorsPrecedence[i][j])
                    {
                        precedence = i;
                        goto Exit;
                    }
                }
            }

            Exit:

            return precedence;
        }

    }
}
