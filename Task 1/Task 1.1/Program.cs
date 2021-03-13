using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Rectangle();
            Triangle();
            AnotherTriangle();
            XMasTree();
            SumOfNumbers();
            FontAdjustment();
            ArrayProcessing();
            NoPositive();
            NonNegativeSum();
            Array2D();
        }

        static int GetPositiveValue()
        {
            do
            {
                Console.Write("ВВОД: ");
                var value = Console.ReadLine();
                if (int.TryParse(value, out int result) && result > 0)
                    return result;
                else
                    Console.WriteLine("Error: The value is not positive. Enter again:");

            } while (true);
        }

        static void Rectangle()
        {
            Console.WriteLine("\nStart of 1.1.1 RECTANGLE\n");

            Console.WriteLine("Enter the side 'a' of the rectangle");
            int a = GetPositiveValue();
            Console.WriteLine("Enter the side 'b' of the rectangle");
            int b = GetPositiveValue();

            Console.WriteLine("The rectangle area is " + a * b);

            Console.WriteLine("\nEnd of 1.1.1 RECTANGLE\n");
        }

        static void Triangle()
        {
            Console.WriteLine("\nStart of 1.1.2 TRIANGLE\n");

            Console.WriteLine("Enter n:");
            int n = GetPositiveValue();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(new string('*', i + 1));
            }

            Console.WriteLine("\nEnd of 1.1.2 TRIANGLE\n");
        }

        static void PrintTriangle(int n, int spaceNum)
        {
            var stars = new StringBuilder("*");

            for (int i = 0; i < n; i++)
            {
                Console.Write(new string(' ', spaceNum));
                Console.WriteLine(stars);
                stars.Append("**");
                spaceNum--;
            }
        }

        static void AnotherTriangle()
        {
            Console.WriteLine("\nStart of 1.1.3 ANOTHER TRIANGLE\n");

            Console.WriteLine("Enter n:");
            int n = GetPositiveValue();
            //int spaceNum = n - 1;

            PrintTriangle(n, n - 1);
            //var stars = new StringBuilder("*");

            //for (int i = 0; i < n; i++)
            //{
            //    Console.Write(new string(' ', spaceNum));
            //    Console.WriteLine(stars);
            //    stars.Append("**");
            //    spaceNum--;
            //}

            Console.WriteLine("\nEnd of 1.1.3 ANOTHER TRIANGLE\n");
        }

        static void XMasTree()
        {
            Console.WriteLine("\nStart of 1.1.4 X-MAS TREE\n");

            Console.WriteLine("Enter n:");
            int n = GetPositiveValue();

            for (int k = 0; k < n; k++)
            {
                PrintTriangle(k + 1, n - 1);
                //int spaceNum = n - 1;
                //var stars = new StringBuilder("*");
                //for (int i = 0; i <= k; i++)
                //{
                //    Console.Write(new string(' ', spaceNum));
                //    Console.WriteLine(stars);
                //    stars.Append("**");
                //    spaceNum--;
                //} 
            }

            Console.WriteLine("\nEnd of 1.1.4 X-MAS TREE\n");
        }

        static void SumOfNumbers()
        {
            Console.WriteLine("\nStart of 1.1.5 SUM OF NUMBERS\n");

            int sum = 0;
            int n = 1000;

            for (int i = 3; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }

            Console.WriteLine("Sum = " + sum);

            Console.WriteLine("\nEnd of 1.1.5 SUM OF NUMBERS\n");
        }

        enum Fonts
        {
            Bold = 1,
            Italic,
            Underline
        }

        static void FontAdjustment()
        {
            Console.WriteLine("\nStart of 1.1.6 FONT ADJUSTMENT\n");

            string fontInfo = "Введите:\n" +
                "1: bold\n" +
                "2: italic\n" +
                "3: underline";

            var parameters = new List<Fonts>();

            Console.WriteLine("Введите 0, чтобы выйти");
            while (true)
            {
                Console.Write("Параметры надписи: ");
                if (parameters.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    for (int i = 0; i < parameters.Count; i++)
                    {
                        Console.Write(parameters[i]);
                        if (i != parameters.Count - 1)
                            Console.Write(", ");
                    }
                    Console.WriteLine();
                }

                Console.WriteLine(fontInfo);

                if (Enum.TryParse(Console.ReadLine(), out Fonts fontType))
                {
                    if (fontType == 0)
                        break;
                    else if (!Enum.IsDefined(typeof(Fonts), fontType))
                        continue;
                }
                else
                {
                    break;
                }

                if(parameters.Contains(fontType))
                    parameters.Remove(fontType);
                else
                    parameters.Add(fontType);
            }

            Console.WriteLine("\nEnd of 1.1.6 FONT ADJUSTMENT\n");
        }

        static int[] FillArray(int n, int minValue, int maxValue)
        {
            var array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(minValue, maxValue);
            }
            return array;
        }
        static int Max(int[] array)
        {
            int max = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                    max = array[i];
            }
            return max;
        }

        static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (min > array[i])
                    min = array[i];
            }
            return min;
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }

        static void SortArray(int[] array, int first, int last)
        {
            int pivot = array[(last - first) / 2 + first];
            int temp;
            int i = first, j = last;
            while (i <= j)
            {
                while (array[i] < pivot && i <= last) ++i;
                while (array[j] > pivot && j >= first) --j;
                if (i <= j)
                {
                    temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    ++i; --j;
                }
            }
            if (j > first) SortArray(array, first, j);
            if (i < last) SortArray(array, i, last);
        }

        static void ArrayProcessing()
        {
            Console.WriteLine("\nStart of 1.1.7 ARRAY PROCESSING\n");

            int n = 20;
            int minValue = -1000;
            int maxValue = 1000;
            int[] array = FillArray(n, minValue, maxValue);

            Console.Write("Array: ");
            PrintArray(array);

            Console.WriteLine("Max value of array is " + Max(array));
            Console.WriteLine("Min value of array is " + Min(array));

            SortArray(array, 0, n - 1);
            Console.Write("Sorted array: ");
            PrintArray(array);

            Console.WriteLine("\nEnd of 1.1.7 ARRAY PROCESSING\n");
        }

        static int[,,] Fill3DArray(int n)
        {
            Random random = new Random();
            var array = new int[n, n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        array[i, j, k] = random.Next(-100, 100);
                    }
                }
            }
            return array;
        }

        static void Print3DArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        Console.Write(array[i, j, k] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

        }
        static void NoPositive()
        {
            Console.WriteLine("\nStart of 1.1.8 NO POSITIVE\n");

            int n = 3;
            var array = Fill3DArray(n);
            Console.WriteLine("Initial array:");
            Print3DArray(array);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (array[i, j, k] > 0)
                        {
                            array[i, j, k] = 0;
                        }
                    }
                }
            }
            Console.WriteLine("New array:");
            Print3DArray(array);

            Console.WriteLine("\nEnd of 1.1.8 NO POSITIVE\n");
        }

        static void NonNegativeSum()
        {
            Console.WriteLine("\nStart of 1.1.9 NON-NEGATIVE SUM\n");

            int n = 20;
            var array = FillArray(n, -100, 100);
            Console.WriteLine("Random array:");
            PrintArray(array);

            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                    sum += array[i];
            }

            Console.WriteLine("Non-negative sum is " + sum);

            Console.WriteLine("\nEnd of 1.1.9 NON-NEGATIVE SUM\n");
        }

        static int[,] Fill2DArray(int firstDim, int secondDim)
        {
            Random random = new Random();
            var array = new int[firstDim, secondDim];
            for (int i = 0; i < firstDim; i++)
            {
                for (int j = 0; j < secondDim; j++)
                {
                    array[i, j] = random.Next(-100, 100);
                }
            }
            return array;
        }

        static void Print2DArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }

        }

        static void Array2D()
        {
            Console.WriteLine("\nStart of 1.1.10 2D ARRAY\n");

            int n = 5;
            var array = Fill2DArray(n, n);
            Console.WriteLine("Random 2D Array:");
            Print2DArray(array);

            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (i + j % 2 == 0)
                        sum += array[i, j];
                }
            }

            Console.WriteLine("Sum = " + sum);

            Console.WriteLine("\nEnd of 1.1.10 2D ARRAY\n");
        }
    }
}
