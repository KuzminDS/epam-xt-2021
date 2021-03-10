using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Circle : Сircumference
    {
        public Circle(Point centre, double radius, Color color) 
            : base(centre, radius, color)
        {
        }

        public double Area
        {
            get
            {
                return Math.PI * Radius * Radius;
            }
        }

        public override string ToString()
        {
            return $"Круг Радиус: {Radius} Длина: {Perimeter} Площадь: {Area} Цвет: {Color}";
        }
    }
}
