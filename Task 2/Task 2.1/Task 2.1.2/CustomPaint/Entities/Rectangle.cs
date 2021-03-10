using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Rectangle : Square
    {
        public double B { get; set; }

        public Rectangle(Point centre, double a, double b, Color color) : base(centre, a, color)
        {
            B = b;
        }

        public override double Perimeter
        {
            get
            {
                return 2 * A + 2 * B;
            }
        }

        public override double Area
        {
            get
            {
                return A * B;
            }
        }

        public override string ToString()
        {
            return $"Прямоугольник Периметр: {Perimeter} Площадь: {Area} Цвет: {Color}";
        }
    }
}
