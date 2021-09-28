using GCForSummerSchool.Interfaces;
using System;

namespace GCForSummerSchool.Models
{
    public class Point : IPoint
    {
        // Constructor:
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        // Property implementation:
        public int X { get; set; }

        public int Y { get; set; }

        // Property implementation
        public double Distance =>
           Math.Sqrt(X * X + Y * Y);

        public override string ToString() => $"X is {X}, Y is {Y}";
    }
}