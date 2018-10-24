using System;
using System.Runtime.InteropServices;

namespace ConverterLibrary
{
    /// <summary>
    /// Struct IEEEFormat that translate <c>System.Double</c> into it`s binary view.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 8, CharSet = CharSet.Auto)]
    internal struct IEEEFormat
    {
        [FieldOffset(0)]
        private double double64Bits;
        [FieldOffset(0)]
        private readonly long long64Bits;

        public double Double64Bit
        {
            get
            {
                return this.double64Bits;
            }

            set
            {
                this.double64Bits = value;
            }
        }

        public long Long64Bits
        {
            get
            {
                return this.long64Bits;
            }
        }
    }

    /// <summary>
    ///  Class for work with IEEEFormat struct, to get binary view of double numbers.
    /// </summary>
    public static class IEEEFormater
    {

        /// <summary>
        /// Math test method, ignore it.
        /// </summary>
        /// <returns> Return the result of multiply operation. </returns>
        public static double VSMulti()
        {
            return 13.6941646913505d * 20.8015918046243d;
        }

        /// <summary>
        /// Method that returns binary view of a<c>double</c> array.
        /// </summary>
        /// <param name="doubles"> Array of doubles. </param>
        /// <returns> Return the <c>string</c> array of binary versions of doubles. </returns>
        public static string[] Format(this double[] doubles)
        {
            if (doubles == null)
            {
                throw new ArgumentNullException(nameof(doubles));
            }

            if (doubles.Length == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(doubles));
            }

            var iFormat = default(IEEEFormat);
            var result = new string[doubles.Length];
            for (var i = 0; i < doubles.Length; i++)
            {
                iFormat.Double64Bit = doubles[i];
                result[i] = DoubleToBinary(iFormat);
            }

            return result;
        }

        /// <summary>
        /// Returns a binary view of a double value.
        /// </summary>
        /// <param name="iFormat"> Struct that contains the <c>double</c> that we want to translate into a binary version. </param>
        /// <returns> Returns the <c>string</c> of bits, that is a binary version. </returns>
        private static string DoubleToBinary(IEEEFormat iFormat)
        {
            var str = string.Empty;
            for (var i = 63; i >= 0; i--)
            {
                str += GetBit(iFormat.Long64Bits, i).ToString();
            }

            str = str.Replace("-", ""); // -1 :c
            return str;
        }

        /// <summary>
        /// Gets bit of some <c>long</c> value.
        /// </summary>
        /// <param name="value"> The <c>long</c> value from witch we need to get a bit.</param>
        /// <param name="pos"> The position of bit we need to get. </param>
        /// <returns> Returns a bit of some long value. </returns>
        /// <exception cref="ArgumentOutOfRangeException"> Thrown if <c>pos</c> is
        /// not in <c>long</c> type range. </exception>
        private static long GetBit(long value, int pos)
        {
            if (pos < 0 || pos > Math.Pow(sizeof(long), 2))
            {
                throw new ArgumentOutOfRangeException(nameof(pos));
            }

            return (value & (1L << pos)) >> pos;
        }
    }
}
