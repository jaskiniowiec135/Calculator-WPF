using Calculator_WPF;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorTests.Basic_operations
{
    [TestClass]
    public class MultiplyTests
    {
        [TestMethod()]
        public void SimplestMultiplyTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "2*2";
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
        public void MultiplyThreeNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "2*2*2";
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
        public void MultiplyFourNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "2*3*5*7";
            string expected = "210";

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
        public void MultiplyTenNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "2*2*2*2*5*10*7*9*12*30";
            string expected = "18144000";

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
        public void MultiplyTwoCommaSeparatedNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "2,5*3,2";
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
        public void MultiplySixCommaSeparatedNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "5,5*10,32*7,1*9,7*12,51*30,1";
            string expected = "1471960,9039212";

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
        public void TryToMultiplyEmptyNumbersTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "5*****";
            string expected = "5";

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
        public void TryToMultiplyCommasTest()
        {
            // Arrange
            Calculator calc = new Calculator();
            string equation = "5*,*,*,*,*5";
            string expected = "25";

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
