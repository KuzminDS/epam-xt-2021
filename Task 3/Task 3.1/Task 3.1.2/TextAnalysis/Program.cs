using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите имя файла:");
            var fileName = Console.ReadLine();
            string text;

            try
            {
                text = ReadFile(fileName);
            }
            catch (Exception)
            {
                Console.WriteLine("Файл с указанным путем не может быть считан.");
                return;
            }

            var table = GetWordsFrequency(text);

            Console.WriteLine("Частота слов в тексте:");
            foreach (var item in table)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

        private static IDictionary<string, int> GetWordsFrequency(string text)
        {
            var table = new Dictionary<string, int>();
            var separators = "[} .,;:!?(){]\"'" + Environment.NewLine;
            var words = text.Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                var lowercaseWord = word.ToLower();
                if (table.ContainsKey(lowercaseWord))
                {
                    table[lowercaseWord]++;
                }
                else
                {
                    table.Add(lowercaseWord, 1);
                }
            }

            return table.OrderByDescending(pair => pair.Value)
                        .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private static string ReadFile(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
