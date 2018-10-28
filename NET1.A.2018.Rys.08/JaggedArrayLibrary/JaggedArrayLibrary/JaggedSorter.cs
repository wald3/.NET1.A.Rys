using System;
using System.Collections.Generic;

namespace JaggedArrayLibrary
{
    /// <summary>
    /// Custom jagged array sorter.
    /// </summary>
    public static class JaggedSorter
    {
        /// <summary>
        /// Method that sorts jagged array.
        /// </summary>
        /// <param name="unsorted"> The jagged array which is need to be sorted. </param>
        /// <param name="comparator"> The custom comparator, that brings the logic
        /// of the comparing into the sort. </param>
        public static void Sort(int[][] unsorted, IComparer<int[]> comparator)
        {
            if (unsorted == null)
            {
                throw new ArgumentNullException(nameof(unsorted));
            }

            if (comparator == null)
            {
                throw new ArgumentNullException(nameof(comparator));
            }

            var isUnsorted = true;

            while (isUnsorted)
            {
                isUnsorted = false;
                for (var i = 0; i < unsorted.Length - 1; i++)
                {
                    if (comparator.Compare(unsorted[i], unsorted[i + 1]) <= 0) continue;
                    Swap(ref unsorted[i], ref unsorted[i + 1]);
                    isUnsorted = true;
                }
            }
        }

        /// <summary>
        /// Change the places of 2 elements.
        /// </summary>
        /// <param name="a"> First element. </param>
        /// <param name="b"> Second element. </param>
        private static void Swap(ref int[] a, ref int[] b)
        {
            var temp = a;
            a = b;
            b = temp;
        }
    }
}
