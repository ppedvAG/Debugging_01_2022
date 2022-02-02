using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_3_and_6_results_9()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(3, 6);

            //Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(0, 0, 0)]
        [DataRow(3, 6, 9)]
        [DataRow(-5, -5, -10)]
        public void Sum(int a, int b, int exp)
        {
            Calc calc = new Calc();

            int result = calc.Sum(a, b);

            Assert.AreEqual(exp, result);
        }

        [TestMethod]
        public void Sum_MAX_or_MIN_and_1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [TestMethod]
        public void Sum_MIN_and_n1_throws_OverflowException()
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MinValue, -1));
        }

    }
}
