using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeSieve
{
    public static class PrimeSieve
    {
        private static void Main(string[] args)
        {
            foreach (var prime in SieveEnum(AskInput.AskPosInt())) Console.Write($"{prime} ");
            Console.WriteLine();
        }

        public static IEnumerable<int> SieveEnum(int max)
        {
            if (max < 2)
            {
                Console.WriteLine("Max number too small.");
                yield break;
            }

            var m = Math.Sqrt(max);
            // See https://en.wikipedia.org/wiki/Prime-counting_function for capacity prediction
            var container = new List<int>((int) (m / Math.Log(m, Math.E) * 1.1)) {2};
            yield return 2;
            foreach (var num in Enumerable.Range(3, max - 2))
            {
                if (container.TakeWhile(prime => prime * prime <= num).Any(prime => num % prime == 0)) continue;
                container.Add(num);
                yield return num;
            }
        }
    }
}