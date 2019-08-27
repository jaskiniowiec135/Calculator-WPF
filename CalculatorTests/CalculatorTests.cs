using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator_WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_WPF.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void CalculatorTest()
        {

        }

        [TestMethod()]
        public void InputValueTest()
        {

        }

        #region Counting

        [TestCategory("Basic counting")]
        [TestMethod()]
        public void AddTest()
        {

            // Arrange

            Calculator calc = new Calculator();
            string equation = "2+2=";
            string expected = "4";

            // Act

            foreach(char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Basic counting")]
        [TestMethod()]
        public void SubstractTest()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "12-9=";
            string expected = "3";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }


            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);

        }

        [TestCategory("Basic counting")]
        [TestMethod()]
        public void MultiplyTest()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "12*4=";
            string expected = "48";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Basic counting")]
        [TestMethod()]
        public void DivideTest()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "30/6=";
            string expected = "5";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Basic counting")]
        [TestMethod()]
        public void RaiseTo2PowerTest()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "8^2=";
            string expected = "64";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Basic counting")]
        [TestMethod()]
        public void RaiseToAnyPowerTest()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "2^3=";
            string expected = "8";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Advanced counting")]
        [TestMethod()]
        public void BracketsTest()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "2+(7*3)=";
            string expected = "23";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Advanced counting")]
        [TestMethod()]
        public void NegativeNumbersTest()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "-7+3=";
            string expected = "-4";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Advanced counting")]
        [TestMethod()]
        public void OrderOfCountingTest1()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "2+5*4-6/3=";
            string expected = "20";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Advanced counting")]
        [TestMethod()]
        public void OrderOfCountingTest2()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "(8*2)-6*9=";
            string expected = "-38";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Advanced counting")]
        [TestMethod()]
        public void OrderOfCountingTest3()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "(3+4)(2-7)=";
            string expected = "-35";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Advanced counting")]
        [TestMethod()]
        public void OrderOfCountingTest4()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "-5(5*2)+4*2=";
            string expected = "-42";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        [TestCategory("Advanced counting")]
        [TestMethod()]
        public void OrderOfCountingTest5()
        {
            // Arrange

            Calculator calc = new Calculator();
            string equation = "(12*4)^2-81/3=";
            string expected = "2277";

            // Act

            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }

            // Assert

            Assert.AreEqual(calc.PrintedValues, expected);
        }

        #endregion
    }
}