using System;
using CalculateTools;

namespace ConsoleCalc
{
    internal static class ConsoleCalc
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                var num1 = AskNumber();
                var num2 = AskNumber();
                Console.Write("Input an operator: ");
                Calculator.Calc(num1, num2, Console.ReadLine(), out _, out var expression);
                Console.WriteLine(expression);
            }
        }

        private static double AskNumber()
        {
            Console.Write("Input a number: ");
            var input = Console.ReadLine();
            double validNum;
            while (!double.TryParse(input, out validNum))
            {
                Console.Write("Bad number. Please retry: ");
                input = Console.ReadLine();
            }

            return validNum;
        }
    }
}