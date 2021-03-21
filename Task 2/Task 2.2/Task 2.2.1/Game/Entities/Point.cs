using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    class Point : IEquatable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public static bool operator ==(Point first, Point second)
            => first.Equals(second);

        public static bool operator !=(Point first, Point second)
            => !first.Equals(second);
    }
}
