using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Ring : Figure
    {
        public Circle InnerCircle { get; }
        public Circle OuterCircle { get; }

        public Ring(Point centre, double insideRadius, double outsideRadius, Color color) 
            : base(centre, color)
        {
            InnerCircle = new Circle(centre, insideRadius, color);
            OuterCircle = new Circle(centre, outsideRadius, color);
        }

        public override double Perimeter
            => InnerCircle.Perimeter + OuterCircle.Perimeter;

        public override double Area
            => OuterCircle.Area - InnerCircle.Area;

        public override string ToString()
        {
            return $"Кольцо Внешний радиус: {OuterCircle.Radius} Внутренний радиус: {InnerCircle.Radius} {base.ToString()}";
        }
    }
}
