using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Line : GeometricEntity
    {
        public Point P1 { get; }
        public Point P2 { get; }

        public Line(Point p1, Point p2, Color color) : base(color)
        {
            P1 = p1;
            P2 = p2;
        }

        public double Length 
        { 
            get
            {
                return Math.Sqrt((P2.X - P1.X) * (P2.X - P1.X) 
                    + (P2.Y - P1.Y) * (P2.Y - P1.Y));
            }
        }

        public override string ToString()
        {
            return $"Линия Длина: {Length} Цвет: {Color}";
        }
    }
}
