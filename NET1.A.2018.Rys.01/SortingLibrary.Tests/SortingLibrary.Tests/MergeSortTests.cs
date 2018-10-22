using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using HelperMethods;

namespace SortingLibrary.Tests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void Sort_SmallEvenCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(10000, 30000, true);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_SmallOddCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(10000, 30000, false);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ParametrizeSmallEvenCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(10000, 30000, true);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ParametrizeSmallOddCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(10000, 30000, false);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_MediumEvenCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(30000, 70000, true);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_MediumOddCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(30000, 70000, false);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ParametrizeMediumEvenCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(30000, 70000, true);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ParametrizeMediumOddCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(30000, 70000, false);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_BigEvenCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(100000, 500000, true);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_BigOddCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(100000, 500000, false);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ParametrizeBigEvenCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(100000, 500000, true);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ParametrizeBigOddCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(100000, 500000, false);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ExtremeEvenCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(1500000, 5000000, true);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ExtremeOddCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(1500000, 5000000, false);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ParametrizeExtremeEvenCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(1500000, 5000000, true);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_ParametrizeExtremeOddCountArraySort_SortedArray()
        {
            var actual = Helpers.ArrayGen(1500000, 5000000, false);
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_StaticDataSmallArraySort_SortedArray()
        {
            var actual = new[] { 8, 4, 1, 7, 24, 5, -82, 1, 88, 0, 234, 768, 23, 1, 74, 23 };
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_StaticDataMediumArraySort_SortedArray()
        {
            var actual = new[] { 8, 4, 1, 7, 24, 5, -82, 1, 59, 763, 5, 353, -456, 765643, 45,
                265, -56, 73, 451, 3, -2357, 789, 7843, 23, 643, 446, 843, 4, -3976, 351, 698,
                -41635, 46, 646, 3, 4, -88, 0, 234, -768, 23, 1, 74, 23, 835, 433, 133, -183};
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Sort_StaticDataBigArraySort_SortedArray()
        {
            var actual = new[] { 8, 4, 1, 7, 24, 5, -82, 1, 59, 763, 5, 353, -456, 765643, 45,
                265, -56, 73, 451, 3, -57, 789, 7843, 23, -82, 1, 59, 76 -82, 10, 59, 763, 51,
                123, -56, 73, 451, 3, 7, 789, 7843,3, 5, 353, -456, 765,- 643, 4325, 934, -12,
                285, -52, 73, 451, 3, -557, 789, -82, 1, 59, 763, 5, 353, -456, 7625, 643, 68,
                225, -76, 73, 451, 3, 57, 789, 7843, 7843, 643, 44 -82, 1, 59, 763, 5, 35, 52,
                565, -16, -82, 1, 59, 763, 5, 353, -456, 765643, 45, 7843,3, 5, 353, -456, 35,
                865, -86, 73, 451, 39, 57, 789, 7843, 73, 451, 3, -2357, 789, 7843,6, 843, -4,
                -4635, 46, 646, 3, 4, -88, 0, 234, -82, 1, 59, 76233, 5, 353, -456, 76243, 49,
                995, 106, 73, 451, 3, 57, 789, 7843,  -82, 1, 59, 763, 5, 353, -456, 4643, 45,
                275, 936, 73, 451, 3, -57, 789, 7843,-768, -82, 1, 59, 763, 57, 353, -456, 45,
                365, 636, 73, 451, 3, -2357, 789, 7843, 23, 184, 74, 23, 835, 433, 133, -183};
            var expected = new int[actual.Length];
            actual.CopyTo(expected, 0);

            Array.Sort(expected);
            MergeSort.Sort(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Sort_NullArraySort_ArgumentNullException()
        {
            MergeSort.Sort(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sort_ParametrizeArraySort_StartPositionArgumentOutOfRangeException()
        {
            var actual = Helpers.ArrayGen(0, 30, false);
            MergeSort.Sort(actual, -1, actual.Length - 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sort_ParametrizeArraySort_StartPositionIsGraterThatEndPositionArgumentOutOfRangeException()
        {
            var actual = Helpers.ArrayGen(0, 30, false);
            MergeSort.Sort(actual, actual.Length, actual.Length - 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Sort_ParametrizeArraySort_EndPositionArgumentOutOfRangeException()
        {
            var actual = Helpers.ArrayGen(0, 30, true);
            MergeSort.Sort(actual, 0, actual.Length + 10);
        }

    }
}
