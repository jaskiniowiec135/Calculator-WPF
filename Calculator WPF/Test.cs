using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Calculator_WPF
{
    class Test
    {
        Calculator calc;

        public Test(Calculator c)
        {
            calc = c;
        }

        public void DoTests()
        {
            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
            Test6();
            Test7();
            Test8();
        }

        void Test1()
        {
            calc.InputValue("2");
            calc.InputValue("+");
            calc.InputValue("2");
            calc.InputValue("=");

            if(calc.PrintedValues == "4")
            {
                Debug.Print("Test1 OK");
            }
            else
            {
                Debug.Print("Test1 FAIL");
            }

            calc.InputValue("");
        }

        void Test2()
        {
            calc.InputValue("2");
            calc.InputValue(",");
            calc.InputValue("5");
            calc.InputValue("-");
            calc.InputValue("1");
            calc.InputValue(",");
            calc.InputValue("5");
            calc.InputValue("*");
            calc.InputValue("1");
            calc.InputValue("0");
            calc.InputValue("=");

            if (calc.PrintedValues == "-12,5")
            {
                Debug.Print("Test2 OK");
            }
            else
            {
                Debug.Print("Test2 FAIL");
            }
            calc.InputValue("");
        }

        void Test3()
        {
            calc.InputValue("7");
            calc.InputValue("-");
            calc.InputValue("2");
            calc.InputValue("+");
            calc.InputValue("4");
            calc.InputValue("*");
            calc.InputValue("1");
            calc.InputValue("2");
            calc.InputValue("-");
            calc.InputValue("8");
            calc.InputValue("/");
            calc.InputValue("2");
            calc.InputValue("=");

            if (calc.PrintedValues == "49")
            {
                Debug.Print("Test3 OK");
            }
            else
            {
                Debug.Print("Test3 FAIL");
            }
            calc.InputValue("");
        }

        void Test4()
        {
            calc.InputValue("1");
            calc.InputValue("2");
            calc.InputValue("+");
            calc.InputValue("(");
            calc.InputValue("4");
            calc.InputValue("-");
            calc.InputValue("1");
            calc.InputValue(")");
            calc.InputValue("*");
            calc.InputValue("2");
            calc.InputValue("+");
            calc.InputValue("1");
            calc.InputValue("=");

            if (calc.PrintedValues == "19")
            {
                Debug.Print("Test4 OK");
            }
            else
            {
                Debug.Print("Test4 FAIL");
            }
            calc.InputValue("");
        }

        void Test5()
        {
            calc.InputValue("9");
            calc.InputValue("(");
            calc.InputValue("6");
            calc.InputValue("*");
            calc.InputValue("2");
            calc.InputValue(")");
            calc.InputValue("(");
            calc.InputValue("4");
            calc.InputValue("/");
            calc.InputValue("3");
            calc.InputValue(")");
            calc.InputValue("=");

            if (calc.PrintedValues == "144")
            {
                Debug.Print("Test5 OK");
            }
            else
            {
                Debug.Print("Test5 FAIL");
            }
            calc.InputValue("");
        }

        void Test6()
        {
            calc.InputValue("2");
            calc.InputValue("+");
            calc.InputValue("7");
            calc.InputValue("^");
            calc.InputValue("2");
            calc.InputValue("-");
            calc.InputValue("9");
            calc.InputValue("(");
            calc.InputValue("5");
            calc.InputValue("+");
            calc.InputValue("2");
            calc.InputValue(")");
            calc.InputValue("=");

            if (calc.PrintedValues == "-12")
            {
                Debug.Print("Test6 OK");
            }
            else
            {
                Debug.Print("Test6 FAIL");
            }
            calc.InputValue("");
        }

        void Test7()
        {
            calc.InputValue("5");
            calc.InputValue("+");
            calc.InputValue("(");
            calc.InputValue("2");
            calc.InputValue("*");
            calc.InputValue("4");
            calc.InputValue("(");
            calc.InputValue("7");
            calc.InputValue("-");
            calc.InputValue("3");
            calc.InputValue(")");
            calc.InputValue(")");
            calc.InputValue("=");


            if (calc.PrintedValues == "37")
            {
                Debug.Print("Test7 OK");
            }
            else
            {
                Debug.Print("Test7 FAIL");
            }
            calc.InputValue("");
        }

        void Test8()
        {
            calc.InputValue("2");
            calc.InputValue("+");
            calc.InputValue("5");
            calc.InputValue("3");
            calc.InputValue("-");
            calc.InputValue("6");
            calc.InputValue("^");
            calc.InputValue("2");
            calc.InputValue("*");
            calc.InputValue("(");
            calc.InputValue("3");
            calc.InputValue("-");
            calc.InputValue("1");
            calc.InputValue(")");
            calc.InputValue("^");
            calc.InputValue("3");
            calc.InputValue("=");

            if(calc.PrintedValues == "-233")
            {
                Debug.Print("Test8 OK");
            }
            else
            {
                Debug.Print("Test8 FAIL");
            }
            calc.InputValue("");
        }
    }
}
