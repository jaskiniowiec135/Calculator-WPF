using Calculator_WPF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Basic_operations
{
    [TestClass]
    public class SubstractTests
    {
        [TestMethod()]
        public void SimplestSubstractTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "4-2";
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

        [TestMethod()]
        public void SubstractThreeNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "8-2-2-2";
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

        [TestMethod()]
        public void SubstractFourNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "10-4-2-2-2";
            string expected = "0";

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
        public void SubstractTenNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "100-4-21-22-11-3-8-1-1-1-10";
            string expected = "18";

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
        public void SubstractTwoCommaSeparatedNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "10,3-2,5-3,2";
            string expected = "4,6";

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
        public void SubstractSixCommaSeparatedNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "100,35-2,5-3,2-19,3-12,6-2,3-10,03";
            string expected = "50,42";

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
        public void TryToSubstractEmptyNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "1---";
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

        [TestMethod()]
        public void TryToSubstractCommasTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "1-,-,-,-1";
            string expected = "0";

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
