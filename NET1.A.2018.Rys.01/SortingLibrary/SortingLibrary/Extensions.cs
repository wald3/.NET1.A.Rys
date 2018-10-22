// <copyright file="Extensions.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using System;

namespace SortingLibrary
{
    /// <summary>
    /// Extensions class with some helpful methods.
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        /// Method that swap 2 elements in some array.
        /// </summary>
        /// <param name="array"> An <see cref="int[]"/> array wherein 2 elements
        /// needs to be changed. </param>
        /// <param name="i"> Position of first swapped element in <c>array</c>. </param>
        /// <param name="j"> Position of second swapped element in <c>array</c>. </param>
        public static void Swap(ref int i, ref int j)
        {
            var temp = i;
            i = j;
            j = temp;
        }

        /// <summary>
        /// Custom Null-detect method.
        /// </summary>
        /// <param name="array"> <see cref="int[]"/> array that needs to be checked on Null reference. </param>
        /// <returns> Return <c>true</c> if array object has null reference. </returns>
        public static bool IsNull(this int[] array)
        {
            return array == null;
        }

        /// <summary>
        /// <c>int[]</c> extension that copy a part of <c>this.</c> array into.
        /// anther and returns it.
        /// </summary>
        /// <param name="mainArray"> The array from which the part is copied. </param>
        /// <param name="start">  Starts copy position of sub-array range. </param>
        /// <param name="end"> Ends copy position of sub-array range. </param>
        /// <returns> Return part of <c>mainArray</c> as new <c>int[]</c> array. </returns>
        /// <exception cref="System.ArgumentNullException"> Thrown if <c>mainArray</c> has null reference. </exception>
        /// <exception cref="System.ArgumentOutOfRangeException"> Thrown when <c>star</c> or <c>end</c> are not in array range. </exception>
        /// <exception cref="System.ArgumentException"> Thrown when <c>start</c> is grater that <c>end</c>. </exception>
        public static int[] Copy(this int[] mainArray, int start, int end)
        {
            if (mainArray.IsNull())
            {
                throw new ArgumentNullException(nameof(mainArray));
            }

            if (start < 0 || start > mainArray.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            if (end < 0 || end > mainArray.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }

            if (start >= end)
            {
                if (start == end)
                {
                    return new int[] { mainArray[start] };
                }

                throw new ArgumentException(nameof(start));
            }

            int[] result = new int[end - start + 1];

            for (int i = start; i < end + 1; i++)
            {
                result[i - start] = mainArray[i];
            }

            return result;
        }

        /// <summary>
        /// <c>int[]</c> extension that paste a part into <c>this.</c> array.
        /// </summary>
        /// <param name="mainArray"> The array into which the part is pasted. </param>
        /// <param name="subArray"> The array from which the part is copied. </param>
        /// <param name="start"> Starts copy-paste position of sub-array range. </param>
        /// <param name="end"> Ends copy-paste position of sub-array range.</param>
        /// <exception cref="System.ArgumentNullException"> Thrown if <c>mainArray</c> or <c>subArray</c> has null reference. </exception>
        /// <exception cref="System.ArgumentOutOfRangeException"> Thrown when <c>star</c> or <c>end</c> are not in array range. </exception>
        /// <exception cref="System.ArgumentException"> Thrown when <c>start</c> is grater that <c>end</c>. </exception>
        public static void Paste(this int[] mainArray, int[] subArray, int start, int end)
        {
            if (mainArray.IsNull())
            {
                throw new ArgumentNullException(nameof(mainArray));
            }

            if (subArray.IsNull())
            {
                throw new ArgumentNullException(nameof(subArray));
            }

            if (start < 0 || start > mainArray.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            if (end < 0 || end > mainArray.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }

            if (start < 0 || start > subArray.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            if (end < 0 || end > subArray.Length - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }

            if (start >= end)
            {
                if (start == end)
                {
                    return;
                }

                throw new ArgumentException(nameof(start));
            }

            subArray.CopyTo(mainArray, start);
        }
    }
}
