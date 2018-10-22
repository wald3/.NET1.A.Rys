using System;
using NUnit.Framework;
using NumberAlgorithmsLibrary;

namespace FindMaxElement.Nu.Tests
{
    [TestFixture]
    public class FindMaxElementRecursionNuTests
    {
        [TestCase(new[] { 9 })]
        [TestCase(new[] { 23, 5 })]
        [TestCase(new[] { 76, 34, 54, 2, 72, 453, 64, 745, 62 })]
        [TestCase(new[] { 9, 8, 7, -6, 6, 5, 4, 3, 2, 1, 23, 4, 5, 4, 32, 0 })]
        [TestCase(new[] { 1, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, -1 })]
        [TestCase(new[] { 8, 34, 5, 24, 787, 2, -3567, 2, 324, 45, 234, 45 })]
        public void FindMaxElem_StaticUnsortedArray_MaxElement(int[] unsortedArray)
        {
            var max = MaxElementRecursion.FindMaxElem(unsortedArray);
            Array.Sort(unsortedArray);

            Assert.AreEqual(unsortedArray[unsortedArray.Length - 1], max);
        }

        [Test]
        public void FindMaxElem_NullReference_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => MaxElementRecursion.FindMaxElem(null));
        }

        [Test]
        public void FindMaxElem_EmptyArray_ArgumentNullException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => MaxElementRecursion.FindMaxElem(new int[0]));
        }

    }
}
