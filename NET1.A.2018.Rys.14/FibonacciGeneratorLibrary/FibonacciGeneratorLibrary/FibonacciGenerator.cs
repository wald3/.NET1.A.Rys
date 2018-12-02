using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace FibonacciGeneratorLibrary
{
    public static class FibonacciGenerator
    {
        public static IEnumerable<BigInteger> GetFibonacciSequence(int count)
        {
            CheckInput(count);

            BigInteger previous = 0;
            BigInteger next = 1;

            for (var i = 0; i < count; i++)
            {
                yield return previous;
                GoNext(ref previous, ref next);
            }
        }

        private static void GoNext(ref BigInteger a, ref BigInteger b)
        {
            var temp = a;
            a = b;
            b += temp;
        }

        private static void CheckInput(int value)
        {
            if(value <= 0) throw new ArgumentException(nameof(value), 
                "Sequence length is must be grater than 0!");
        }
    }
}
