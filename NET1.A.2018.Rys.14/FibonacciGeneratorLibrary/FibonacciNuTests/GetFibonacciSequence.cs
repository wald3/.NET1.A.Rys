using System;
using System.Numerics;
using FibonacciGeneratorLibrary;
using NUnit.Framework;

namespace Fibonacci.Nu.Tests
{
    [TestFixture]
    public class FibonacciGeneratorNuTests
    {
        [TestCase(12, new long[]{ 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 })]
        [TestCase(45, new long[]{ 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025, 121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887, 9227465, 14930352, 24157817, 39088169, 63245986, 102334155, 165580141, 267914296, 433494437, 701408733 })]
        public void GetFibonacciSequence_RangeOfSequenceLengths_FibonacciSequence(int length, 
            long[] expectedSequence)
        {
            BigInteger[] expected = new BigInteger[length];
            for (var i = 0; i < length; i++)
            {
                expected[i] = new BigInteger(expectedSequence[i]);
            }

            var actualSequence = FibonacciGenerator.GetFibonacciSequence(length);
            Assert.AreEqual(expected, actualSequence);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-100)]
        public void FibonacciGeneratorTest_InvalidData_ResultException(int value)
        {   
            Assert.Throws<ArgumentException>(() => FibonacciGenerator.GetFibonacciSequence(value));
        }
    }
}
