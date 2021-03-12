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
        AddShape = 1,
        PrintAllShapes,
        ClearCanvas,
        Exit,
        ChangeUser
    }

    enum Shapes
    {
        Point = 1,
        Line,
        Сircumference,
        Circle,
        Ring,
        Triangle,
        Square,
        Rectangle
    }

    enum ShapeOptions
    {
        Point = 1,
        Line,
        Сircumference,
        Circle,
        Ring,
        Triangle,
        Square,
        Rectangle
    }

    class Program
    {
        private static UserService _userService;

        static void Main(string[] args)
        {
            _userService = new UserService();

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
                    user.Shapes.Clear();
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

        private static void PrintShapes(User user)
        {
            Console.WriteLine("ВЫВОД: Список фигур:");
            foreach (var shape in user.Shapes)
            {
                if (shape is Point point)
                {
                    Console.WriteLine(point);
                }
                else if (shape is Line line)
                {
                    Console.WriteLine(line);
                }
                else if (shape is Circle circle)
                {
                    Console.WriteLine(circle);
                }
                else if (shape is Сircumference сircumference)
                {
                    Console.WriteLine(сircumference);
                }
                else if (shape is Ring ring)
                {
                    Console.WriteLine(ring);
                }
                else if (shape is Triangle triangle)
                {
                    Console.WriteLine(triangle);
                }
                else if (shape is Rectangle rectangle)
                {
                    Console.WriteLine(rectangle);
                }
                else if (shape is Square square)
                {
                    Console.WriteLine(square);
                }
            }
        }

        private static void PrintMenu()
        {
            Console.WriteLine(@"ВЫВОД: Выберите действие
1. Добавить фигуру
2. Вывести фигуры 
3. Очистить холст
4. Выход
5. Сменить пользователя");
        }

        private static User ChangeUser()
        {
            Console.WriteLine("ВЫВОД: Введите имя пользователя");
            string name = Console.ReadLine();
            User user;
            try
            {
                user = _userService.GetByName(name);
            }
            catch (Exception)
            {
                user = new User
                {
                    Name = name,
                    Shapes = new List<GeometricEntity>()
                };
                _userService.Add(user);
            }

            return user;
        }

        private static void PrintShapeOptions()
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

        private static void PrintColorOptions()
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

        private static Color EnterColor()
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

        private static double EnterCoordinate()
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (double.TryParse(value, out double coordinate))
                    return coordinate;
                else
                    Console.WriteLine("ВЫВОД: Неправильное значение");

            } while (true);
        }

        private static Point EnterPoint(Color color)
        {
            Console.WriteLine("ВЫВОД: Введите первую координату: ");
            var x = EnterCoordinate();
            Console.WriteLine("ВЫВОД: Введите вторую координату: ");
            var y = EnterCoordinate();
            return new Point(x, y, color);
        }

        private static double EnterPositiveScalar()
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (double.TryParse(value, out double scalar) && scalar > 0)
                    return scalar;
                else
                    Console.WriteLine("ВЫВОД: Неправильное значение");

            } while (true);
        }

        private static Line EnterLine(Color color)
        {
            Console.WriteLine("ВЫВОД: Введите первую точку");
            var point1 = EnterPoint(color);
            Console.WriteLine("ВЫВОД: Введите вторую точку");
            var point2 = EnterPoint(color);
            return new Line(point1, point2, color);
        }

        private static Сircumference EnterСircumference<T>(Color color) where T : Сircumference
        {
            Console.WriteLine("ВЫВОД: Введите центр");
            var centre = EnterPoint(color);
            Console.WriteLine("ВЫВОД: Введите радиус: ");
            var radius = EnterPositiveScalar();
            if (typeof(T) == typeof(Circle))
            {
                return new Circle(centre, radius, color);
            }
            else
            {
                return new Сircumference(centre, radius, color);
            }
        }

        private static Ring EnterRing(Color color)
        {
            Console.WriteLine("ВЫВОД: Введите центр");
            var centre = EnterPoint(color);
            Console.WriteLine("ВЫВОД: Введите первый радиус: ");
            var radius1 = EnterPositiveScalar();
            Console.WriteLine("ВЫВОД: Введите второй радиус: ");
            var radius2 = EnterPositiveScalar();

            return new Ring(centre, Math.Min(radius1, radius2), Math.Max(radius1, radius2), color);
        }

        private static Triangle EnterTriangle(Color color)
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
                    Console.WriteLine("ВЫВОД: Неправильное значение");
                }
                else
                {
                    return new Triangle(p1, p2, p3, color);
                }
            } while (true);
        }

        private static Square EnterRectangle<T>(Color color) where T : Square
        {
            Console.WriteLine("ВЫВОД: Введите центр");
            var centre = EnterPoint(color);
            Console.WriteLine("ВЫВОД: Введите сторону: ");
            var a = EnterPositiveScalar();
            if (typeof(T) == typeof(Rectangle))
            {
                Console.WriteLine("ВЫВОД: Введите вторую сторону: ");
                var b = EnterPositiveScalar();
                return new Rectangle(centre, a, b, color);
            }
            else
            {
                return new Square(centre, a, color);
            }
        }

        private static void AddShape(User user)
        {
            PrintShapeOptions();
            Console.Write("ВВОД: ");
            var shapeOption = (ShapeOptions)Enum.Parse(typeof(ShapeOptions), Console.ReadLine());

            var color = EnterColor();

            if (shapeOption == ShapeOptions.Point)
            {
                user.Shapes.Add(EnterPoint(color));
            }
            else if (shapeOption == ShapeOptions.Line)
            {
                user.Shapes.Add(EnterLine(color));
            }
            else if (shapeOption == ShapeOptions.Сircumference)
            {
                user.Shapes.Add(EnterСircumference<Сircumference>(color));
            }
            else if (shapeOption == ShapeOptions.Circle)
            {
                user.Shapes.Add(EnterСircumference<Circle>(color));
            }
            else if (shapeOption == ShapeOptions.Ring)
            {
                user.Shapes.Add(EnterRing(color));
            }
            else if (shapeOption == ShapeOptions.Triangle)
            {
                user.Shapes.Add(EnterTriangle(color));
            }
            else if (shapeOption == ShapeOptions.Square)
            {
                user.Shapes.Add(EnterRectangle<Square>(color));
            }
            else if (shapeOption == ShapeOptions.Rectangle)
            {
                user.Shapes.Add(EnterRectangle<Rectangle>(color));
            }
            else
            {
                Console.WriteLine("ВЫВОД: Неправильный выбор");
            }
        }
    }
}
