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
                var people = CreateCollection(number).ToList();
                StartGame(people, removingNumber);
            }
            else
            {
                Console.WriteLine("ВЫВОД: Невозможно вычеркнуть человека с номером больше, чем есть в кругу.");
            }
        }

        private static void StartGame(List<Person> people, int removingNumber)
        {
            Console.WriteLine($"ВЫВОД: Сгенерирован круг людей. Начинаем вычеркивать каждого {removingNumber}-го.");

            var removingIndex = removingNumber - 1;
            var round = 1;

            while (people.Count >= removingNumber)
            {
                if(removingIndex < people.Count)
                {
                    var num = people[removingIndex].Number;
                    people.RemoveAt(removingIndex);
                    Console.WriteLine($"ВЫВОД: Раунд {round++}. Вычеркнут человек №{num}. Людей осталось: {people.Count}");

                    removingIndex += removingNumber - 1;
                }
                else
                {
                    removingIndex += removingNumber - people.Count - 2;
                }
            }

            Console.WriteLine("ВЫВОД: Игра окончена. Невозможно вычеркнуть больше людей.");
            Console.Write("Список номеров победителей: ");
            foreach (var person in people)
                Console.Write($"{person.Number} ");
            Console.WriteLine();
        }

        private static IEnumerable<Person> CreateCollection(int number)
        {
            return Enumerable.Range(1, number).Select(n => new Person { Number = n });
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
