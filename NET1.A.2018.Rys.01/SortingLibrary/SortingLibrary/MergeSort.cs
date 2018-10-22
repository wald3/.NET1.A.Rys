// <copyright file="MergeSort.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;

namespace SortingLibrary
{
    /// <summary>
    /// Class with a MergeSort implementation.
    /// </summary>
    /// <remarks>
    /// Class that takes an array of int`s(with or without an indexes
    /// of start and end sort position) and sort it with MergeSort.
    /// </remarks>
    public static class MergeSort
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

            MergeSorting(unsorted);
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

            var part = unsorted.Copy(startIndex, endIndex);
            MergeSorting(part);
            unsorted.Paste(part, startIndex, endIndex);
        }

        /// <summary>
        /// Private sorting method, that would be call in Merge sort`s methods.
        /// </summary>
        /// <param name="array"> Array of int`s that needs to be sorted. </param>
        private static void MergeSorting(int[] array)
        {
            if (array.Length < 2)
            {
                return;
            }

            var pivot = array.Length / 2;
            var arrayLeft = new int[pivot];
            var arrayRight = new int[array.Length - pivot];

            for (var i = 0; i < pivot; i++)
            {
                arrayLeft[i] = array[i];
            }

            for (var i = pivot; i < array.Length; i++)
            {
                arrayRight[i - pivot] = array[i];
            }

            MergeSorting(arrayLeft);
            MergeSorting(arrayRight);
            Merge(array, arrayLeft, arrayRight);
        }

        /// <summary>
        /// Merging the 2 arrays into 1 array.
        /// </summary>
        /// <param name="mainArray"> The result array of merging 2 sub arrays. </param>
        /// <param name="subArrayLeft"> Lest sub-array for merging. </param>
        /// <param name="subArrayRight"> Right sub-array for merging. </param>
        private static void Merge(int[] mainArray, int[] subArrayLeft, int[] subArrayRight)
        {
            int i = 0, j = 0, index = 0;

            while (i < subArrayLeft.Length && j < subArrayRight.Length)
            {
                if (subArrayLeft[i] <= subArrayRight[j])
                {
                    mainArray[index] = subArrayLeft[i];
                    i++;
                }
                else
                {
                    mainArray[index] = subArrayRight[j];
                    j++;
                }

                index++;
            }

            while (i < subArrayLeft.Length)
            {
                mainArray[index] = subArrayLeft[i];
                i++;
                index++;
            }

            while (j < subArrayRight.Length)
            {
                mainArray[index] = subArrayRight[j];
                j++;
                index++;
            }
        }
    }
}
