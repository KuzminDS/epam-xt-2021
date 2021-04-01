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
            if (p1.X == p2.X && p1.Y == p2.Y)
                throw new Exception("Линия не может точкой p1 == p2");

            P1 = p1;
            P2 = p2;
        }

        public double Length 
        { 
            get
            {
                var xDif = (P2.X - P1.X);
                var yDif = (P2.Y - P1.Y);
                return Math.Sqrt(xDif * xDif + yDif * yDif);
            }
        }

        public override string ToString()
        {
            return $"Линия Длина: {Length} {base.ToString()}";
        }
    }
}
