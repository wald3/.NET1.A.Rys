using System;
using System.Collections;
using System.Collections.Generic;
using JaggedArrayLibrary;
using NUnit.Framework;

namespace JaggedArray.Nu.Tests
{
    [TestFixture]
    public class JaggedArrayMaxElementSort
    {
        [Test]
        public void Sort_UnsortedJaggedArrayWithMaxElementComparator_SortedInRightWayArray()
        {
            var unsorted = new[]
            {
                new[] { 1, 2, 3, 4, 5, 6 },
                new[] { 1, 2, 3, 4, 5 },
                null,
                new[] { 1, 2, 3 },
                new[] { 1, 2 },
                new[] { 1 }
            };

            var actual = new[]
            {
                null,
                new[] { 1 },
                new[] { 1, 2 },
                new[] { 1, 2, 3 },
                new[] { 1, 2, 3, 4, 5},
                new[] { 1, 2, 3, 4, 5, 6}
            };

            JaggedSorter.Sort(unsorted, new MaxElementOrder());
            Assert.AreEqual(unsorted, actual);
        }

        private class MaxElementOrder : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                if (a == null)
                {
                    return 0;
                }

                if (b == null)
                {
                    return 1;
                }

                return (GetMaxElement(a) - GetMaxElement(b));
            }

            private int GetMaxElement(int[] array)
            {
                var max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (max < array[i])
                    {
                        max = array[i];
                    }
                }

                return max;
            }
        }
    }

    [TestFixture]
    public class JaggedArrayMaxElementSortReverse
    {
        [Test]
        public void Sort_UnsortedJaggedArrayWithMaxElementReversedComparator_SortedInRightWayArray()
        {
            var unsorted = new[]
            {
                new[] { 1 },
                new[] { 1, 2 },
                null,
                new[] { 1, 2, 3 },
                new[] { 1, 2, 3, 4, 5},
                new[] { 1, 2, 3, 4, 5, 6}

            };

            var actual = new[]
            {
                null,
                new[] { 1, 2, 3, 4, 5, 6 },
                new[] { 1, 2, 3, 4, 5 }, 
                new[] { 1, 2, 3 },
                new[] { 1, 2 },
                new[] { 1 }
            };

            JaggedSorter.Sort(unsorted, new MaxElementReverseOrder());
            Assert.AreEqual(unsorted, actual);
        }

        private class MaxElementReverseOrder : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                if (a == null)
                {
                    return 0;
                }

                if (b == null)
                {
                    return 1;
                }

                return (GetMaxElement(b) - GetMaxElement(a));
            }

            private int GetMaxElement(int[] array)
            {
                var max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (max < array[i])
                    {
                        max = array[i];
                    }
                }

                return max;
            }
        }
    }

    [TestFixture]
    public class JaggedArrayMinElementSort
    {
        [Test]
        public void Sort_UnsortedJaggedArrayWithMinElementComparator_SortedInRightWayArray()
        {

            var unsorted = new[]
            {
                new[] { -1 },
                new[] { 1, -2 },
                new[] { 1, 2, -3 },
                null,
                new[] { 1, 2, 3, 4, -5},
                new[] { 1, 2, 3, 4, 5, -6}
            };
            var actual = new[]
            {
                null,
                new[] { 1, 2, 3, 4, 5, -6 },
                new[] { 1, 2, 3, 4, -5 },
                new[] { 1, 2, -3 },
                new[] { 1, -2 },
                new[] { -1 }
            };



            JaggedSorter.Sort(unsorted, new MinElementOrder());
            Assert.AreEqual(unsorted, actual);
        }

        private class MinElementOrder : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                if (a == null)
                {
                    return 0;
                }

                if (b == null)
                {
                    return 1;
                }

                return (GetMinElement(a) - GetMinElement(b));
            }

            private int GetMinElement(int[] array)
            {
                var max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (max > array[i])
                    {
                        max = array[i];
                    }
                }

                return max;
            }
        }
    }

    [TestFixture]
    public class JaggedArrayMinElementSortReverse
    {
        [Test]
        public void Sort_UnsortedJaggedArrayWithMinElementReverseComparator_SortedInRightWayArray()
        {

            var unsorted = new[]
            {
                
                new[] { 1, 2, 3, 4, 5, -6 },
                new[] { 1, 2, 3, 4, -5 },
                null,
                new[] { 1, 2, -3 },
                new[] { 1, -2 },
                new[] { -1 }
            };
            var actual = new[]
            {
                null,
                new[] { -1 },
                new[] { 1, -2 },
                new[] { 1, 2, -3 },
                new[] { 1, 2, 3, 4, -5},
                new[] { 1, 2, 3, 4, 5, -6}

            };



            JaggedSorter.Sort(unsorted, new MinElementReverseOrder());
            Assert.AreEqual(unsorted, actual);
        }

        private class MinElementReverseOrder : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                if (a == null)
                {
                    return 0;
                }

                if (b == null)
                {
                    return 1;
                }

                return (GetMinElement(b) - GetMinElement(a));
            }

            private int GetMinElement(int[] array)
            {
                var max = array[0];
                for (int i = 1; i < array.Length; i++)
                {
                    if (max > array[i])
                    {
                        max = array[i];
                    }
                }

                return max;
            }
        }
    }

    [TestFixture]
    public class JaggedArrayArraySumSort
    {
        [Test]
        public void Sort_UnsortedJaggedArrayWithArraySumComparator_SortedInRightWayArray()
        {
            var unsorted = new[]
            {
                new[] { 1, 2, 3, 4, 5, 6 },
                new[] { 1, 2, 3, 4, 5 },
                null,
                new[] { 1, 2, 3 },
                new[] { 1, 2 },
                new[] { 1 }
            };

            var actual = new[]
            {
                null,
                new[] { 1 },
                new[] { 1, 2 },
                new[] { 1, 2, 3 },
                new[] { 1, 2, 3, 4, 5},
                new[] { 1, 2, 3, 4, 5, 6}
            };

            JaggedSorter.Sort(unsorted, new ArraySumOrder());
            Assert.AreEqual(unsorted, actual);
        }

        private class ArraySumOrder : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                if (a == null)
                {
                    return 0;
                }

                if (b == null)
                {
                    return 1;
                }

                return (GetSum(a) - GetSum(b));
            }

            private int GetSum(int[] array)
            {
                var sum = 0;

                foreach (var num in array)
                {
                    sum += num;
                }

                return sum;
            }
        }
    }

    [TestFixture]
    public class JaggedArrayArraySumSortReverse
    {
        [Test]
        public void Sort_UnsortedJaggedArrayWithArraySumReversedComparator_SortedInRightWayArray()
        {
            var unsorted = new[]
            {   
                new[] { 1 },
                new[] { 1, 2 },
                new[] { 1, 2, 3 },
                null,
                new[] { 1, 2, 3, 4, 5},
                new[] { 1, 2, 3, 4, 5, 6}
            };

            var actual = new[]
            {
                null,
                new[] { 1, 2, 3, 4, 5, 6 },
                new[] { 1, 2, 3, 4, 5 },
                new[] { 1, 2, 3 },
                new[] { 1, 2 },
                new[] { 1 }
            };

            JaggedSorter.Sort(unsorted, new ArraySumReverseOrder());
            Assert.AreEqual(unsorted, actual);
        }

        private class ArraySumReverseOrder : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                if (a == null)
                {
                    return 0;
                }

                if (b == null)
                {
                    return 1;
                }

                return (GetSum(b) - GetSum(a));
            }

            private int GetSum(int[] array)
            {
                var sum = 0;

                foreach (var num in array)
                {
                    sum += num;
                }

                return sum;
            }
        }
    }

    [TestFixture]
    public class JaggedArrayExceptionTests
    {
        [Test]
        public void Sort_JaggedArrayIsNullReferenced_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedSorter.Sort(null, new FakeComparer()));
        }

        [Test]
        public void Sort_ComparatorIsNullReferenced_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedSorter.Sort(new []
            {
                new[] { 1, 2, 3 },
                new[] { 1, 2 },
                new[] { 1 }
            }, 
            null));
        }

        [Test]
        public void Sort_InputsAreNullReferenced_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => JaggedSorter.Sort(null, null));
        }

        private class FakeComparer : IComparer<int[]>
        {
            public int Compare(int[] a, int[] b)
            {
                return 0;
            }
        }
    }
}
