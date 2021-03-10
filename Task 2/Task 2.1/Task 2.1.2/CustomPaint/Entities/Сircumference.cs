using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Сircumference : Figure
    {
        public double Radius { get; }

        public Сircumference(Point centre, double radius, Color color) 
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

        public override string ToString()
        {
            return $"Окружность Радиус: {Radius} Длина: {Perimeter} Цвет: {Color}";
        }
    }
}
