using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public abstract class Figure : GeometricEntity
    {
        public Point Centre { get; }

        public Figure(Point centre, Color color) : base(color)
        {
            Centre = centre;
        }

        public abstract double Perimeter { get; }
    }
}
