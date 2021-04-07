using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperString
{
    class Program
    {
        static void Main(string[] args)
        {
            var eng = "Hello";
            Console.WriteLine(eng.GetTextType());

            var rus = "Приветё";
            Console.WriteLine(rus.GetTextType());

            var num = "9890898";
            Console.WriteLine(num.GetTextType());

            var mixed = "sdflkjslkf dlfkjskd 8978 dksjflj? ";
            Console.WriteLine(mixed.GetTextType());
        }
    }
}
