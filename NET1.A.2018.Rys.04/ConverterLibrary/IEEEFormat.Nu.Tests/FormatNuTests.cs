using System;
using ConverterLibrary;
using NUnit.Framework;

namespace IEEEFormat.Nu.Tests
{
    [TestFixture]
    public class FormatNuTests
    {
        #region TestCases
        [TestCase(new[] { -255.255 }, new[] { "1100000001101111111010000010100011110101110000101000111101011100" })]
        [TestCase(new[] { 255.255 }, new[] { "0100000001101111111010000010100011110101110000101000111101011100" })]
        [TestCase(new[] { 4294967295.0 }, new[] { "0100000111101111111111111111111111111111111000000000000000000000" })]
        [TestCase(new[] { double.MinValue }, new[] { "1111111111101111111111111111111111111111111111111111111111111111" })]
        [TestCase(new[] { double.MaxValue }, new[] { "0111111111101111111111111111111111111111111111111111111111111111" })]
        [TestCase(new[] { double.Epsilon }, new[] { "0000000000000000000000000000000000000000000000000000000000000001" })]
        [TestCase(new[] { double.NaN }, new[] { "1111111111111000000000000000000000000000000000000000000000000000" })]
        [TestCase(new[] { double.NegativeInfinity }, new[] { "1111111111110000000000000000000000000000000000000000000000000000" })]
        [TestCase(new[] { double.PositiveInfinity }, new[] { "0111111111110000000000000000000000000000000000000000000000000000" })]
        [TestCase(new[] { -0.0 }, new[] { "1000000000000000000000000000000000000000000000000000000000000000" })]
        [TestCase(new[] { 0.0 }, new[] { "0000000000000000000000000000000000000000000000000000000000000000" })]
        #endregion
        public void Format_ArrayOfDoubles_Binary64bitCode(double[] doubles, string[] actual)
        {
            var expected = doubles.Format();
            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void LINQMath_AnswerFromVSAndAnswerFromLINQPad5_TheyAreNotEquals()
        {
            var expected = IEEEFormater.VSMulti(); // result (13.6941646913505d * 20.8015918046243d) from VisualStudio
            var actual = 284.860424014772d; // result (13.6941646913505d * 20.8015918046243d) from LINQpad5 
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public void Format_NullReference_ArgumentNullException()
        {
            double[] nullArray = null;
            Assert.Throws<ArgumentNullException>(() => nullArray.Format());
        }

        [Test]
        public void Format_EmptyArray_ArgumentOutOfRangeException()
        {
            var emptyArray = new double[] {};
            Assert.Throws<ArgumentOutOfRangeException>(() => emptyArray.Format());
        }
    }
}
