using System;
using System.Diagnostics;
using ConverterLibrary;
using NUnit.Framework;

namespace GCDAlgorithms.Nu.Tests
{
    public class EuclidGCD : IGCDFinder
    {
        public int FindGcd(int firstValue, int secondValue)
        {
            while (firstValue != 0)
            {
                firstValue = secondValue % (secondValue = firstValue);
            }

            return secondValue;
        }
    }

    public class SteinGCD : IGCDFinder
    {
        public int FindGcd(int first, int second)
        {
            if (first == 0) return second;
            if (second == 0) return first;
            if (first == second) return first;

            var value1IsEven = (first & 1) == 0;
            var value2IsEven = (second & 1) == 0;

            if (value1IsEven && value2IsEven)
            {
                return FindGcd(first >> 1, second >> 1) << 1;
            }

            if (value1IsEven)
            {
                return FindGcd(first >> 1, second);
            }

            if (value2IsEven)
            {
                return FindGcd(first, second >> 1);
            }

            if (first > second)
            {
                return FindGcd((first - second) >> 1, second);
            }
            else
            {
                return FindGcd(first, (second - first) >> 1);
            }
        }
    }

    [TestFixture]
    public class GCDAlgorithmsNuTests
    {
        #region EuclidGCDTests

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

        [TestCase(new []{ -24, -48, -9, 21, 21 }, 3)]
        [TestCase(new[] { -10, 30, -2, -6, -28, 8 }, 2)]
        [TestCase(new[] { 33, 12, -36, -3, 45, -24, -48 }, 3)]
        [TestCase(new[] { 26, -39, -13, 39, 26 }, 13)]
        [TestCase(new[] { 25, -35, 40, -40, 10, -40, -45 }, 5)]
        [TestCase(new[] { -12, -4, 44, -12, 20 }, 4)]
        public void GCDEuclid_ParamsInput_ValidOutPut(int[] intValues, int expected)
        {
            Assert.AreEqual(expected, GCDAlgorithm.FindGCDEuclid(intValues));
        }

        #endregion

        #region SteinGCDTests

        [TestCase(0, 4, 4)]
        [TestCase(17, 29, 1)]
        [TestCase(123, 3, 3)]
        [TestCase(150, 50, 50)]
        [TestCase(-100, 80, 20)]
        [TestCase(152, 50, 2)]
        [TestCase(0, 0, 0)]
        public void GCDStein_TenAndFive_Five(int first, int second, int expected)
        {
            var actual = GCDAlgorithm.FindGCDStein(first, second);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new[] { -24, -48, -9, 21, 21 }, 3)]
        [TestCase(new[] { -10, 30, -2, -6, -28, 8 }, 2)]
        [TestCase(new[] { 33, 12, -36, -3, 45, -24, -48 }, 3)]
        [TestCase(new[] { 26, -39, -13, 39, 26 }, 13)]
        [TestCase(new[] { 25, -35, 40, -40, 10, -40, -45 }, 5)]
        [TestCase(new[] { -12, -4, 44, -12, 20 }, 4)]
        public void GCDStein_ParamsInput_ValidOutPut(int[] intValues, int expected)
        {
            Assert.AreEqual(expected, GCDAlgorithm.FindGCDStein(intValues));
        }

        #endregion

        #region StopWatchTests
   
        [TestCase(100046300, 10034000)]
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
            GCDAlgorithm.FindGCDStein(first, second);
            sw.Stop();
            var shtein = sw.Elapsed;

            Debug.WriteLine($"euclid: {euclid}, shtein: {shtein}");
            Assert.AreNotSame(euclid, shtein);
        }

        #endregion

        #region InterfaceTests

        [TestCase(new [] { 26, -39, -13, 39, 26 })]
        [TestCase(new[] { 25, -35, 40, -40, 10, -40, -45 })]
        [TestCase(new[] { -12, -4, 44, -12, 20 })]
        public void FindGCD_EuclidClassObject_ValidValue(int[] array)
        {
           Assert.AreEqual(GCDAlgorithm.FindGCDEuclid(array), GCDAlgorithm.FindGCD(new EuclidGCD(), array));
        }

        [TestCase(new[] { 26, -39, -13, 39, 26 })]
        [TestCase(new[] { 25, -35, 40, -40, 10, -40, -45 })]
        [TestCase(new[] { -12, -4, 44, -12, 20 })]
        public void FindGCD_SteinClassObject_ValidValue(int[] array)
        {
            Assert.AreEqual(GCDAlgorithm.FindGCDStein(array), GCDAlgorithm.FindGCD(new SteinGCD(), array));
        }

        #endregion

        #region DelegateTests

        [TestCase(new[] { 26, -39, -13, 39, 26 })]
        [TestCase(new[] { 25, -35, 40, -40, 10, -40, -45 })]
        [TestCase(new[] { -12, -4, 44, -12, 20 })]
        public void FindGCD_EuclidDelegate_ValidOutPut(int[] array)
        {
            Func<int,int,int> delegateGcd = new EuclidGCD().FindGcd;  
            Assert.AreEqual(GCDAlgorithm.FindGCDEuclid(array), GCDAlgorithm.FindGCD(delegateGcd, array));
        }

        [TestCase(new[] { 26, -39, -13, 39, 26 })]
        [TestCase(new[] { 25, -35, 40, -40, 10, -40, -45 })]
        [TestCase(new[] { -12, -4, 44, -12, 20 })]
        public void FindGCD_SteinDelegate_ValidOutPut(int[] array)
        {
            Func<int, int, int> delegateGcd = new SteinGCD().FindGcd;
            Assert.AreEqual(GCDAlgorithm.FindGCDStein(array), GCDAlgorithm.FindGCD(delegateGcd, array));
        }

        #endregion
    }
}
