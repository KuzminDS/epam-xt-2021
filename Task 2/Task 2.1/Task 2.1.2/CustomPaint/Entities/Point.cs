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

        public override string ToString()
        {
            return $"Точка X = {X} Y = {Y} Цвет: {Color}";
        }
    }
}
