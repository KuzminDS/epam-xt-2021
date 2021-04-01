using CustomPaint.Entities;
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
                    case MainMenuOptions.AddShape:
                        AddShape(user);
                        break;
                    case MainMenuOptions.PrintAllShapes:
                        PrintShapes(user);
                        break;
                    case MainMenuOptions.ClearCanvas:
                        _painter.ClearShapes(user);
                        Console.WriteLine("ВЫВОД: Список фигур пуст");
                        break;
                    case MainMenuOptions.Exit:
                        Console.WriteLine("ВЫВОД: Выход");
                        isOver = true;
                        break;
                    case MainMenuOptions.ChangeUser:
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
            do
            {
                Console.WriteLine("ВЫВОД: Введите имя пользователя");
                string name = Console.ReadLine();

                try
                {
                    return _painter.ChangeUser(name);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
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

            switch (shapeOption)
            {
                case Shapes.Point:
                    _painter.AddShape(user, EnterPoint(color));
                    break;
                case Shapes.Line:
                    _painter.AddShape(user, EnterLine(color));
                    break;
                case Shapes.Circle:
                    _painter.AddShape(user, EnterCircle(color));
                    break;
                case Shapes.Ring:
                    _painter.AddShape(user, EnterRing(color));
                    break;
                case Shapes.Triangle:
                    _painter.AddShape(user, EnterTriangle(color));
                    break;
                case Shapes.Square:
                    _painter.AddShape(user, EnterRectangle(true, color));
                    break;
                case Shapes.Rectangle:
                    _painter.AddShape(user, EnterRectangle(false, color));
                    break;
                default:
                    Console.WriteLine("ВЫВОД: Неправильный выбор");
                    break;
            }
        }

        private T EnterEnum<T>() where T : struct, Enum
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (Enum.TryParse(value, ignoreCase: true, out T option))
                    return option;
                else
                    Console.WriteLine("ВЫВОД: Неверный ввод. Введите опцию из списка выше.");

            } while (true);
        }

        private MainMenuOptions EnterOption()
        {
            return EnterEnum<MainMenuOptions>();
        }

        private Shapes EnterShape()
        {
            return EnterEnum<Shapes>();
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

            return EnterEnum<Color>();
        }



        private Point EnterPoint(Color color)
        {
            Console.WriteLine("ВЫВОД: Введите первую координату: ");
            var x = ConsoleHelper.EnterScalar();
            Console.WriteLine("ВЫВОД: Введите вторую координату: ");
            var y = ConsoleHelper.EnterScalar();
            return new Point(x, y, color);
        }

        private Line EnterLine(Color color)
        {
            do
            {
                Console.WriteLine("ВЫВОД: Введите первую точку");
                var point1 = EnterPoint(color);
                Console.WriteLine("ВЫВОД: Введите вторую точку");
                var point2 = EnterPoint(color);
                try
                {
                    return new Line(point1, point2, color);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }

        private Circle EnterCircle(Color color)
        {
            do
            {
                Console.WriteLine("ВЫВОД: Введите центр");
                var centre = EnterPoint(color);
                Console.WriteLine("ВЫВОД: Введите радиус: ");
                var radius = ConsoleHelper.EnterPositiveScalar();

                try
                {
                    return new Circle(centre, radius, color);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (true);
        }

        private Ring EnterRing(Color color)
        {
            Console.WriteLine("ВЫВОД: Введите центр");
            var centre = EnterPoint(color);
            Console.WriteLine("ВЫВОД: Введите первый радиус: ");
            var radius1 = ConsoleHelper.EnterPositiveScalar();
            Console.WriteLine("ВЫВОД: Введите второй радиус: ");
            var radius2 = ConsoleHelper.EnterPositiveScalar();

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

                try
                {
                    return new Triangle(p1, p2, p3, color);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            } while (true);
        }

        private Rectangle EnterRectangle(bool isSquare, Color color)
        {
            do
            {
                Console.WriteLine("ВЫВОД: Введите центр");
                var centre = EnterPoint(color);
                Console.WriteLine("ВЫВОД: Введите сторону: ");
                var a = ConsoleHelper.EnterPositiveScalar();

                try
                {
                    if (!isSquare)
                    {
                        Console.WriteLine("ВЫВОД: Введите вторую сторону: ");
                        var b = ConsoleHelper.EnterPositiveScalar();
                        return new Rectangle(centre, a, b, color);
                    }

                    return new Rectangle(centre, a, color);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            } while (true);
        }
    }
}
