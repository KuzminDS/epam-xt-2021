using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public abstract class GeometricEntity
    {
        public Color Color { get; }

        public GeometricEntity(Color color)
        {
            Color = color;
        }

        public override string ToString()
        {
            return $"Цвет: {Color}";
        }
    }
}
