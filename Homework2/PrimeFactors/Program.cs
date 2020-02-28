using System;

namespace PrimeFactors
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var number = AskInput.AskPosInt();
            switch (number)
            {
                case 1:
                    Console.WriteLine("Prime Factors: None");
                    return;
                case 2:
                    Console.WriteLine("Prime Factors: 2");
                    return;
            }

            Console.Write("Prime Factors: ");
            var max = number;
            foreach (var prime in PrimeSieve.PrimeSieve.SieveEnum(number))
            {
                if ((long) prime * prime > max)
                {
                    Console.Write(max);
                    break;
                }

                if (max % prime != 0) continue;
                Console.Write($"{prime} ");
                do
                {
                    max /= prime;
                } while (max % prime == 0);

                if (max == 1) break;
            }

            Console.WriteLine();
        }
    }
}