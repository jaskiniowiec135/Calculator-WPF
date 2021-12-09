using Calculator_WPF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Basic_operations
{
    [TestClass]
    public class AddTests
    {
        [TestMethod()]
        public void SimplestAddTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "2+2";
            string expected = "4";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod()]
        public void AddingThreeNumbers()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "2+2+2";
            string expected = "6";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod()]
        public void AddingFourNumbers()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "2+2+2+2";
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

        [TestMethod()]
        public void AddingTenNumbers()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "1+1+1+1+1+1+1+1+1+1";
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

        [TestMethod()]
        public void AddingTwoCommaSeparatedTwoNumbers()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "1,5+2,5";
            string expected = "4";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod()]
        public void AddingSixCommaSeparatedTwoNumbers()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "1,5+2,5+3,1+0,7+2,3+3,5";
            string expected = "13,6";

            // Act
            foreach (char s in equation)
            {
                calc.InputValue(s.ToString());
            }
            calc.InputValue(SpecialSignals.Calculate.ToString());

            // Assert
            Assert.AreEqual(expected, calc.PrintedValues);
        }

        [TestMethod()]
        public void TryToAddEmptyValues()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "1+++";
            string expected = "1";

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
