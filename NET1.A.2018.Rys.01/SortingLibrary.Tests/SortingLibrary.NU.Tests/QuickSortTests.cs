using System;
using NUnit.Framework;
using HelperMethods;

namespace SortingLibrary.NU.Tests
{
    [TestFixture]
    public class QuickSortTests
    {
        [TestCase(10, 50, true)]
        [TestCase(10, 50, false)]
        [TestCase(100, 500, true)]
        [TestCase(100, 500, false)]
        [TestCase(1000, 5000, true)]
        [TestCase(1000, 5000, false)]
        [TestCase(10000, 50000, true)]
        [TestCase(10000, 50000, false)]
        [TestCase(100000, 500000, true)]
        [TestCase(100000, 500000, false)]
        [TestCase(1000000, 5000000, true)]
        [TestCase(1000000, 5000000, false)]
        [TestCase(10000000, 50000000, true)]
        [TestCase(10000000, 50000000, false)]
        public void Sort_InputArray_SortedArray(int loBound, int upBound, bool isEven)
        {
            var actual = Helpers.ArrayGen(loBound, upBound, isEven);
            var expected = new int[actual.Length];

            actual.CopyTo(expected, 0);
            Array.Sort(expected);
            QuickSort.Sort(actual);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(100000, 500000, true)]
        [TestCase(100000, 500000, false)]
        [TestCase(1000000, 5000000, true)]
        [TestCase(1000000, 5000000, false)]
        [TestCase(10000000, 50000000, true)]
        [TestCase(10000000, 50000000, false)]
        public void ParametrizeSort_InputArray_SortedArray(int loBound, int upBound, bool isEven)
        {
            var actual = Helpers.ArrayGen(loBound, upBound, isEven);
            var expected = new int[actual.Length];

            actual.CopyTo(expected, 0);
            Array.Sort(expected);
            QuickSort.Sort(actual, 0, actual.Length - 1);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 9, 8, 7, 5, -23, 5, 3, 2, 6, -1, 2, 0 })]
        [TestCase(new int[] { 19, 2, 34, 534, 1, 455, 134, 3, 5142, 312, })]
        [TestCase(new int[] { 6434, -2343, 234, 4234, 78632, -46, 234, 0, 254 })]
        public void Sort_StaticInputArray_SortedArray(int[] actual)
        {
            var expected = new int[actual.Length];

            actual.CopyTo(expected, 0);
            Array.Sort(expected);
            QuickSort.Sort(actual, 0, actual.Length - 1);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Sort_UnsortedArray_ArgumentNullException()
        {
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => QuickSort.Sort(array));
        }

        [Test]
        public void Sort_UnsortedArray_StartPositionArgumentOutOfRangeException()
        {
            var array = Helpers.ArrayGen(100, 1000, true);
            Assert.Throws<ArgumentOutOfRangeException>(() => QuickSort.Sort(array, -10, array.Length - 1));
        }

        [Test]
        public void Sort_UnsortedArray_EndPositionArgumentOutOfRangeException()
        {
            var array = Helpers.ArrayGen(100, 1000, true);
            Assert.Throws<ArgumentOutOfRangeException>(() => QuickSort.Sort(array, 0, array.Length + 10));
        }

        [Test]
        public void Sort_UnsortedArray_StartPositionIsGraterThanEndPositionArgumentOutOfRangeException()
        {
            var array = Helpers.ArrayGen(100, 10000, true);
            Assert.Throws<ArgumentException>(() => QuickSort.Sort(array, array.Length - 10, array.Length - 20));
        }

    }
}
