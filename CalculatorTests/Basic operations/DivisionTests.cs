using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator_WPF;

namespace CalculatorTests.Basic_operations
{
    [TestClass]
    public class DivisionTests
    {
        [TestMethod]
        public void SimplestDivideTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "4/2";
            string expected = "2";

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
        public void DivideThreeNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "12/2/2/3";
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

        [TestMethod]
        public void DivideFourNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "24/2/2/2/2";
            string expected = "1,5";

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
        public void DivideTenNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "4096/2/2/2/2/2/2/2/1/2/2";
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
        public void DivideTwoCommaSeparatedNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "6,3/2,4";
            string expected = "2,625";

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
        public void DivideSixCommaSeparatedNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "12515,53/1,5/6,4/75,2/0,5/12,73/24,26";
            string expected = "0,112271872870838";

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
        public void TryToDivideEmptyNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "7////";
            string expected = "7";

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
        public void TryToDivideCommasTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "7/,/,/,/7";
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
