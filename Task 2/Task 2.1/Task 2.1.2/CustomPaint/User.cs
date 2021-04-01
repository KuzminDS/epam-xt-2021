using CustomPaint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint
{
    public class User
    {
        public User(string name, List<GeometricEntity> shapes)
        {
            Name = name;
            Shapes = shapes;
        }

        public string Name { get; }

        public List<GeometricEntity> Shapes { get; }
    }
}
