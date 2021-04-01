using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Circle : Figure
    {
        public double Radius { get; }

        public Circle(Point centre, double radius, Color color) 
            : base(centre, color)
        {
            if (radius <= 0)
                throw new Exception("Радиус не может быть отрицательным");

            Radius = radius;
        }

        public override double Perimeter => 2 * Math.PI * Radius;

        public override double Area => Math.PI * Radius * Radius;

        public override string ToString()
        {
            return $"Круг Радиус: {Radius} {base.ToString()}";
        }
    }
}
