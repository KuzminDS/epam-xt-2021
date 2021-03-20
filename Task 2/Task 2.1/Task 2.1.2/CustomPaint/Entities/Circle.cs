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
            Radius = radius;
        }

        public override double Perimeter
        {
            get
            {
                return 2 * Math.PI * Radius;
            }
        }


        public override double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public override string ToString()
        {
            return $"Круг Радиус: {Radius} {base.ToString()}";
        }
    }
}
