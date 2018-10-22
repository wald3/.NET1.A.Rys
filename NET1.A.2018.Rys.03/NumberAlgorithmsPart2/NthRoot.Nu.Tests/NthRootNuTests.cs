using NumberAlgorithmsPart2;
using NUnit.Framework;
using System;

namespace NthRoot.Nu.Tests
{
    [TestFixture]
    public class NthRootNuTests
    {
        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001, 0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindRoot_RootedValuePowerAccuracy_NthRoot(double value, double power, double accuracy, double actual)
        {
            var myRoot = FindNthRoot.FindRoot(value, power, accuracy);

            Assert.AreEqual(myRoot, actual, accuracy);
        }

        [TestCase(-0.01, 2, 0.0001)]
        public void FindRoot_NegativeNumberWithEvenPower_ArgumentException(double value, double power, double accuracy)
        {
            Assert.Throws<ArgumentException>(() => FindNthRoot.FindRoot(value, power, accuracy));
        }

        [TestCase(0.001, 0.0001, 0.0001)]
        public void FindRoot_PowerEqualsAccuracy_ArgumentException(double value, double power, double accuracy)
        {
            Assert.Throws<ArgumentException>(() => FindNthRoot.FindRoot(value, power, accuracy));
        }

        [TestCase(0.01, 2, -1)]
        public void FindRoot_NegativeAccuracy_ArgumentException(double value, double power, double accuracy)
        {
            Assert.Throws<ArgumentException>(() => FindNthRoot.FindRoot(value, power, accuracy));
        }
    }
}
