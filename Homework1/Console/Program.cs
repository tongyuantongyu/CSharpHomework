using System;

namespace Project1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var num1 = AskNumber();
                var num2 = AskNumber();
                Console.Write("Input an operator: ");
                switch (Console.Read())
                {
                    case 'a':
                        Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
                        break;
                    case 's':
                        Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
                        break;
                    case 'm':
                        Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
                        break;
                    case 'd':
                        Console.WriteLine(num2 != 0 ? $"{num1} / {num2} = {num1 / num2}" : "Can't divide by zero.");
                        break;
                    default:
                        Console.WriteLine("Not a valid operator.");
                        break;
                }

                Console.ReadLine();
            }
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