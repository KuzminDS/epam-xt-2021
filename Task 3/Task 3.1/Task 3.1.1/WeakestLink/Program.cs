using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeakestLink
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ВЫВОД: Введите N");
            var number = EnterNumber();
            Console.WriteLine("ВЫВОД: Введите, какой по счету человек будет вычеркнут каждый раунд:");
            var removingNumber = EnterNumber();

            if (number >= removingNumber)
            {
                var people = CreateList(number).ToList();
                StartGame(people, removingNumber);
            }
            else
            {
                Console.WriteLine("ВЫВОД: Невозможно вычеркнуть человека с номером больше, чем есть в кругу.");
            }
        }

        private static void StartGame(ICollection<Person> people, int removingNumber)
        {
            Console.WriteLine("ВЫВОД: Сгенерирован круг людей. Начинаем вычеркивать каждого второго.");

            var removingIndex = removingNumber - 1;
            var round = 1;

            while (people.Count >= removingNumber)
            {
                var person = people.ElementAtOrDefault(removingIndex);

                if (person != null)
                {
                    people.Remove(person);
                    Console.WriteLine($"ВЫВОД: Раунд {round++}. Вычеркнут человек. Людей осталось: {people.Count}");

                    removingIndex += removingNumber - 1;
                }
                else
                {
                    removingIndex = removingNumber - 1 - people.Count + removingIndex;
                }
            }

            Console.WriteLine("ВЫВОД: Игра окончена. Невозможно вычеркнуть больше людей.");
        }

        private static IEnumerable<Person> CreateList(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                yield return new Person { Number = i };
            }
        }

        private static int EnterNumber()
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (int.TryParse(value, out int number) && number > 0)
                    return number;
                else
                    Console.WriteLine("ВЫВОД: Неправильное значение! Введите целочисленное положительное число.");

            } while (true);
        }
    }
}
