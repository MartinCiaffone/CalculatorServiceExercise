using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorService.Library.Tests
{
    [TestClass()]
    public class CalculatorTests
    {

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void AdditionOverflowTest()
        {
            _ = Calculator.Addition(new int[] { Int32.MaxValue, 1 });
        }
        [TestMethod()]
        public void AdditionTest()
        {
            Assert.AreEqual(Calculator.Addition(new int[] { 3, 3, 2 }), 8);
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void SubtractionOverflowTest()
        {
            _ = Calculator.Subtraction(Int32.MinValue, 1);
        }
        [TestMethod()]
        public void SubtractionTest()
        {
            Assert.AreEqual(Calculator.Subtraction(3, 7), -4);
        }

        [TestMethod()]
        public void MultiplicationTest()
        {
            Assert.AreEqual(Calculator.Multiplication(new int[] { 8, 3, 2 }), 48);
        }

        [TestMethod()]
        [ExpectedException(typeof(OverflowException))]
        public void DivisionOverflowTest()
        {
            _ = Calculator.Division(Int32.MinValue, -1);
        }
        [TestMethod()]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivisionByZeroTest()
        {
            _ = Calculator.Division(1, 0);
        }

        [TestMethod()]
        public void DivisionTest()
        {
            Assert.AreEqual(Calculator.Division(11, 5), (2, 1));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareRootingNegativeArgumentTest()
        {
            _ = Calculator.SquareRooting(-1);
        }
        [TestMethod()]
        public void SquareRootingTest()
        {
            Assert.AreEqual(Calculator.SquareRooting(16), (4));
        }


    }
}