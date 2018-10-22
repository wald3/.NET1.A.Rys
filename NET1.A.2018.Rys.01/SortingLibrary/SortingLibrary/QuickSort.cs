// <copyright file="QuickSort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;
using static SortingLibrary.Extensions;

namespace SortingLibrary
{
    /// <summary>
    /// Class with a QuickSort implementation.
    /// </summary>
    /// <remarks>
    /// Class that takes an array of int`s(with or without an indexes
    /// of start and end sort position) and sort it with QuickSort.
    /// </remarks>
    public static class QuickSort
    {
        /// <summary>
        /// Sort method that takes an <c>unsorted</c> as
        /// the only 1 input, too sort it.
        /// </summary>
        /// <param name="unsorted"> Array of int`s that needs to be sorted. </param>
        /// <exception cref="System.ArgumentNullException"> Thrown when the input array has null reference. </exception>
        public static void Sort(int[] unsorted)
        {
            if (unsorted.IsNull())
            {
                throw new ArgumentNullException(nameof(unsorted));
            }

            if (unsorted.Length <= 1)
            {
                return;
            }

            QuickSorting(unsorted, 0, unsorted.Length - 1);
        }

        /// <summary>
        /// Sort method that takes an <c>unsorted</c> with
        /// the <c>startIndex</c> and <c>endIndex</c> sub-array positions, to sort it.
        /// </summary>
        /// <param name="unsorted"> Array of int`s that needs to be sorted. </param>
        /// <param name="startIndex"> Starting position from <c>unsorted</c> sub-array. </param>
        /// <param name="endIndex"> Ending position from <c>unsorted</c> sub-array. </param>
        /// <exception cref="System.ArgumentNullException"> Thrown when the input array(<c>unsorted</c>) has null reference. </exception>
        /// <exception cref="System.ArgumentOutOfRangeException"> Thrown when <c>startIndex</c> or <c>endIndex</c> are not in array range. </exception>
        /// <exception cref="System.ArgumentException"> Thrown when <c>startIndex</c> is grater that <c>endIndex</c>. </exception>
        public static void Sort(int[] unsorted, int startIndex, int endIndex)
        {
            if (unsorted.IsNull())
            {
                throw new ArgumentNullException(nameof(unsorted));
            }

            if (unsorted.Length <= 1)
            {
                return;
            }

            if (startIndex < 0 || startIndex > unsorted.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            }

            if (endIndex < 0 || endIndex > unsorted.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(endIndex));
            }

            if (startIndex >= endIndex)
            {
                if (startIndex == endIndex)
                {
                    return;
                }

                throw new ArgumentException(nameof(startIndex));
            }

            QuickSorting(unsorted, startIndex, endIndex);
        }

        /// <summary>
        /// Private sorting method, that would be call in Sort`s methods.
        /// </summary>
        /// <param name="mainArray"> Array of int`s that needs to be sorted. </param>
        /// <param name="left"> Start position of Sorting process. </param>
        /// <param name="right"> End position of Sorting process. </param>
        private static void QuickSorting(int[] mainArray, int left, int right)
        {
            var pivot = mainArray[(left + right) / 2];
            int i = left, j = right;

            while (true)
            {
                while (mainArray[i] < pivot)
                {
                    i++;
                }

                while (pivot < mainArray[j])
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(ref i, ref j);
                    i++;
                    j--;
                }

                if (i > j)
                {
                    break;
                }
            }

            if (left < j)
            {
                QuickSorting(mainArray, left, j);
            }

            if (i < right)
            {
                QuickSorting(mainArray, i, right);
            }
        }
    }
}
