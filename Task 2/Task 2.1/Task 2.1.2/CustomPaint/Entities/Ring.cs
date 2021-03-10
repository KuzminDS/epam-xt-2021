using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Ring : Figure
    {
        public Сircumference InsideСircumference { get; }
        public Сircumference OutsideСircumference { get; }

        public Ring(Point centre, double insideRadius, double outsideRadius, Color color) 
            : base(centre, color)
        {
            InsideСircumference = new Сircumference(centre, insideRadius, color);
            OutsideСircumference = new Сircumference(centre, outsideRadius, color);
        }

        public override double Perimeter
        {
            get
            {
                return InsideСircumference.Perimeter + OutsideСircumference.Perimeter;
            }
        }

        public double Area
        {
            get
            {
                return Math.PI * OutsideСircumference.Radius * OutsideСircumference.Radius
                    - Math.PI * InsideСircumference.Radius * InsideСircumference.Radius;
            }
        }

        public override string ToString()
        {
            return $"Кольцо Внешний радиус: {OutsideСircumference.Radius} Внутренний радиус: {InsideСircumference.Radius} Длина: {Perimeter} Площадь: {Area} Цвет: {Color}";
        }
    }
}
