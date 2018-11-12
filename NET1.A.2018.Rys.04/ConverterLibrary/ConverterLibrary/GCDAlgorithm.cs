using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConverterLibrary
{
    public static class GCDAlgorithm
    {
        public static int FindGCDEuclid(int firstInput, int secondInput)
        {
            int result = InputValidation(Math.Abs(firstInput), Math.Abs(secondInput));
            if (result == -1)
            {
                return GSDEuclid(Math.Abs(firstInput), Math.Abs(secondInput));
            }

            return result;
        }

        public static int FindGCDEuclid(int firstInput, int secondInput, ref Stopwatch sw)
        {
            sw.Start();
            var result = FindGCDEuclid(firstInput, secondInput);
            sw.Stop();
            return result;
        }

        public static int FindGCDShtein(int firstInput, int secondInput)
        {
            int result = InputValidation(Math.Abs(firstInput), Math.Abs(secondInput));
            if (result == -1)
            {
                return GSDEuclid(Math.Abs(firstInput), Math.Abs(secondInput));
            }

            return result;
        }

        public static int FindGCDShtein(int firstInput, int secondInput, ref Stopwatch sw)
        {
            sw.Start();
            var result = FindGCDShtein(firstInput, secondInput);
            sw.Stop();
            return result;
        }

        private static int InputValidation(int firstInput, int secondInput)
        {
            if (firstInput == 0) return secondInput;
            if (secondInput == 0) return firstInput;
            if (firstInput == secondInput) return firstInput;
            return -1;
        }

        private static int GSDEuclid(int first, int second)
        {
            while (first != 0)
            {
                first = second % (second = first);
            }

            return second;
        }

        private static int FindGCDStein(int first, int second)
        {
            if (first == 0) return second;
            if (second == 0) return first;
            if (first == second) return first;

            var value1IsEven = (first & 1) == 0;
            var value2IsEven = (second & 1) == 0;

            if (value1IsEven && value2IsEven)
            {
                return FindGCDStein(first >> 1, second >> 1) << 1;
            }

            if (value1IsEven)
            {
                return FindGCDStein(first >> 1, second);
            }

            if (value2IsEven)
            {
                return FindGCDStein(first, second >> 1);
            }

            if (first > second)
            {
                return FindGCDStein((first - second) >> 1, second);
            }
            else
            {
                return FindGCDStein(first, (second - first) >> 1);
            }
        }
    }
}
