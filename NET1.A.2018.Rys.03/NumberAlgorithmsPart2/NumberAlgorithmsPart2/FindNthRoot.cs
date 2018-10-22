using System;

namespace NumberAlgorithmsPart2
{
    /// <summary>
    /// Implementation of Nth root finding method by Newton's method.
    /// </summary>
    public static class FindNthRoot
    {
        /// <summary>
        /// Method that calculates the root incrementally. 
        /// </summary>
        /// <param name="number"> The powered root that we know. </param>
        /// <param name="power"> That is power of the root that we need to calculate <c>number</c>. </param>
        /// <param name="accuracy"> The accuracy of calculating. </param>
        /// <returns></returns>
        public static double FindRoot(double number, double power, double accuracy)
        {
            if (number < 0 && power % 2 == 0)
            {
                throw new ArgumentException(nameof(number));
            }

            if (power == accuracy)
            {
                throw new ArgumentException(nameof(power));
            }

            if (accuracy < 0)
            {
                throw new ArgumentException(nameof(accuracy));
            }

            var currentValue = number / power;
            var zoom = (1 / power) * ((power - 1) * currentValue + number / Math.Pow(currentValue, (int) power - 1));

            while (Math.Abs(zoom - currentValue) > accuracy)
            {
                currentValue = zoom;
                zoom = (1 / power) * ((power - 1) * currentValue + number / Math.Pow(currentValue, (int) power - 1));
            }

            return zoom;
        }
    }
}
