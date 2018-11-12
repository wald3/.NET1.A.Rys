using System;
using System.Diagnostics;
using ConverterLibrary;
using NUnit.Framework;

namespace GCDAlgorithms.Nu.Tests
{
    [TestFixture]
    public class GCDAlgorithmsNuTests
    {
        [Test]
        public void GCDEuclid_TenAndFive_Five()
        {
            var expected = 5;

            var actual = GCDAlgorithm.FindGCDEuclid(10, 5);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 4, 4)]
        [TestCase(17, 29, 1)]
        [TestCase(123, 3, 3)]
        [TestCase(150, 50, 50)]
        [TestCase(-100, 80, 20)]
        [TestCase(152, 50, 2)]
        [TestCase(0, 0, 0)]
        public void GCDEuclid_TenAndFive_Five(int first, int second, int expected)
        {
            var actual = GCDAlgorithm.FindGCDEuclid(first, second);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0, 4)]
        [TestCase(17, 29)]
        [TestCase(123, 3)]
        [TestCase(150, 50)]
        [TestCase(-100, 80)]
        [TestCase(152, 50)]
        [TestCase(0, 0)]
        [TestCase(100046300, 10034000)]
        public void GCD_StopWatchTest(int first, int second)
        {
            Stopwatch sw = new Stopwatch();
            

            sw.Start();
            GCDAlgorithm.FindGCDEuclid(first, second);
            sw.Stop();
            var euclid = sw.Elapsed;

            sw.Reset();

            sw.Start();
            GCDAlgorithm.FindGCDShtein(first, second);
            sw.Stop();
            var shtein = sw.Elapsed;

            Debug.WriteLine($"euclid: {euclid}, shtein: {shtein}");
            Assert.AreNotSame(euclid, shtein);
        }

    }
}
