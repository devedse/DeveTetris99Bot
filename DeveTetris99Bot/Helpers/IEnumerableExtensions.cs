using System;
using System.Collections.Generic;
using System.Linq;

namespace DeveTetris99Bot.Helpers
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            return source.RandomizeAlgorithm(new Random(1337));
        }

        private static IEnumerable<T> RandomizeAlgorithm<T>(this IEnumerable<T> source, Random random)
        {
            var temp = source.ToList();

            for (int i = 0; i < temp.Count; i++)
            {
                int j = random.Next(i, temp.Count);
                yield return temp[j];

                temp[j] = temp[i];
            }
        }
    }
}
