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
        public bool IsSquare { get; private set; }


        public Rectangle(Point centre, double sideLength, Color color) : base(centre, color)
        {
            if (sideLength <= 0)
                throw new Exception("Сторона фигуры должна быть положительна");

            IsSquare = true;
            Height = sideLength;
            Width = sideLength;
        }

        public Rectangle(Point centre, double height, double width, Color color)
            : this(centre, height, color)
        {
            if (width <= 0)
                throw new Exception("Сторона фигуры должна быть положительна");

            IsSquare = height == width;
            Height = height;
            Width = width;
        }

        public override double Perimeter => 2 * (Height + Width);

        public override double Area => Height * Width;

        public override string ToString()
        {
            var info = $"Ширина = {Width} {base.ToString()}";

            return IsSquare ? $"Квадрат {info}" : $"Прямоугольник Длина = {Height} {info}";
        }
    }
}
