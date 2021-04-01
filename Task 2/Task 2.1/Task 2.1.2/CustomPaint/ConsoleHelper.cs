using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomPaint
{
    public static class ConsoleHelper
    {
        public static double EnterScalar()
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (double.TryParse(value, out double scalar))
                    return scalar;
                else
                    Console.WriteLine("ВЫВОД: Неверное значение! Введите действительное число.");

            } while (true);
        }

        public static double EnterPositiveScalar()
        {
            do
            {
                var scalar = EnterScalar();

                if (scalar > 0)
                    return scalar;
                else
                    Console.WriteLine("ВЫВОД: Неверное значение! Введите действительное положительное число.");

            } while (true);
        }
    }
}
