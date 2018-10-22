using System;

namespace SortingLibrary.Tests
{
    public class HelperMethods
    {
        public static int[] ArrayGen(int loBound, int upBound, bool isEven)
        {
            Random rnd = new Random();

            int arraySize = rnd.Next(loBound, upBound);
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

            for (int i = 0; i < arraySize - 1; i++)
            {
                unsortedArray[i] = rnd.Next(-500, 500);
            }


            return unsortedArray;
        }

        public static bool IsSorted(int[] array)
        {
            for (int i = 1; i < array.Length - 1; i++)
            {
                if (array[i - 1] > array[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
