using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Point : GeometricEntity
    {
        public double X { get; }
        public double Y { get; }
        public Point(double x, double y, Color color) : base(color)
        {
            X = x;
            Y = y;
        }

        public static Point GetAverage(params Point[] points)
        {
            double x = 0;
            double y = 0;
            foreach (var point in points)
            {
                x += point.X;
                y += point.Y;
            }
            x /= points.Length;
            y /= points.Length;

            return new Point(x, y, points[0].Color);
        }

        public override string ToString()
        {
            return $"Точка X = {X} Y = {Y} {base.ToString()}";
        }
    }
}
