﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public enum Color { Yellow = 1, Orage, Red, Green, Blue, Purple, Black };

    public abstract class GeometricEntity
    {
        public Color Color { get; }

        public GeometricEntity(Color color)
        {
            Color = color;
        }
    }
}
