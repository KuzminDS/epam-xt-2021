using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Square : Figure
    {
        public double A { get; }
        public Square(Point centre, double a, Color color) : base(centre, color)
        {
            A = a;
        }

        public override double Perimeter
        {
            get
            {
                return 4 * A;
            }
        }

        public virtual double Area
        {
            get
            {
                return A * A;
            }
        }

        public override string ToString()
        {
            return $"Квадрат Периметр: {Perimeter} Площадь: {Area} Цвет: {Color}";
        }
    }
}
