using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Rectangle : Figure
    {
        public double Height { get; }
        public double Width { get; }
        public bool IsSquare { get; set; }


        public Rectangle(Point centre, double height, Color color) : base(centre, color)
        {
            IsSquare = true;
            Height = height;
            Width = height;
        }

        public Rectangle(Point centre, double height, double width, Color color)
            : this(centre, height, color)
        {
            IsSquare = height == width;
            Height = height;
            if (IsSquare)
                Width = height;
            else
                Width = width;
        }

        public override double Perimeter
        {
            get
            {
                return 2 * Height + 2 * Width;
            }
        }

        public override double Area
        {
            get
            {
                return Height * Width;
            }
        }

        public override string ToString()
        {
            var info = $"Ширина = {Width} {base.ToString()}";

            return IsSquare ? $"Квадрат {info}" : $"Прямоугольник Длина = {Height} {info}";
        }
    }
}
