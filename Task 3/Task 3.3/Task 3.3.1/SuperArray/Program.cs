using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperArray
{
    class Program
    {
        static void Main(string[] args)
        {
            const int len = 5;

            var array = new double[len] { 3, 0, 4, 4, 9 };

            Console.WriteLine($"Sum = {array.GetSum()}");
            Console.WriteLine($"Mean = {array.GetMean()}");
            Console.WriteLine($"Mode = {array.GetMode()}");
        }
    }
}
