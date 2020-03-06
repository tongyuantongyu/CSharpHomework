using System;
using System.Collections.Generic;
using System.Linq;

namespace Shapes
{
    internal static class ShapeFactory
    {
        private static readonly Random R = new Random();

        // ReSharper disable once MemberCanBePrivate.Global
        public static IShape GetShape(string shapeType)
        {
            switch (shapeType.ToLower())
            {
                case "rectangle":
                    return new Rectangle(10 * R.NextDouble(), 10 * R.NextDouble());
                case "square":
                    return new Square(10 * R.NextDouble());
                case "triangle":
                    return new Triangle(10 * R.NextDouble(), 10 * R.NextDouble());
                default:
                    throw new ArgumentException("Unknown shape");
            }
        }

        public static IShape GetShape()
        {
            var shapes = new List<string> {"rectangle", "square", "triangle"};
            return GetShape(shapes[R.Next(0, 3)]);
        }
    }

    internal static class Program
    {
        private static void Main(string[] args)
        {
            var area = Enumerable.Range(0, 10)
                .Select(_ => ShapeFactory.GetShape())
                .Sum(i =>
                {
                    Console.WriteLine(i.ToString());
                    return i.Area;
                });
            Console.WriteLine($"Total area of the 10 shapes are {area}.");
            Console.ReadLine();
        }
    }
}