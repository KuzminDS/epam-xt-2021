using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Triangle : Figure
    {
        public Line Line1 { get; }
        public Line Line2 { get; }
        public Line Line3 { get; }

        public Triangle(Point p1, Point p2, Point p3, Color color)
            : base(new Point((p1.X + p2.X + p3.X) / 3, (p1.Y + p2.Y + p3.Y) / 3, color), color) //вычисление центра треугольника
        {
            Line1 = new Line(p1, p2, color);
            Line2 = new Line(p2, p3, color);
            Line3 = new Line(p3, p1, color);
        }

        public override double Perimeter
        {
            get
            {
                return Line1.Length + Line2.Length + Line3.Length;
            }
        }

        public override double Area
        {
            get
            {
                double HalfP = Perimeter / 2;
                return Math.Sqrt(HalfP * (HalfP - Line1.Length) * (HalfP - Line2.Length) * (HalfP - Line3.Length));
            }
        }

        public override string ToString()
        {
            return $"Треугольник {base.ToString()}";
        }
    }
}
