using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint.Entities
{
    public class Rectangle : Figure
    {
        private const double eps = 0.00000001d; 

        public double Height { get; }
        public double Width { get; }
        public bool IsSquare { get; set; }


        public Rectangle(Point centre, double height, Color color) : base(centre, color)
        {
            if (height < 0)
                throw new Exception("The side is negative");

            IsSquare = true;
            Height = height;
            Width = height;
        }

        public Rectangle(Point centre, double height, double width, Color color)
            : this(centre, height, color)
        {
            if (width < 0)
                throw new Exception("The side is negative");

            IsSquare = (height - width) < eps;
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
            var info = $"{base.ToString()} Периметр: {Perimeter} Площадь: {Area} Цвет: {Color}";

            return IsSquare ? $"Квадрат {info}" : $"Прямоугольник {info}";
        }
    }
}
