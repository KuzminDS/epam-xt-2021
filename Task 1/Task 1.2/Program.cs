using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Averages();
            Doubler();
            Lowercase();
            Validator();
        }

        static void Averages()
        {
            Console.WriteLine("\nStart of 1.2.1 AVERAGES\n");

            Console.Write("ВВОД: ");
            string text = Console.ReadLine();
            int symbolCount = 0;
            char[] separators = "[} \n\t\r.,;:!?(){]".ToArray();
            var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in words)
            {
                symbolCount += word.Length;
            }
            Console.WriteLine("ВЫВОД: " + symbolCount / words.Length); //округление происходит вниз

            Console.WriteLine("\nEnd of 1.2.1 AVERAGES\n");
        }

        static void Doubler()
        {
            Console.WriteLine("\nStart of 1.2.2 DOUBLER\n");

            Console.Write("ВВОД 1: ");
            string text = Console.ReadLine();
            Console.Write("ВВОД 2: ");
            string doubler = Console.ReadLine();
            var result = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                result.Append(text[i]);
                if (doubler.Contains(text[i]))
                {
                    result.Append(text[i]);
                }
            }
            Console.WriteLine("ВЫВОД: " + result);

            Console.WriteLine("\nEnd of 1.2.2 DOUBLER\n");
        }

        static void Lowercase() //вариант со *
        {
            Console.WriteLine("\nStart of 1.2.3 LOWERCASE\n");

            Console.Write("ВВОД: ");
            string text = Console.ReadLine();
            int lowerCaseWordCount = 0;
            char[] separators = "[} \n\t\r.,;:!?(){]".ToArray();
            foreach (var word in text.Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                if (char.IsLower(word[0]))
                {
                    lowerCaseWordCount++;
                }
            }
            Console.WriteLine("ВЫВОД: " + lowerCaseWordCount);


            Console.WriteLine("\nEnd of 1.2.3 LOWERCASE\n");
        }

        static void Validator()
        {
            Console.WriteLine("\nStart of 1.2.4 VALIDATOR\n");

            Console.Write("ВВОД: ");
            string text = Console.ReadLine();
            var result = new StringBuilder();
            var sentence = new StringBuilder();
            var separators = ".?!";
            foreach (var word in text.Split(' '))
            {
                sentence.AppendFormat("{0} ", word);
                if (separators.Contains(word[word.Length - 1]))
                {
                    sentence[0] = char.ToUpper(sentence[0]);
                    result.Append(sentence);
                    sentence.Clear();
                }
            }
            Console.WriteLine("ВЫВОД: " + result);

            Console.WriteLine("\nEnd of 1.2.4 VALIDATOR\n");
        }
    }
}
