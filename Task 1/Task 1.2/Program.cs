using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._2
{
    class Program
    {
        static void Averages()
        {
            Console.WriteLine("\nStart of 1.1.1 AVERAGES\n");

            Console.Write("ВВОД: ");
            string text = Console.ReadLine();
            int symbolCount = 0;
            int wordCount = 0;
            char[] separators = "[} \n\t\r.,;:!?(){]".ToArray();
            foreach (var word in text.Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                symbolCount += word.Length;
                wordCount++;
            }
            Console.WriteLine("ВЫВОД: " + symbolCount / wordCount); //округление происходит вниз

            Console.WriteLine("\nEnd of 1.1.1 AVERAGES\n");
        }

        static void Doubler()
        {
            Console.WriteLine("\nStart of 1.1.2 DOUBLER\n");

            Console.Write("ВВОД 1: ");
            string text = Console.ReadLine();
            Console.Write("ВВОД 2: ");
            string doubler = Console.ReadLine();
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                result += text[i];
                if (doubler.Contains(text[i]))
                {
                    result += text[i];
                }
            }
            Console.WriteLine("ВЫВОД: " + result);

            Console.WriteLine("\nEnd of 1.1.2 DOUBLER\n");
        }

        static void Lowercase() //вариант со *
        {
            Console.WriteLine("\nStart of 1.1.3 LOWERCASE\n");

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


            Console.WriteLine("\nEnd of 1.1.3 LOWERCASE\n");
        }

        static void Validator()
        {
            Console.WriteLine("\nStart of 1.1.4 VALIDATOR\n");

            Console.Write("ВВОД: ");
            string text = Console.ReadLine();
            string result = "";
            string sentence = "";
            string separators = ".?!";
            foreach (var word in text.Split(' '))
            {
                sentence += word + " ";
                if (separators.Contains(word[word.Length - 1]))
                {
                    result += char.ToUpper(sentence[0]) + sentence.Substring(1, sentence.Length - 1);
                    sentence = "";
                }
            }
            Console.WriteLine("ВЫВОД: " + result);

            Console.WriteLine("\nEnd of 1.1.4 VALIDATOR\n");
        }

        static void Main(string[] args)
        {
            Averages();
            Doubler();
            Lowercase();
            Validator();
        }
    }
}
