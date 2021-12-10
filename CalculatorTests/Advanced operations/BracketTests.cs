using Calculator_WPF;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorTests.Advanced_operations
{
    [TestClass]
    public class BracketTests
    {
        [TestMethod]
        public void SimplestBracketTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "4+(2+2)";
            string expected = "8";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod]
        public void TwoNestedBracketsTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "4+(2+2+(18-7))";
            string expected = "19";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod]
        public void ThreeNestedBracketsTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "4+(2+2+(18-7-(7+2)))";
            string expected = "10";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod]
        public void MultiplyTwoBracketsTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "(2+7)*(7+3)";
            string expected = "90";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod]
        public void MultiplyThreeBracketsTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "(2+7)*(7+3)*(6-2)";
            string expected = "360";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod]
        public void MultiplyTwoNestedBracketsTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "(2*(7-3))*(4+(8*7))";
            string expected = "480";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod]
        public void MultiplyTwoNestedNotClosedBracketsTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "(2*(7-3";
            string expected = "8";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }
    }
}
