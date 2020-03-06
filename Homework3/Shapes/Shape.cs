using System;
using System.Security.AccessControl;

namespace Shapes
{
    public interface IShape
    {
        double Area { get; }
    }

    public class Rectangle : IShape
    {
        // No necessity for modification ability after construction, prohibit it.
        // Refactor into property and internal valid check function for such use case.
        // ReSharper disable MemberCanBePrivate.Global
        // ReSharper disable MemberCanBeProtected.Global
        public readonly double Width, Height;
        // ReSharper restore MemberCanBeProtected.Global
        // ReSharper restore MemberCanBePrivate.Global

        public Rectangle(double w, double h)
        {
            if (w > 0 && h > 0)
            {
                Width = w;
                Height = h;
            }
            else
            {
                throw new ArgumentException("Invalid shape.");
            }
        }

        public double Area => Width * Height;

        public override string ToString()
        {
            return $"Rectangle(w={Width}, h={Height}, S={Area})";
        }
    }

    public class Square : Rectangle
    {
        public Square(double a) : base(a, a)
        {
        }

        public override string ToString()
        {
            return $"Square(a={Width}, S={Area})";
        }
    }

    public class Triangle : IShape
    {
        // ReSharper disable MemberCanBePrivate.Global
        public readonly double Width, Height;
        // ReSharper restore MemberCanBePrivate.Global

        public Triangle(double w, double h)
        {
            if (w > 0 && h > 0)
            {
                Width = w;
                Height = h;
            }
            else
            {
                throw new ArgumentException("Invalid shape.");
            }
        }

        public Triangle(double a, double b, double c)
        {
            if (a > 0 && b > 0 && c > 0 && a + b > c && b + c > a && a + c > b)
            {
                Width = a;
                Height = Math.Sqrt(b * b - (a * a + b * b - c * c) / (4 * a * a));
            }
            else
            {
                throw new ArgumentException("Invalid shape.");
            }
        }

        public double Area => Width * Height / 2;

        public override string ToString()
        {
            return $"Triangle(w={Width}, h={Height}, S={Area})";
        }
    }
}