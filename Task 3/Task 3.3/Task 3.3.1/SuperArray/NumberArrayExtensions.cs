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
