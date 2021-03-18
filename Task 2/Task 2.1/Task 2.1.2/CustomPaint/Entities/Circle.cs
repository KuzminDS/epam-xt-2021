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

        public bool IsСircumference { get; }

        public Circle(Point centre, double radius, Color color, bool isСircumference = false) 
            : base(centre, color)
        {
            if (radius < 0)
                throw new Exception("Radius is negative");

            Radius = radius;
            IsСircumference = isСircumference;
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
                return !IsСircumference ? Math.PI * Radius * Radius : 0;
            }
        }

        public override string ToString()
        {
            var info = $"{base.ToString()} Радиус: {Radius} Длина: {Perimeter} Цвет: {Color}";
            
            return IsСircumference ? $"Окружность {info}" : $"Круг Площадь: {Area} {info}";
        }
    }
}
