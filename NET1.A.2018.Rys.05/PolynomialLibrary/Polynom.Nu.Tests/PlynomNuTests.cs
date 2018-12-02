using PolynomialLibrary;
using NUnit.Framework;

namespace Polynomial.Nu.Tests
{
    [TestFixture]
    public class PlynomNuTests
    {
        private static double[] polyDataFirst = new[] { 2.123, 23, 457.9303, 23.8740000000, 5.23, 0 };
        private static double[] polyDataSecond = new[] { 2.123, 23.0001, 457.9303, 23.874, 5.23, 0 };

        private readonly Polynom polyFirst = new Polynom(polyDataFirst);
        private readonly Polynom polySecond = new Polynom(polyDataSecond);

        [TestCase(0.000000001, false)]
        [TestCase(0.0000001, false)]
        [TestCase(0.001, true)]
        [TestCase(0.1, true)]
        public void Equals_ChangeAccuracy_TestsWithHighAccuracyWillFall(double accuracy, bool result)
        {
            Polynom.accuracy = accuracy;

            Assert.AreEqual(result, (polyFirst == polySecond));
        }

        [Test] // !=
        public void Equals_NonEqualImplementationTest_ValidResult()
        {
            Assert.AreNotEqual(polyFirst, polySecond);
        }

        [Test] // ==
        public void Equals_EqualImplementationTest_ValidResult()
        {
            Assert.AreEqual(polyFirst, polyFirst);
        }

        [Test]
        public void Clone_OnePolynomialData_CloneIsDoneSuccessful()
        {
            var polyCloneOfFirst = (Polynom)polyFirst.Clone();

            Assert.AreEqual(polyFirst, polyCloneOfFirst);
        }

        [Test]
        public void Subtraction_SubWithPolynomial_ValidReturn()
        {
            var expected = (double[])polyDataFirst.Clone();

            for (var i = 0; i < polyDataFirst.Length; i++)
            {
                expected[i] -= polyDataSecond[i];
            }

            Assert.AreEqual(new Polynom(expected), polyFirst - polySecond);
        }

        [Test]
        public void Subtraction_SubWithInteger_ValidReturn()
        {
            var expected = (double[])polyDataFirst.Clone();
            var value = 5;

            for (var i = 0; i < polyDataFirst.Length; i++)
            {
                expected[i] -= value;
            }

            Assert.AreEqual(new Polynom(expected), polyFirst - value);
        }

        [Test]
        public void Adding_AddingAPolynomial_ValidReturn()
        {
            var expected = (double[])polyDataFirst.Clone();

            for (var i = 0; i < polyDataFirst.Length; i++)
            {
                expected[i] += polyDataSecond[i];
            }

            Assert.AreEqual(new Polynom(expected), polyFirst + polySecond);
        }

        [Test]
        public void Adding_AddingAnInteger_ValidReturn()
        {
            var expected = (double[])polyDataFirst.Clone();
            var value = 5;

            for (var i = 0; i < polyDataFirst.Length; i++)
            {
                expected[i] += value;
            }

            Assert.AreEqual(new Polynom(expected), polyFirst + value);
        }

        [Test]
        public void Multiplication_MultiByInteger_ValidReturn()
        {
            var expected = (double[])polyDataFirst.Clone();
            var value = 5;

            for (var i = 0; i < polyDataFirst.Length; i++)
            {
                expected[i] *= value;
            }

            Assert.AreEqual(new Polynom(expected), polyFirst * value);
        }

        [Test]
        public void Division_DivisionByInteger_ValidReturn()
        {
            var expected = (double[])polyDataFirst.Clone();
            var value = 5;

            for (var i = 0; i < polyDataFirst.Length; i++)
            {
                expected[i] /= value;
            }

            Assert.AreEqual(new Polynom(expected), polyFirst / value);
        }
    }
}
