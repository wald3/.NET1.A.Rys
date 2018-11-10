using System;
using System.Collections.Generic;
using System.Text;

namespace NumberAlgorithmsPart2
{
    /// <summary>
    /// Implementing the Finding Biggest Nest Number algorithm.
    /// </summary>
    public static class FindNextBiggerNumber
    {
        /// <summary>
        /// Public method that checks inputs and calls algorithm
        /// if inputs are valid.
        /// </summary>
        /// <param name="number"> Input number in range of: [0, Int32.MaxValue] </param>
        /// <returns> Returns result of the main algorithm method. </returns>
        public static int FindNextBigNumber(int number)
        {
            if (number < 0) { throw new ArgumentException(nameof(number)); }
            if (number % 10 == 0) return -1;
            return Find(number);
        }

        /// <summary>
        /// The main method that find next biggest number that can be compiled from the
        /// "number" digits.
        /// </summary>
        /// <param name="number">Input number in range of: [0, Int32.MaxValue] </param>
        /// <returns>Returns the biggest next number. </returns>
        private static int Find(int number)
        {
            var numbers = ConvertToArray(number);
            for (var i = numbers.Length - 1; i >= 1; i--)
            {
                if (numbers[i] <= numbers[i - 1]) continue;

                Swap(ref numbers[i], ref numbers[i - 1]);
                if (numbers.Length - i <= 1) return ConvertToNum(numbers);
            
                var unsortedNUms = new int[numbers.Length - i];
                Array.Copy(numbers, i, unsortedNUms, 0, numbers.Length - i);
                Array.Sort(unsortedNUms);
                Array.Copy(unsortedNUms, 0, numbers, i, unsortedNUms.Length);

                return ConvertToNum(numbers);
            }
            return -1;
        }

        /// <summary>
        /// Swap method fo some ref params.
        /// </summary>
        /// <param name="a"> First parameter to swap. </param>
        /// <param name="b"> Second parameter to swap. </param>
        private static void Swap(ref int a, ref int b)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        /// <summary>
        /// Method that take a number as input and returns an array of
        /// digits of that number.
        /// </summary>
        /// <param name="number"> Number that needs to be divided on digits. </param>
        /// <returns> Returns the arrays of digits. </returns>
        private static int[] ConvertToArray(int number)
        {
            var nums = new int[number.ToString().Length];
            for (var i = 0; i < nums.Length; i++)
            {
                nums[nums.Length - 1 - i] = number % 10;
                number /= 10;
            }
            return nums;
        }

        /// <summary>
        /// Method that take an array of digits as input and returns the int value.
        /// </summary>
        /// <param name="nums"> The array that needs to be translated into int value. </param>
        /// <returns> Returns the int value from the arrays of digits. </returns>
        private static int ConvertToNum(int[] nums)
        {
            StringBuilder num = new StringBuilder();
            foreach (var n in nums)
            {
                num.Append(n);
            }
            return int.Parse(num.ToString());
        }
    }
}
