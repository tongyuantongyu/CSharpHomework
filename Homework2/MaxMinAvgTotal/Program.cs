using System;
using System.Collections.Generic;

namespace MaxMinAvgTotal
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Array size? ");
            var list = new List<double>(AskInput.AskPosInt());
            for (var i = 0; i < list.Capacity; i++)
            {
                Console.Write($"Number #{i + 1}? ");
                list.Add(AskInput.AskDouble());
            }

            double max = double.MinValue, min = double.MaxValue, total = 0;
            foreach (var d in list)
            {
                max = max < d ? d : max;
                min = min > d ? d : min;
                total += d;
            }

            Console.WriteLine($"Max: {max}, Min: {min}, Total: {total}, Average: {total / list.Count}.");
        }
    }
}