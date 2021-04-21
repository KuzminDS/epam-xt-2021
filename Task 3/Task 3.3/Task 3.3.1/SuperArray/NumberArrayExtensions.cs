using System;
using System.Collections.Generic;                  
using System.Linq;                                 
using System.Text;                                 
using System.Threading.Tasks;                      
                                                   
namespace SuperArray                               
{                                                  
    public static class NumberArrayExtensions                 
    {
        #region ByteArrayExtensions
        public static void ForEach(this byte[] array, Func<byte, byte> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static int GetSum(this byte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum(e => e);
        }

        public static byte GetMean(this byte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return (byte)(array.GetSum() / array.Length);
        }

        public static byte GetMode(this byte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region SbyteArrayExtensions
        public static void ForEach(this sbyte[] array, Func<sbyte, sbyte> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static int GetSum(this sbyte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum(e => e);
        }

        public static sbyte GetMean(this sbyte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return (sbyte)(array.GetSum() / array.Length);
        }

        public static sbyte GetMode(this sbyte[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region ShortArrayExtensions
        public static void ForEach(this short[] array, Func<short, short> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static int GetSum(this short[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum(e => e);
        }

        public static short GetMean(this short[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return (short)(array.GetSum() / array.Length);
        }

        public static short GetMode(this short[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region UshortArrayExtensions
        public static void ForEach(this ushort[] array, Func<ushort, ushort> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static int GetSum(this ushort[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum(e => e);
        }

        public static ushort GetMean(this ushort[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return (ushort)(array.GetSum() / array.Length);
        }

        public static ushort GetMode(this ushort[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region UintArrayExtensions
        public static void ForEach(this uint[] array, Func<uint, uint> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static uint GetSum(this uint[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return (uint)array.Sum(e => e);
        }

        public static uint GetMean(this uint[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.GetSum() / (uint)array.Length;
        }

        public static uint GetMode(this uint[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region IntArrayExtensions
        public static void ForEach(this int[] array, Func<int, int> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static int GetSum(this int[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum();
        }

        public static int GetMean(this int[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.Sum() / array.Length;
        }

        public static int GetMode(this int[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region UlongArrayExtensions
        public static void ForEach(this ulong[] array, Func<ulong, ulong> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static ulong GetSum(this ulong[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            ulong sum = 0;

            foreach (var item in array)
                sum += item;

            return sum;
        }

        public static ulong GetMean(this ulong[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.GetSum() / (ulong)array.Length;
        }

        public static ulong GetMode(this ulong[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region LongArrayExtensions
        public static void ForEach(this long[] array, Func<long, long> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static long GetSum(this long[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum(e => e);
        }

        public static long GetMean(this long[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.GetSum() / array.Length;
        }

        public static long GetMode(this long[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region FloatArrayExtensions
        public static void ForEach(this float[] array, Func<float, float> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static float GetSum(this float[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum();
        }

        public static float GetMean(this float[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.Sum() / array.Length;
        }

        public static float GetMode(this float[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region DoubleArrayExtensions
        public static void ForEach(this double[] array, Func<double, double> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static double GetSum(this double[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum();
        }

        public static double GetMean(this double[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.Sum() / array.Length;
        }

        public static double GetMode(this double[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion

        #region DecimalArrayExtensions
        public static void ForEach(this decimal[] array, Func<decimal, decimal> func)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = func(array[i]);
            }
        }

        public static decimal GetSum(this decimal[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            return array.Sum();
        }

        public static decimal GetMean(this decimal[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");


            return array.Sum() / array.Length;
        }

        public static decimal GetMode(this decimal[] array)
        {
            if (array == null)
                throw new NullReferenceException("Argument cannot be null");

            if (array.Length == 0)
                throw new ArgumentException("Array is empty");

            return array.GroupBy(e => e)
                        .OrderByDescending(g => g.Count())
                        .FirstOrDefault()
                        .Key;
        }
        #endregion
    }
}
