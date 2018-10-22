using System;

namespace NumberAlgorithmsLibrary
{
    /// <summary>
    /// Class implements the method of finding maximal element of the array using recursion.
    /// </summary>
    public static class MaxElementRecursion
    {
        /// <summary>
        /// <c>FindMaxElem</c> method is a shell for recursive method <c>FindMaxElemRecursion</c>.
        /// </summary>
        /// <param name="array"> Input array among the elements of which need to identify the
        /// maximum element. </param>
        /// <returns> Returns the maximum element of the <c>array</c>. </returns>
        /// <exception cref="System.ArgumentNullException"> Thrown when the input array has null
        /// reference. </exception>
        /// <exception cref="System.IndexOutOfRangeException"> Thrown when the input array has no
        /// elements inside. </exception>
        public static int FindMaxElem(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (array.Length == 0)
            {
                throw new IndexOutOfRangeException(nameof(array));
            }

            return FindMaxElemRecursion(array, 1, array[0]);
        }

        /// <summary>
        /// Method that finds maximum element with recursion.
        /// </summary>
        /// <param name="array"> Input array among the elements of which need
        /// to identify the maximum element.</param>
        /// <param name="index"> The position of item to be compared. </param>
        /// <param name="max"> The element witch is currently considered maximum. </param>
        /// <returns>Returns maximum element of array.</returns>
        private static int FindMaxElemRecursion(int[] array, int index, int max)
        {
            if (array.Length < index + 1)
            {
                return max;
            }

            if (max < array[index])
            {
                max = array[index];
            }

            return FindMaxElemRecursion(array, index + 1, max);
        }
    }
}
