using CustomPaint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint
{
    enum Options
    {
        None,
        AddShape,
        PrintAllShapes,
        ClearCanvas,
        Exit,
        ChangeUser
    }

    enum Shapes
    {
        None,
        Point,
        Line,
        Сircumference,
        Circle,
        Ring,
        Triangle,
        Square,
        Rectangle
    }

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
                PrintMenu();
                Console.Write("ВВОД: ");
                var option = (Options)Enum.Parse(typeof(Options), Console.ReadLine());

                if (option == Options.AddShape)
                {
                    AddShape(user);
                }
                else if (option == Options.PrintAllShapes)
                {
                    PrintShapes(user);
                }
                else if (option == Options.ClearCanvas)
                {
                    _painter.ClearShapes(user);
                    Console.WriteLine("ВЫВОД: Список фигур пуст");
                }
                else if (option == Options.Exit)
                {
                    Console.WriteLine("ВЫВОД: Выход");
                    isOver = true;
                }
                else if (option == Options.ChangeUser)
                {
                    Console.WriteLine("ВЫВОД: Смена пользователя...");
                    user = ChangeUser();
                }
                else
                {
                    Console.WriteLine("ВЫВОД: Неверное действие!");
                }
            }
        }

        #region menu
        private void PrintMenu()
        {
            Console.WriteLine(@"ВЫВОД: Выберите действие
1. Добавить фигуру
2. Вывести фигуры 
3. Очистить холст
4. Выход
5. Сменить пользователя");
        }

        private void PrintShapeOptions()
        {
            Console.WriteLine(@"ВЫВОД: Выберите тип фигуры:
1. Точка
2. Линия
3. Окружность
4. Круг
5. Кольцо
6. Треугольник
7. Квадрат
8. Прямоугольник");
        }

        private void PrintColorOptions()
        {
            Console.WriteLine(@"ВЫВОД: Выберите цвет фигуры:
1. Желтый
2. Оранжевый
3. Красный
4. Зеленый
5. Синий
6. Розовый
7. Черный");
        }
        #endregion

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
            PrintShapeOptions();
            Console.Write("ВВОД: ");
            var shapeOption = (Shapes)Enum.Parse(typeof(Shapes), Console.ReadLine());

            var color = EnterColor();

            if (shapeOption == Shapes.Point)
            {
                _painter.AddShape(user, EnterPoint(color));
            }
            else if (shapeOption == Shapes.Line)
            {
                _painter.AddShape(user, EnterLine(color));
            }
            else if (shapeOption == Shapes.Сircumference)
            {
                _painter.AddShape(user, EnterCircle(Shapes.Сircumference, color));
            }
            else if (shapeOption == Shapes.Circle)
            {
                _painter.AddShape(user, EnterCircle(Shapes.Circle, color));
            }
            else if (shapeOption == Shapes.Ring)
            {
                _painter.AddShape(user, EnterRing(color));
            }
            else if (shapeOption == Shapes.Triangle)
            {
                _painter.AddShape(user, EnterTriangle(color));
            }
            else if (shapeOption == Shapes.Square)
            {
                _painter.AddShape(user, EnterRectangle(Shapes.Square, color));
            }
            else if (shapeOption == Shapes.Rectangle)
            {
                _painter.AddShape(user, EnterRectangle(Shapes.Rectangle, color));
            }
            else
            {
                Console.WriteLine("ВЫВОД: Неправильный выбор");
            }
        }

        private Color EnterColor()
        {
            PrintColorOptions();
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (Enum.TryParse(value, ignoreCase: true, out Color color))
                    return color;
                else
                    Console.WriteLine("ВЫВОД: Неправильный выбор");

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
            if (shape == Shapes.Сircumference)
            {
                return new Circle(centre, radius, color, true);
            }
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
