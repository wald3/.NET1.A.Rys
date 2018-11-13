using System;
using System.Diagnostics;

namespace ConverterLibrary
{
    public static class GCDAlgorithm
    {
        #region EuclidGCDAlgorithm

        public static int? FindGCDEuclid(int firstInput, int secondInput)
        {
            var result = InputValidation(Math.Abs(firstInput), Math.Abs(secondInput));
            return result ?? GSDEuclid(Math.Abs(firstInput), Math.Abs(secondInput));
        }

        public static int? FindGCDEuclid(params int[] inputInts)
        {
            if (inputInts.Length == 1) throw new ArgumentException(nameof(inputInts), " Length is less than 2!");

            var result = Math.Abs(inputInts[0]);

            for (var i = 1; i < inputInts.Length; i++)
            {
                var isValid = InputValidation(result, Math.Abs(inputInts[i]));
                result = isValid == null ? GSDEuclid(result, Math.Abs(inputInts[i])) : GSDEuclid(result, Math.Abs(inputInts[i]));
            }

            return result;
        }

        public static int? FindGCDEuclid(out Stopwatch sw, int firstInput, int secondInput)
        {
            sw = new Stopwatch();
            sw.Start();
            var result = FindGCDEuclid(firstInput, secondInput);
            sw.Stop();
            return result;
        }

        public static int? FindGCDEuclid(out Stopwatch sw, params int[] inputInts)
        {
            sw = new Stopwatch();
            sw.Start();
            var result = FindGCDEuclid(inputInts);
            sw.Stop();
            return result;
        }
        #endregion

        #region SteinBinaryGCDAlgorithm

        public static int FindGCDStein(int firstInput, int secondInput)
        {
            var result = InputValidation(Math.Abs(firstInput), Math.Abs(secondInput));
            return result ?? GSDEuclid(Math.Abs(firstInput), Math.Abs(secondInput));
        }

        public static int FindGCDStein(params int[] inputInts)
        {
            if (inputInts.Length == 1) throw new ArgumentException(nameof(inputInts), " Length is less than 2!");

            var result = Math.Abs(inputInts[0]);

            for (var i = 1; i < inputInts.Length; i++)
            {
                var isValid = InputValidation(result, Math.Abs(inputInts[i]));
                result = isValid == null ? GCDStein(result, Math.Abs(inputInts[i])) : GCDStein(result, Math.Abs(inputInts[i]));
            }

            return result;
        }

        public static int FindGCDStein(out Stopwatch sw, int firstInput, int secondInput)
        {
            sw = new Stopwatch();
            sw.Start();
            var result = GCDStein(firstInput, secondInput);
            sw.Stop();
            return result;
        }

        public static int FindGCDStein(out Stopwatch sw, params int[] inputInts)
        {
            sw = new Stopwatch();
            sw.Start();
            var result = FindGCDStein(inputInts);
            sw.Stop();
            return result;
        }

        #endregion

        #region UniversalLogicInterface

        public static int? FindGCD(IGCDFinder gcdLogic, params int[] inputValues)
        {
            if (inputValues.Length == 1) throw new ArgumentException(nameof(inputValues), " Length is less than 2!");

            var result = Math.Abs(inputValues[0]);

            for (var i = 1; i < inputValues.Length; i++)
            {
                var isValid = InputValidation(result, Math.Abs(inputValues[i]));
                result = isValid == null ? gcdLogic.FindGcd(result, Math.Abs(inputValues[i])) : gcdLogic.FindGcd(result, Math.Abs(inputValues[i]));
            }

            return result;
        }

        public static int? FindGCD(Func<int, int, int> gcdLogic, params int[] inputValues)
        {
            if (inputValues.Length == 1) throw new ArgumentException(nameof(inputValues), " Length is less than 2!");

            var result = Math.Abs(inputValues[0]);

            for (var i = 1; i < inputValues.Length; i++)
            {
                var isValid = InputValidation(result, Math.Abs(inputValues[i]));
                result = isValid == null ? gcdLogic(result, Math.Abs(inputValues[i])) : gcdLogic(result, Math.Abs(inputValues[i]));
            }

            return result;
        }

        #endregion

        private static int? InputValidation(int? firstInput, int? secondInput)
        {
            if (firstInput == null || secondInput == null) throw new ArgumentNullException("null cant be an input value!");
            if (firstInput == 0) return secondInput;
            if (secondInput == 0) return firstInput;
            if (firstInput == secondInput) return firstInput;
            return null;
        }

        private static int GSDEuclid(int first, int second)
        {
            while (first != 0)
            {
                first = second % (second = first);
            }

            return second;
        }

        private static int GCDStein(int first, int second)
        {
            if (first == 0) return second;
            if (second == 0) return first;
            if (first == second) return first;

            var value1IsEven = (first & 1) == 0;
            var value2IsEven = (second & 1) == 0;

            if (value1IsEven && value2IsEven)
            {
                return GCDStein(first >> 1, second >> 1) << 1;
            }

            if (value1IsEven)
            {
                return GCDStein(first >> 1, second);
            }

            if (value2IsEven)
            {
                return GCDStein(first, second >> 1);
            }

            if (first > second)
            {
                return GCDStein((first - second) >> 1, second);
            }
            else
            {
                return GCDStein(first, (second - first) >> 1);
            }
        }
    }
}
