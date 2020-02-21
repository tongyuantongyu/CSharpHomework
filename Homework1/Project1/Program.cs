using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            var num1 = AskNumber();
            var num2 = AskNumber();
            double result;
            Console.Write("Input an operator: ");
            switch (Console.Read())
            {
                case 'a':
                    result = num1 + num2;
                    Console.Write($"{num1} + {num2} = {result}");
                    break;
                case 's':
                    result = num1 - num2;
                    Console.Write($"{num1} - {num2} = {result}");
                    break;
                case 'm':
                    result = num1 * num2;
                    Console.Write($"{num1} * {num2} = {result}");
                    break;
                case 'd':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        Console.Write($"{num1} / {num2} = {result}");
                    }
                    else
                    {
                        Console.Write("Can't divide by zero.");
                    }

                    break;
                default:
                    Console.Write("Not a valid operator.");
                    break;
            }

            Console.ReadKey();
        }

        static double AskNumber()
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
