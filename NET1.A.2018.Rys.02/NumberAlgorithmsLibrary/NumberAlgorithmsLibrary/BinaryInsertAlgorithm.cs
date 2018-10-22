using System;

namespace NumberAlgorithmsLibrary
{
    /// <summary>
    /// BinaryInsert class is for inserting some bits from 1 num, to another.
    /// </summary>
    public static class BinaryInsertAlgorithm
    {
        /// <summary>
        /// The shell for a main insert method.
        /// </summary>
        /// <param name="numberIn"> The base 32bit int number into which the bits from 2nd number will be inserted. </param>
        /// <param name="numberInsert"> The 32bit int number from which bits will be inserted. </param>
        /// <param name="start"> The start position of the inserted bits. </param>
        /// <param name="end"> The end position of the inserted bits.</param>
        /// <returns> Method returns an integer that`s contains bits from both of 2 numbers. </returns>
        /// <exception cref="System.ArgumentOutOfRangeException"> Thrown when the inputs as
        /// <c>start</c> / <c>end</c> are out of array range, or when <c>end</c> are less than <c>start</c>. </exception>
        public static int BinaryInsert(int numberIn, int numberInsert, int start, int end)
        {
            if (start < 0 || start > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            if (end < 0 || end > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(end));
            }

            if (start > end)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }

            return Insert(numberIn, numberInsert, start, end);
        }

        /// <summary>
        /// Main method of insertion. Insert method takes 2 32bits numbers with a start and end positions,
        /// and returns 10th base number that contains some bits from 1st and 2nd numbers.
        /// </summary>
        /// <returns>Method returns an integer that`s contains bits from both of 2 numbers. </returns>
        private static int Insert(int numberIn, int numberInsert, int start, int end)
        {
            for (var i = start; i < end + 1; i++)
            {
                var bitA = GetBit(numberIn, i);
                var bitB = GetBit(numberInsert, i - start);
                if (bitB != bitA)
                {
                    numberIn ^= 1 << i;
                }
            }

            return numberIn;
        }

        /// <summary>
        /// Gets the bit of <c>value</c> integer on <c>pos</c> position.
        /// </summary>
        /// <param name="value"> The number you want take 1 bit. </param>
        /// <param name="pos"> The position of that bit. </param>
        /// <returns> Bit from <c>value</c> on <c>pos</c> position. </returns>
        private static int GetBit(int value, int pos)
        {
            return (value & (1 << pos)) >> pos;
        }
    }
}