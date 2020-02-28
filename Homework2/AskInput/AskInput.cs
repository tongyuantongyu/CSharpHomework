using System;

internal static class AskInput
{
    public static int AskPosInt()
    {
        Console.Write("Input a positive integer: ");
        int result;
        while (!int.TryParse(Console.ReadLine(), out result) || result <= 0) Console.Write("Bad value. Please retry: ");
        return result;
    }

    public static double AskDouble()
    {
        Console.Write("Input a number: ");
        double result;
        while (!double.TryParse(Console.ReadLine(), out result)) Console.Write("Bad value. Please retry: ");
        return result;
    }
}