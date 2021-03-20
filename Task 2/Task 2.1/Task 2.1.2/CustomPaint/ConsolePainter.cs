using CustomPaint.Entities;
using CustomPaint.Validators;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint
{
    public class ConsolePainter
    {
        private readonly Painter _painter;

        public ConsolePainter(Painter painter)
        {
            _painter = painter;
        }

        public void Start()
        {
            var user = ChangeUser();

            var isOver = false;

            while (!isOver)
            {
                Console.WriteLine(string.Join(Environment.NewLine,
                                              "ВЫВОД: Выберите действие: ",
                                              "1. Добавить фигуру",
                                              "2. Вывести фигуры",
                                              "3. Очистить холст",
                                              "4. Выход",
                                              "5. Сменить пользователя"));

                var option = EnterOption();

                switch (option)
                {
                    case Options.AddShape:
                        AddShape(user);
                        break;
                    case Options.PrintAllShapes:
                        PrintShapes(user);
                        break;
                    case Options.ClearCanvas:
                        _painter.ClearShapes(user);
                        Console.WriteLine("ВЫВОД: Список фигур пуст");
                        break;
                    case Options.Exit:
                        Console.WriteLine("ВЫВОД: Выход");
                        isOver = true;
                        break;
                    case Options.ChangeUser:
                        Console.WriteLine("ВЫВОД: Смена пользователя...");
                        user = ChangeUser();
                        break;
                    default:
                        Console.WriteLine("ВЫВОД: Неверное действие!");
                        break;
                }
            }
        }

        private User ChangeUser()
        {
            Console.WriteLine("ВЫВОД: Введите имя пользователя");
            string name = Console.ReadLine();

            return _painter.ChangeUser(name);
        }

        private void PrintShapes(User user)
        {
            Console.WriteLine("ВЫВОД: Список фигур:");
            foreach (var shape in _painter.GetShapes(user))
            {
                Console.WriteLine(shape);
            }
        }

        private void AddShape(User user)
        {
            Console.WriteLine(string.Join(Environment.NewLine,
                                          "ВЫВОД: Выберите тип фигуры:",
                                          "1. Точка",
                                          "2. Линия",
                                          "3. Круг",
                                          "4. Кольцо",
                                          "5. Треугольник",
                                          "6. Квадрат",
                                          "7. Прямоугольник"));

            var shapeOption = EnterShape();

            var color = EnterColor();

            ICollection<ValidationFailure> errorList = new List<ValidationFailure>();

            switch (shapeOption)
            {
                case Shapes.Point:
                    _painter.AddShape(user, EnterPoint(color), out errorList);
                    break;
                case Shapes.Line:
                    _painter.AddShape(user, EnterLine(color), out errorList);
                    break;
                case Shapes.Circle:
                    _painter.AddShape(user, EnterCircle(Shapes.Circle, color), out errorList);
                    break;
                case Shapes.Ring:
                    _painter.AddShape(user, EnterRing(color), out errorList);
                    break;
                case Shapes.Triangle:
                    _painter.AddShape(user, EnterTriangle(color), out errorList);
                    break;
                case Shapes.Square:
                    _painter.AddShape(user, EnterRectangle(Shapes.Square, color), out errorList);
                    break;
                case Shapes.Rectangle:
                    _painter.AddShape(user, EnterRectangle(Shapes.Rectangle, color), out errorList);
                    break;
                default:
                    Console.WriteLine("ВЫВОД: Неправильный выбор");
                    break;
            }

            if (errorList.Any())
            {
                foreach (var error in errorList)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
        }

        private Options EnterOption()
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (Enum.TryParse(value, ignoreCase: true, out Options option))
                    return option;
                else
                    Console.WriteLine("ВЫВОД: Неверный ввод. Введите номер действия.");

            } while (true);
        }

        private Shapes EnterShape()
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (Enum.TryParse(value, ignoreCase: true, out Shapes shape))
                    return shape;
                else
                    Console.WriteLine("ВЫВОД: Неверный ввод. Введите номер фигуры.");

            } while (true);
        }

        private Color EnterColor()
        {
            Console.WriteLine(string.Join(Environment.NewLine,
                                          "ВЫВОД: Выберите цвет фигуры:",
                                          "1. Желтый",
                                          "2. Оранжевый",
                                          "3. Красный",
                                          "4. Зеленый",
                                          "5. Синий",
                                          "6. Розовый",
                                          "7. Черный"));

            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (Enum.TryParse(value, ignoreCase: true, out Color color))
                    return color;
                else
                    Console.WriteLine("ВЫВОД: Неправильный выбор. Введите номер цвета.");

            } while (true);
        }

        private double EnterCoordinate()
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (double.TryParse(value, out double coordinate))
                    return coordinate;
                else
                    Console.WriteLine("ВЫВОД: Неверное значение! Введите действительное число.");

            } while (true);
        }

        private Point EnterPoint(Color color)
        {
            Console.WriteLine("ВЫВОД: Введите первую координату: ");
            var x = EnterCoordinate();
            Console.WriteLine("ВЫВОД: Введите вторую координату: ");
            var y = EnterCoordinate();
            return new Point(x, y, color);
        }

        private double EnterPositiveScalar()
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (double.TryParse(value, out double scalar) && scalar > 0)
                    return scalar;
                else
                    Console.WriteLine("ВЫВОД: Неправильное значение! Введите действительное положительное число.");

            } while (true);
        }

        private Line EnterLine(Color color)
        {
            Console.WriteLine("ВЫВОД: Введите первую точку");
            var point1 = EnterPoint(color);
            Console.WriteLine("ВЫВОД: Введите вторую точку");
            var point2 = EnterPoint(color);
            return new Line(point1, point2, color);
        }

        private Circle EnterCircle(Shapes shape, Color color)
        {
            Console.WriteLine("ВЫВОД: Введите центр");
            var centre = EnterPoint(color);
            Console.WriteLine("ВЫВОД: Введите радиус: ");
            var radius = EnterPositiveScalar();
            return new Circle(centre, radius, color);
        }

        private Ring EnterRing(Color color)
        {
            Console.WriteLine("ВЫВОД: Введите центр");
            var centre = EnterPoint(color);
            Console.WriteLine("ВЫВОД: Введите первый радиус: ");
            var radius1 = EnterPositiveScalar();
            Console.WriteLine("ВЫВОД: Введите второй радиус: ");
            var radius2 = EnterPositiveScalar();

            return new Ring(centre, Math.Min(radius1, radius2), Math.Max(radius1, radius2), color);
        }

        private Triangle EnterTriangle(Color color)
        {
            do
            {
                Console.WriteLine("ВЫВОД: Введите первую точку");
                var p1 = EnterPoint(color);
                Console.WriteLine("ВЫВОД: Введите вторую точку");
                var p2 = EnterPoint(color);
                Console.WriteLine("ВЫВОД: Введите третью точку");
                var p3 = EnterPoint(color);
                if ((p3.X - p1.X) / (p2.X - p1.X) == (p3.Y - p1.X) / (p2.Y - p1.X))
                {
                    Console.WriteLine("ВЫВОД: Треугольник некорректный, указанные вершины лежат на одной прямой. Введите данные снова.");
                }
                else
                {
                    return new Triangle(p1, p2, p3, color);
                }
            } while (true);
        }

        private Rectangle EnterRectangle(Shapes shape, Color color)
        {
            Console.WriteLine("ВЫВОД: Введите центр");
            var centre = EnterPoint(color);
            Console.WriteLine("ВЫВОД: Введите сторону: ");
            var a = EnterPositiveScalar();
            if (shape == Shapes.Rectangle)
            {
                Console.WriteLine("ВЫВОД: Введите вторую сторону: ");
                var b = EnterPositiveScalar();
                return new Rectangle(centre, a, b, color);
            }
            else
            {
                return new Rectangle(centre, a, color);
            }
        }
    }
}
