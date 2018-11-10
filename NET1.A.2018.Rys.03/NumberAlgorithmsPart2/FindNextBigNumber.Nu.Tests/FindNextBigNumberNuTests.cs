using System;
using NumberAlgorithmsPart2;
using NUnit.Framework;


namespace FindNextBigNumber.Nu.Tests
{
    [TestFixture]
    public class FindNextBigNumberNuTests
    {
        [TestCase(10, -1)]
        [TestCase(20, -1)]
        [TestCase(12, 21)]
        [TestCase(513, 531)]
        [TestCase(2017, 2071)]
        [TestCase(414, 441)]
        [TestCase(144, 414)]
        [TestCase(1234321, 1241233)]
        [TestCase(1234126, 1234162)]
        [TestCase(3456432, 3462345)]
        public void FindNextBigNumber_Number_ValidOutPut(int number, int expected)
        {
            Assert.AreEqual(expected, FindNextBiggerNumber.FindNextBigNumber(number));
        }

        [TestCase(-10)]
        [TestCase(-5123)]
        public void FindNextBigNumber_Number_ValidOutPut(int number)
        {
            Assert.Throws<ArgumentException>(() => FindNextBiggerNumber.FindNextBigNumber(number));
        }


    }
}
