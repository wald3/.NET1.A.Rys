using System;
using System.Collections.Generic;
using System.Text;

namespace ConverterLibrary
{
    /// <summary>
    /// Class transform from <c>double</c> into <c>string</c>.
    /// </summary>
    public static class TransformToWords
    {
        /// <summary>
        /// Transform method takes an array of <c>double</c> and convert them into <c>string</c>.
        /// </summary>
        /// <param name="arrayDoubles"> Array of doubles that need to be transform. </param>
        /// <returns> Returns an array of strings. </returns>
        public static string[] Transform(double[] arrayDoubles)
        {
            if (arrayDoubles == null)
            {
                throw new ArgumentNullException(nameof(arrayDoubles));
            }

            if (arrayDoubles.Length == 0)
            {
                throw new ArgumentException(nameof(arrayDoubles));
            }

            var result = new string[arrayDoubles.Length];
            for (var i = 0; i < arrayDoubles.Length; i++)
            {
                var sb = new StringBuilder(arrayDoubles[i].ToString());
                for (var j = 0; j < sb.Length; j++)
                {
                    result[i] += translater[sb[j]] + " ";
                }

                result[i] = result[i].Remove(result[i].Length - 1, 1);
            }
            return result;
        }

        private static readonly Dictionary<char, string> translater = new Dictionary<char, string>()
        {
            {'0', "zero"},
            {'1', "one"},
            {'2', "two"},
            {'3', "three"},
            {'4', "four"},
            {'5', "five"},
            {'6', "six"},
            {'7', "seven"},
            {'8', "eight"},
            {'9', "nine"},
            {'-', "minus"},
            {',', "point"},
        };
    }
}
