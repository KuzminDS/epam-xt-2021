using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Entities
{
    public class Point : IEquatable<Point>
    {
        public double X { get; set; }
        public double Y { get; set; }

        public bool Equals(Point other)
        {
            return this.X == other.X && this.Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Point p = obj as Point;
            return this.Equals(p);
        }

        public static bool operator ==(Point first, Point second)
            => first.Equals(second);

        public static bool operator !=(Point first, Point second)
            => !first.Equals(second);
    }
}
