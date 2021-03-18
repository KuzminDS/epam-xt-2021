using CustomStringLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing of CustomString");

            var s1 = new CustomString("meme");
            var s2 = new CustomString("aemes");
            Console.WriteLine(s1.CompareTo(s2));

            var str1 = new CustomString(' ');
            Console.WriteLine(str1);

            var str2 = new CustomString('H', 'e', 'l', 'l', 'o');
            Console.WriteLine(str2);

            var str3 = new CustomString("World");
            Console.WriteLine(str3);

            var str4 = str2 + str1 + str3;
            Console.WriteLine(str4);

            Console.WriteLine(str2.CompareTo(str3));

            Console.WriteLine(str2.Equals(str3));

            var str5 = new CustomString("Hello");
            Console.WriteLine(str2.Equals(str5));

            Console.WriteLine(str5.IndexOf('e'));
            Console.WriteLine(str5.LastIndexOf('l'));
            Console.WriteLine(str5.Contains('l'));

            char[] charArray = str5.ConvertToCharArray();
            for (int i = 0; i < charArray.Length; i++)
            {
                Console.Write(charArray[i]);
            }
            Console.WriteLine();

            Console.WriteLine(str4);
            Console.WriteLine("Колличество слов = " + str4.GetCountOfWords());

            Console.WriteLine(str5[1]);
            str5[1] = 'a';
            Console.WriteLine(str5);
        }
    }
}
