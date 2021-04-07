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
                text = File.ReadAllText(fileName);
            }
            catch (Exception)
            {
                Console.WriteLine("Файл с указанным путем не может быть считан.");
                return;
            }

            var table = GetWordsFrequency(text);

            Console.WriteLine("Частота слов в тексте:");
            Console.WriteLine(string.Format("|{0,20}|{1,15}|", "Слово", "Частота слов"));
            foreach (var item in table)
            {
                Console.WriteLine(string.Format("|{0,20}|{1,15}|", item.Key, item.Value));
            }

            Console.ReadKey();
        }

        private static IDictionary<string, int> GetWordsFrequency(string text)
        {
            var separators = text.Where(c => char.IsPunctuation(c) || char.IsWhiteSpace(c)).Distinct().ToArray();
            var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower());

            return words.GroupBy(w => w)
                        .Select(p => new KeyValuePair<string, int>(p.Key, p.Count()))
                        .OrderByDescending(p => p.Value)
                        .ToDictionary(p => p.Key, p => p.Value);
        }
    }
}
