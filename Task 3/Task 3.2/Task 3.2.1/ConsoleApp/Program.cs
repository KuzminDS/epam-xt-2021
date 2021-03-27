using DynamicArray;
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
            var array = new DynamicArray<int>();

            for (int i = 0; i < 5; i++)
            {
                array.Add(i);

                Console.WriteLine($"elem = {array[i]} len =  {array.Length} cap = {array.Capacity}");
            }

            var newArray = new DynamicArray<int>(new List<int>() { 1, 2, 3, 4, 5, 6 });
            newArray.Add(1);
            newArray.Insert(4, 5);
            foreach (var item in newArray)
            {
                Console.WriteLine($"elem = {item} len =  {newArray.Length} cap = {newArray.Capacity}");
            }

            Console.WriteLine(newArray[-2]);

            newArray.Remove(2);

            foreach (var item in newArray)
            {
                Console.WriteLine($"elem = {item} len =  {newArray.Length} cap = {newArray.Capacity}");
            }

            try
            {
                newArray.Insert(100, 5);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            newArray.AddRange(new List<int>() { 1, 2, 3, 4, 5, 6 });

            foreach (var item in newArray)
            {
                Console.WriteLine($"elem = {item} len =  {newArray.Length} cap = {newArray.Capacity}");
            }


            var cycledArray = new CycledDynamicArray<int>(array);

            //foreach (var item in cycledArray) //inf loop
            //{
            //    Console.WriteLine($"elem = {item} len =  {cycledArray.Length} cap = {cycledArray.Capacity}");
            //}
        }
    }
}
