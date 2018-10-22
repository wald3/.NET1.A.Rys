using System;

namespace HelperMethods
{
    public class Helpers
    {
        public static int[] ArrayGen(int loBound, int upBound, bool isEven)
        {
            var rnd = new Random();

            var arraySize = rnd.Next(loBound, upBound);
            int[] unsortedArray;

            if (isEven)
            {
                arraySize *= 2;
                unsortedArray = new int[arraySize];
            }
            else
            {
                arraySize = arraySize * 2 + 1;
                unsortedArray = new int[arraySize];
            }

            for (var i = 0; i < arraySize - 1; i++)
            {
                unsortedArray[i] = rnd.Next(-5000, 5000);
            }


            return unsortedArray;
        }
    }
}
