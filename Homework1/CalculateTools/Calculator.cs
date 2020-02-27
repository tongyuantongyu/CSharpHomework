using System;

namespace CalculateTools
{
    internal static class Calculator
    {
        public static bool Calc(double num1, double num2, string ope, out double result, out string expression)
        {
            switch (ope)
            {
                case "+":
                    result = num1 + num2;
                    expression = $"{num1} + {num2} = {result}";
                    return true;
                case "-":
                    result = num1 - num2;
                    expression = $"{num1} - {num2} = {result}";
                    return true;
                case "*":
                    result = num1 * num2;
                    expression = $"{num1} * {num2} = {result}";
                    return true;
                case "/":
                    if (Math.Abs(num2) < double.Epsilon)
                    {
                        result = double.NaN;
                        expression = "Can't divide by zero.";
                        return false;
                    }
                    else
                    {
                        result = num1 / num2;
                        expression = $"{num1} / {num2} = {result}";
                        return true;
                    }
                default:
                    result = double.NaN;
                    expression = "Bad operator.";
                    return false;
            }
        }
    }
}