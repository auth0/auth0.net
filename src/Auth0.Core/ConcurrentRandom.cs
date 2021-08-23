using System;

namespace Auth0.Core
{
    internal sealed class ConcurrentRandom
    {
        private static readonly Random SRandom = new Random();

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="minValue">The inclusive lower bound of the random number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random number returned. <paramref name="maxValue" /> must be greater than or equal to <paramref name="minValue" />.</param>
        /// <returns>A 32-bit signed integer greater than or equal to <paramref name="minValue" /> and less than <paramref name="maxValue" />; that is, the range of return values includes <paramref name="minValue" /> but not <paramref name="maxValue" />. If <paramref name="minValue" /> equals <paramref name="maxValue" />, <paramref name="minValue" /> is returned.</returns>
        public int Next(int minValue, int maxValue)
        {
            lock (SRandom)
            {
                return SRandom.Next(minValue, maxValue);
            }
        }
    }
}
